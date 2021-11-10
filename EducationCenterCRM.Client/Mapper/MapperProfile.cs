using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.DAL.Entities;

namespace EducationCenterCRM.PresentationLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {


            CreateMap<Student, StudentDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.EducationCenterUser.PersonName))
                .ForMember(x => x.Lastname, opt => opt.MapFrom(x => x.EducationCenterUser.PersonLastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.EducationCenterUser.Email))
                 .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.EducationCenterUser.PhoneNumber));
            CreateMap<StudentDTO, Student>();

            CreateMap<Group, GroupDTO>()
                .ForMember(x => x.CourseTitle, opt => opt.MapFrom(x => x.Course.Title))
                 .ForMember(x => x.TeacherName, opt => opt.MapFrom(x => $"{x.Teacher.EducationCenterUser.PersonName} {x.Teacher.EducationCenterUser.PersonLastName}"));
            CreateMap<GroupDTO, Group>();


            CreateMap<Topic, TopicDTO>().ReverseMap();

            CreateMap<Course, CourseDTO>().ReverseMap();


            CreateMap<StudingRequest, StudingRequestDTO>();

            CreateMap<Teacher, TeacherDTO>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.EducationCenterUser.PersonName} {x.EducationCenterUser.PersonLastName}"))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.EducationCenterUser.Email))
                .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.EducationCenterUser.PhoneNumber));
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<StudingRequest, StudingRequestDTO>();

            CreateMap<EducationCenterUser, UserDTO>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.PersonName} {x.PersonLastName}"));

        }
    }
}
