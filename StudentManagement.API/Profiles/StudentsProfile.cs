using AutoMapper;
using StudentManagement.API.Helpers;

namespace StudentManagement.API.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Entities.Student, Models.StudentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                );

            CreateMap<Models.StudentForCreationDto, Entities.Student>();
            CreateMap<Models.StudentForUpdateDto, Entities.Student>();
            CreateMap<Entities.Student, Entities.User>();
        }
    }
}