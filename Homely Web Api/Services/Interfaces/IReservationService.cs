using Homely_Web_Api.DTOs.ReservationDtos;

namespace Homely_Web_Api.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> CreateReservationAsync(CreateReservationDto createReservationDto, int userId);
        Task<ReservationDto> UpdateReservationStatusAsync(int id, UpdateReservationDto updateReservationDto, int userId);
        Task<IEnumerable<ReservationDto>> GetReservationsByUserIdAsync(int userId);
    }
}
