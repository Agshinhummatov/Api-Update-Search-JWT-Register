using AutoMapper;
using Domain.Models;
using Services.DTOs.Account;
using Services.DTOs.City;
using Services.DTOs.Country;
using Services.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeUpdateDto, Employee>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryUpdateDto, Country>().ReverseMap();



            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityUpdateDto, City>().ReverseMap();

            CreateMap<RegisterDto, AppUser>();


        }
    }
}
