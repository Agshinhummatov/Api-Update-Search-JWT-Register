using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Services.DTOs.City;
using Services.DTOs.Country;
using Services.DTOs.Employee;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }


        public async Task CreateAsync(CountryCreateDto employee) => await _countryRepo.CreateAsync(_mapper.Map<Country>(employee));

        public async Task<IEnumerable<CountryDto>> GetAllAsync() => _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.FindAllAsync());

        public async Task<CountryDto> GetByIdAsync(int? id) => _mapper.Map<CountryDto>(await _countryRepo.GetByIdAsync(id));

        public async Task DeleteAsync(int? id) => await _countryRepo.DeleteAsync(await _countryRepo.GetByIdAsync(id));

        public async Task UpdateAsync(int id, CountryUpdateDto country)
        {
            var dbCountry = await _countryRepo.GetByIdAsync(id);

            _mapper.Map(country, dbCountry);

            await _countryRepo.UpdateAsync(dbCountry);
        }

        public async Task<IEnumerable<CountryDto>> SerachAsync(string serachTeaxt) => _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.FindAllAsync(m => m.Name.Contains(serachTeaxt)));

        public async Task SoftDeleteAsync(int? id)
        {
            await _countryRepo.SoftDeleteAsync(id);
        }

    }
}
