﻿using AutoMapper;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;

namespace EducationCenterCRM.PresentationLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student,StudentRequest>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();

            CreateMap<Group, GroupRequest>().ReverseMap();
            CreateMap<Group, GroupResponse>().ReverseMap();

            CreateMap<Topic, TopicRequest>().ReverseMap();
            CreateMap<Topic, TopicResponse>().ReverseMap();

            CreateMap<Course, CourseRequest>().ReverseMap();
            CreateMap<Course, CourseResponse>().ReverseMap();


            CreateMap<Teacher, TeacherRequest>().ReverseMap();
            CreateMap<Teacher, TeacherResponse>().ReverseMap();
        }
    }
}
