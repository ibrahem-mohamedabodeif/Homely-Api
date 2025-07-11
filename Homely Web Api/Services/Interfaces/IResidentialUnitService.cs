using Homely_Web_Api.DTOs.ResidentialUnitDtos;
using Homely_Web_Api.Models.Residential_Units;

namespace Homely_Web_Api.Services.Interfaces
{
    public interface IResidentialUnitService
    {
        Task<IEnumerable<UnitDto>> GetAllResidentialUnitsAsync();
        Task<UnitDto?> GetResidentialUnitByIdAsync(int id);
        Task<IEnumerable<UnitDto>> GetResidentialUnitsByHostIdAsync(int hostId);
        Task<int> CreateResidentialUnitAsync(CreateUnitDto Unit, int hostId);
        Task<bool> UpdateResidentialUnitAsync(UpdateUnitDto residentialUnit, int unitId, int hostId);
        Task<bool> DeleteResidentialUnitAsync(int id, int hostId);
    }
}
