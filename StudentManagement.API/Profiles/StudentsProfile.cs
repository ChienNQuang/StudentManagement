using AutoMapper;
using StudentManagement.API.Helpers;
using StudentManagement.API.Models.DTOs;
using StudentManagement.API.Models.Entities;

namespace StudentManagement.API.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                );

            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();
            CreateMap<Student, User>();
        }
    }
}