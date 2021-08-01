using AutoMapper;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.PresentationLayer.Models;

namespace EducationCenterCRM.PresentationLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<Group, GroupViewModel>();
            CreateMap<Teacher, TeacherViewModel>().ForMember(tv=>tv.FullName,opt=>opt.MapFrom(x=>$"{x.Name} {x.Lastname}"));

        }
    }
}
