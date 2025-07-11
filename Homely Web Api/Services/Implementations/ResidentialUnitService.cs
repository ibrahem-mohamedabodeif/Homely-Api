using Homely_Web_Api.Data;
using Homely_Web_Api.DTOs.ResidentialUnitDtos;
using Homely_Web_Api.Models.Residential_Units;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Homely_Web_Api.Services.Implementations
{
    public class ResidentialUnitService : IResidentialUnitService
    {
        private readonly AppDbContext _context;
        public ResidentialUnitService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateResidentialUnitAsync(CreateUnitDto unit, int hostId)
        {
            var location = new Location
            {
                Address = unit.Address,
                City = unit.City,
                State = unit.State,
                Country = unit.Country
            };

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == unit.Category.ToLower());

            var residentialUnit = new ResidentialUnit
            {
                Title = unit.Title,
                SubTitle = unit.SubTitle,
                Description = unit.Description,
                Price = unit.Price,
                Capacity = unit.Capacity,
                BedroomsNum = unit.BedroomsNum,
                BathroomsNum = unit.BathroomsNum,
                BedsNum = unit.BedsNum,
                CategoryId = category.Id,
                LocationId = location.Id,
                HostId = hostId
            };

            _context.ResidentialUnits.Add(residentialUnit);
            await _context.SaveChangesAsync();

            return residentialUnit.Id;


        }
        public async Task<bool> UpdateResidentialUnitAsync(UpdateUnitDto residentialUnit, int unitId, int hostId)
        {
            var existingUnit = await _context.ResidentialUnits
                .Include(u => u.Location)
                .FirstOrDefaultAsync(u => u.Id == unitId && u.HostId == hostId);

            

            if (existingUnit == null) return false;

            if (!string.IsNullOrWhiteSpace(residentialUnit.Title)) existingUnit.Title = residentialUnit.Title;
            if (!string.IsNullOrWhiteSpace(residentialUnit.SubTitle)) existingUnit.SubTitle = residentialUnit.SubTitle;
            if (!string.IsNullOrWhiteSpace(residentialUnit.Description)) existingUnit.Description = residentialUnit.Description;
            if (residentialUnit.Price.HasValue) existingUnit.Price = residentialUnit.Price.Value;
            if (residentialUnit.Capacity.HasValue) existingUnit.Capacity = residentialUnit.Capacity.Value;
            if (residentialUnit.BedroomsNum.HasValue) existingUnit.BedroomsNum = residentialUnit.BedroomsNum.Value;
            if (residentialUnit.BathroomsNum.HasValue) existingUnit.BathroomsNum = residentialUnit.BathroomsNum.Value;
            if (residentialUnit.BedsNum.HasValue) existingUnit.BedsNum = residentialUnit.BedsNum.Value;
            if (!string.IsNullOrWhiteSpace(residentialUnit.Category))
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Name.ToLower() == residentialUnit.Category.ToLower());

                if (category != null)
                    existingUnit.CategoryId = category.Id;
            }
            if (existingUnit.Location != null)
            {
                if (!string.IsNullOrWhiteSpace(residentialUnit.Address)) existingUnit.Location.Address = residentialUnit.Address;
                if (!string.IsNullOrWhiteSpace(residentialUnit.City)) existingUnit.Location.City = residentialUnit.City;
                if (!string.IsNullOrWhiteSpace(residentialUnit.State)) existingUnit.Location.State = residentialUnit.State;
                if (!string.IsNullOrWhiteSpace(residentialUnit.Country)) existingUnit.Location.Country = residentialUnit.Country;
            }

                await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> DeleteResidentialUnitAsync(int id, int hostId)
        {
            var unit = await _context.ResidentialUnits
                   .Include(u => u.Location)
                   .FirstOrDefaultAsync(u => u.Id == id);

            if (unit == null) return false;

            _context.ResidentialUnits.Remove(unit);
            if (unit.Location != null)
            {
                _context.Locations.Remove(unit.Location);
            }

            if (unit.WishListItems != null)
            {
            _context.WishList.RemoveRange(unit.WishListItems);
            }

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<UnitDto>> GetAllResidentialUnitsAsync()
        {
            var units = await _context.ResidentialUnits
                .Include(u => u.Location)
                .Include(u => u.Category)
                .Include(u => u.Host)
                .ToListAsync();
            return units.Select(u => new UnitDto
            {
                Id = u.Id,
                Title = u.Title,
                SubTitle = u.SubTitle,
                Description = u.Description,
                Price = u.Price,
                Capacity = u.Capacity,
                BedroomsNum = u.BedroomsNum,
                BathroomsNum = u.BathroomsNum,
                BedsNum = u.BedsNum,
                Location = $"{u.Location.Address}, {u.Location.City}, {u.Location.State}, {u.Location.Country}",
                Category = u.Category.Name,
                Hostedby = $"{u.Host.FirstName} {u.Host.LastName}"
            });
        }
        public async Task<UnitDto?> GetResidentialUnitByIdAsync(int id)
        {
            var unit = await _context.ResidentialUnits
                .Include(u => u.Location)
                .Include(u => u.Category)
                .Include(u => u.Host)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (unit == null) return null;
            return new UnitDto
            {
                Id = unit.Id,
                Title = unit.Title,
                SubTitle = unit.SubTitle,
                Description = unit.Description,
                Price = unit.Price,
                Capacity = unit.Capacity,
                BedroomsNum = unit.BedroomsNum,
                BathroomsNum = unit.BathroomsNum,
                BedsNum = unit.BedsNum,
                Location = $"{unit.Location.Address}, {unit.Location.City}, {unit.Location.State}, {unit.Location.Country}",
                Category = unit.Category.Name,
                Hostedby = $"{unit.Host.FirstName} {unit.Host.LastName}"
            };
        }
        public async Task<IEnumerable<UnitDto>> GetResidentialUnitsByHostIdAsync(int hostId)
        {
            var units = await _context.ResidentialUnits
                .Include(u => u.Location)
                .Include(u => u.Category)
                .Include(u => u.Host)
                .Where(u => u.HostId == hostId)
                .ToListAsync();
            return units.Select(u => new UnitDto
            {
                Id = u.Id,
                Title = u.Title,
                SubTitle = u.SubTitle,
                Description = u.Description,
                Price = u.Price,
                Capacity = u.Capacity,
                BedroomsNum = u.BedroomsNum,
                BathroomsNum = u.BathroomsNum,
                BedsNum = u.BedsNum,
                Location = $"{u.Location.Address}, {u.Location.City}, {u.Location.State}, {u.Location.Country}",
                Category = u.Category.Name,
                Hostedby = $"{u.Host.FirstName} {u.Host.LastName}"
            });
        }

        
    }
}
