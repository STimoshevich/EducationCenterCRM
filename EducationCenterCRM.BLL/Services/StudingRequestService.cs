using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using EducationCenterCRM.Services.Interfaces.BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class StudingRequestService : IStudingRequestService
    {
        private readonly StudingRequestRepository studingRequestRepository;
        private readonly GroupsRepository groupsRepository;
        private readonly IStudentService studentService;
        private readonly StudentsRepository studentsRepository;
        private readonly IMapper mapper;
        private readonly ICourseService courseService;
        private readonly IIdentityService identityService;

        public StudingRequestService(
            StudingRequestRepository studingRequestRepository,
            GroupsRepository groupsRepository,
            IStudentService studentService,
            StudentsRepository studentsRepository,
            IMapper mapper,
            ICourseService courseService,
            IIdentityService identityService
           )
        {
            this.studingRequestRepository = studingRequestRepository;
            this.groupsRepository = groupsRepository;
            this.studentService = studentService;
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
            this.courseService = courseService;
            this.identityService = identityService;
        }

        public async Task<bool> AddNewAsync(int courseId)
        {
            var added = 0;
            if (courseId > 0)
            {
                var course = await courseService.GetByIdAsync(courseId);
                if (course is not null)
                {

                    var user = await identityService.GetCurrentUserAsync();
                    if (user is not null)
                    {
                        var student = await studentService.GetByUserIdAsync(user.Id);
                        if (student is not null)
                        {
                            var newStudingRequest = new StudingRequest()
                            {
                                CourseId = courseId,
                                CourseName = course.Title,
                                StudentId = user.Id,
                                StudentFullName = $"{user.PersonName} {user.PersonLastName}",
                                Created = DateTime.Now,
                                Status = StudingRequestStatus.Open
                            };

                            added = await studingRequestRepository.AddAsync(newStudingRequest);
                        }

                    }

                }

            }
            return added > 0 ? true : false;
        }

        public async Task<StudingRequestsListDTO> GetAllOpenAsync(int page, int itemsPerPage)
        {
            var result = new StudingRequestsListDTO();
            var allRequests =await studingRequestRepository.FindAsync(predicate: x=>x.Status == StudingRequestStatus.Open, page,itemsPerPage);
            result.Requests = mapper.Map<List<StudingRequestDTO>>(allRequests);
            result.RequestsAmount = await studingRequestRepository.CountAsync(predicate: x => x.Status == StudingRequestStatus.Open);
            return result;
        }

        public async Task<StudingRequestsListDTO> GetAllClosedAsync(int page, int itemsPerPage)
        {
            var result = new StudingRequestsListDTO();
            var allRequests = await studingRequestRepository.FindAsync(predicate: x => x.Status == StudingRequestStatus.Closed, page, itemsPerPage);
            result.Requests = mapper.Map<List<StudingRequestDTO>>(allRequests);
            result.RequestsAmount = await studingRequestRepository.CountAsync(predicate: x => x.Status == StudingRequestStatus.Open);
            return result;
        }

        public IEnumerable<string> GetAllStydingTypes()
        {
            return Enum.GetNames(typeof(StudingType));
        }

        public async Task ConfirmRequestAsync(int requestId, int groupId)
        {
            var request = await studingRequestRepository.GetByPredicateOrDefaulAsync(x => x.Id == requestId, IsTracking:false) ;
            var group = await groupsRepository.GetByPredicateOrDefaulAsync(x=>x.Id == groupId,include:x=>x.Include(x=>x.Students)) ;

            if(request is not null && group is not null)
            {
                var student = await studentsRepository.GetByPredicateOrDefaulAsync(x=>x.EducationCenterUserId == request.StudentId);
                if(student is not null)
                {
                    group.Students.Add(student); 
                    await groupsRepository.UpdateAsync(group);
                    request.Status = StudingRequestStatus.Closed;
                   await studingRequestRepository.UpdateAsync(request);

                }

            }
        }
    }
}
