
using Services.DTOs.City;


namespace Services.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int? id);
        Task CreateAsync(CityCreateDto city);
        Task DeleteAsync(int? id);

        Task UpdateAsync(int id, CityUpdateDto city);

        Task<IEnumerable<CityDto>> SerachAsync(string serachTeaxt);

        Task SoftDeleteAsync(int? id);
    }
}
