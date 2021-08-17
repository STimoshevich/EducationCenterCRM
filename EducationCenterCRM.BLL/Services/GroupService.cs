using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using EducationCenterCRM.Services.Interfaces.BLL;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EducationCenterCRM.Services.BLL
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> groupRepository;
        private readonly IMapper mapper;

        public GroupService(IRepository<Group> groupRepository, IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }


        public async Task<List<GroupResponse>> GetAllAsync()
        {
            var allGroups = await groupRepository.GetAllAsync();          
            return mapper.Map<List<GroupResponse>>(allGroups);
        }

        public async Task<bool> AddNewAsync(GroupRequest groupRequest)
        {
            var added = 0;
            if (groupRequest is not null)
            {
               var group =  mapper.Map<Group>(groupRequest);
                added = await groupRepository.AddAsync(group);
            }
            return added > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(int id,GroupRequest groupRequest)
        {
            var updated = 0;
            if (groupRequest is not null)
            {
                var newGroup = mapper.Map<Group>(groupRequest);
                newGroup.Id = id;
                updated = await groupRepository.UpdateAsync(newGroup);
            }
            return updated > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await groupRepository.DeleteAsync(id);
            return deleted > 0 ? true: false;
        }
        public async Task<GroupResponse> GetByIdAsync(int id)
        {
            var group = await groupRepository.GetByPredicateOrDefaulAsync(predicate: x => x.Id == id);
            return mapper.Map<GroupResponse>(group);
        }
    }
}
