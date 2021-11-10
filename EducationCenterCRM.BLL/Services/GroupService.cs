using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using EducationCenterCRM.DAL.Filteres.GroupFilters;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.BLL
{
    public class GroupService : IGroupService
    {
        private readonly GroupsRepository groupRepository;
        private readonly StudingRequestRepository studingRequestRepository;
        private readonly IMapper mapper;
        private readonly TeachersRepository teachersRepository;

        public GroupService(GroupsRepository groupRepository, StudingRequestRepository studingRequestRepository, IMapper mapper, TeachersRepository teachersRepository)
        {
            this.groupRepository = groupRepository;
            this.studingRequestRepository = studingRequestRepository;
            this.mapper = mapper;
            this.teachersRepository = teachersRepository;
        }


        public async Task<GroupListDTO> GetAllAsync(int page, int itemsPerPage)
        {
            var result = new GroupListDTO();
            var allGroups = await groupRepository.GetAllAsync(page, itemsPerPage, include: x => x.Include(x => x.Course).Include(x => x.Teacher).ThenInclude(x=>x.EducationCenterUser));
            var count = await groupRepository.CountAsync();
            result.Groups = mapper.Map<List<GroupDTO>>( allGroups);
            return result;
        }

        public async Task<GroupListDTO> GetByFilter(GroupFilter filter, int currentPage, int itemsPerPage)
        {

            var result = new GroupListDTO();
            var filteredGroups = await groupRepository.FilterAsync(filter, currentPage, itemsPerPage);
            if (filteredGroups.List is not null)
            {
                result.Groups = mapper.Map<List<GroupDTO>>(filteredGroups.List);
                result.GroupsAmount = filteredGroups.ItemsAmount;
                return result;
            }



            return await GetAllAsync(currentPage, itemsPerPage);
        }

        public async Task<bool> AddNewAsync(GroupDTO groupRequest)
        {
            var added = 0;
            if (groupRequest is not null)
            {
                var group = mapper.Map<Group>(groupRequest);
                added = await groupRepository.AddAsync(group);
            }
            return added > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(GroupDTO groupRequest)
        {
            var updated = 0;
            if (groupRequest is not null)
            {
                var teacher = await teachersRepository.GetByPredicateOrDefaulAsync(x => x.Id == groupRequest.TeacherId);
                var newGroup = mapper.Map<Group>(groupRequest);
                updated = await groupRepository.UpdateAsync(newGroup);
            }
            return updated > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await groupRepository.DeleteAsync(id);
            return deleted > 0 ? true : false;
        }
        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var group = await groupRepository.GetByPredicateOrDefaulAsync(include: x => x.Include(x => x.Course).Include(x=>x.Teacher).ThenInclude(x=>x.EducationCenterUser), predicate: x => x.Id == id, IsTracking: false);
            return mapper.Map<GroupDTO>(group);
        }

        public IEnumerable<string> GetAllGroupStatusNames()
        {
            foreach (var statusName in Enum.GetNames(typeof(GroupStatus)))
            {
                yield return statusName;
            }
        }

      
        public async Task<IEnumerable<GroupDTO>> FindGroupsForRequest(int requestId)
        {
            var request = await studingRequestRepository.GetByPredicateOrDefaulAsync(x=>x.Id == requestId);
            if(request is not null)
            {
                var res = await groupRepository.FindAsync(
                include: x=>x.Include(x=>x.Course).Include(x=>x.Students),
                IsTracking: false,
                predicate: x => (x.StudingType == request.StudingType || x.StudingType == StudingType.Mix) && x.Course.Title == request.CourseName && x.StudentCapacity > x.Students.Count());
                return mapper.Map<IEnumerable<GroupDTO>>(res);
            }
            return null;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsByGroupId(int groupId)
        {
            var group = await groupRepository.GetByPredicateOrDefaulAsync(predicate: x=>x.Id == groupId, IsTracking:false, include: x=>x.Include(x=>x.Students));
            if(group is not null)
            {
                return mapper.Map<IEnumerable<StudentDTO>>(group.Students);
            }
            return null;
        }
    }
}
