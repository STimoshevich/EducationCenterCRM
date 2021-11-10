using AutoMapper;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;

namespace EducationCenterCRM.PresentationLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student,StudentDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();

            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();

            CreateMap<Topic, TopicDTO>().ReverseMap();
            CreateMap<Topic, TopicDTO>().ReverseMap();

            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();


            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
        }
    }
}
