using Homely_Web_Api.DTOs.ResidentialUnitDtos;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homely_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController(IResidentialUnitService unitService) : ControllerBase
    {
        private readonly IResidentialUnitService _unitService = unitService;

        [HttpPost]
        [Authorize(Roles = "host")]
        public async Task<IActionResult> AddUnite([FromBody] CreateUnitDto unit)
        {
            try
            {
                var hostId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var unitId = await _unitService.CreateResidentialUnitAsync(unit, hostId);
                return Ok(unitId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "host")]
        public async Task<IActionResult> UpdateUnit(int id, [FromBody] UpdateUnitDto unit)
        {
            try
            {
                var hostId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _unitService.UpdateResidentialUnitAsync(unit, id, hostId);
                if (result)
                {
                    return Ok(new { message = "Unit updated successfully" });
                }
                return NotFound(new { message = "Unit not found or you are not the host" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "host")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            try
            {
                var hostId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _unitService.DeleteResidentialUnitAsync(id, hostId);
                if (result)
                {
                    return Ok(new { message = "Unit deleted successfully" });
                }
                return NotFound(new { message = "Unit not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            try
            {
                var units = await _unitService.GetAllResidentialUnitsAsync();
                return Ok(units);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            try
            {
                var unit = await _unitService.GetResidentialUnitByIdAsync(id);
                if (unit != null)
                {
                    return Ok(unit);
                }
                return NotFound(new { message = "Unit not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("host")]
        [Authorize(Roles = "host")]
        public async Task<IActionResult> GetUnitsByHostId()
        {
            try
            {
                var hostId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var units = await _unitService.GetResidentialUnitsByHostIdAsync(hostId);
                return Ok(units);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

}
