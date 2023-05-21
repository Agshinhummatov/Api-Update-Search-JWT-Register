using AutoMapper;
using Domain.Models;

using Repository.Repositories.Interfaces;
using Services.DTOs.City;

using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }


        public async Task CreateAsync(CityCreateDto city) => await _cityRepo.CreateAsync(_mapper.Map<City>(city));

        public async Task DeleteAsync(int? id) => await _cityRepo.DeleteAsync(await _cityRepo.GetByIdAsync(id));

        public async Task<IEnumerable<CityDto>> GetAllAsync() => _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.FindAllAsync());


        public async Task<CityDto> GetByIdAsync(int? id) => _mapper.Map<CityDto>(await _cityRepo.GetByIdAsync(id));

        public async Task<IEnumerable<CityDto>> SerachAsync(string serachTeaxt) => _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.FindAllAsync(m => m.Name.Contains(serachTeaxt)));

        public async Task SoftDeleteAsync(int? id)
        {
            await _cityRepo.SoftDeleteAsync(id);
        }


        public async Task UpdateAsync(int id, CityUpdateDto city)
        {
            if (id == null) throw new ArgumentNullException();

            var data = await _cityRepo.GetByIdAsync(id);
            if (data == null) throw new NullReferenceException();

            _mapper.Map(city, data);
            await _cityRepo.UpdateAsync(data);
        }

    }
}
