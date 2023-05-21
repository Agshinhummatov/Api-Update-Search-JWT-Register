
using Services.DTOs.Country;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();

        Task<CountryDto> GetByIdAsync(int? id);

        Task CreateAsync(CountryCreateDto country);
        Task DeleteAsync(int? id);

        Task UpdateAsync(int id, CountryUpdateDto country);

        Task<IEnumerable<CountryDto>> SerachAsync(string serachTeaxt);

        Task SoftDeleteAsync(int? id);

    }
}
