using Homely_Web_Api.DTOs.ReservationDtos;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homely_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController(IReservationService service) : ControllerBase
    {
        private readonly IReservationService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            if (createReservationDto == null)
            {
                return BadRequest("Invalid reservation data.");
            }
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                var reservation = await _service.CreateReservationAsync(createReservationDto, userId);

                return Ok(reservation);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservationStatus(int id, [FromBody] UpdateReservationDto updateReservationDto)
        {
            if (updateReservationDto == null)
            {
                return BadRequest("Invalid reservation data.");
            }
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                var updatedReservation = await _service.UpdateReservationStatusAsync(id, updateReservationDto, userId);

                return Ok(updatedReservation);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> GetUserReservations()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                var reservations = await _service.GetReservationsByUserIdAsync(userId);
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
