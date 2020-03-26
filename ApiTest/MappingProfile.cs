using ApiTest.DTOs;
using ApiTest.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<School, SchoolDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            
            //komentar Gabriela 
        }
    }
}
