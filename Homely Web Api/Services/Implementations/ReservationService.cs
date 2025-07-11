using Homely_Web_Api.Data;
using Homely_Web_Api.DTOs.ReservationDtos;
using Homely_Web_Api.Models;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Homely_Web_Api.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public ReservationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ReservationDto> CreateReservationAsync(CreateReservationDto createReservationDto, int userId)
        {
            var unit = await _context.ResidentialUnits
                .Include(u => u.Location)
                .FirstOrDefaultAsync(u => u.Id == createReservationDto.UnitId);

            if (unit == null)
            {
                throw new InvalidOperationException("The unit does not exist.");
            }

            var checkIn = DateOnly.FromDateTime(createReservationDto.CheckIn);
            var checkOut = DateOnly.FromDateTime(createReservationDto.CheckOut);

            var checkUnit = await _context.Reservations
                .AnyAsync(r => r.UnitId == createReservationDto.UnitId &&
                          r.Status != "Cancelled" &&
                          r.CheckIn < checkIn &&
                          r.CheckOut > checkOut);

            if (checkUnit)
            {
                throw new InvalidOperationException("This unit is already booked for the selected dates.");
            }

            if (createReservationDto.CheckIn >= createReservationDto.CheckOut)
            {
                throw new InvalidOperationException("Check-in date must be before check-out date.");
            }

            if (createReservationDto.CheckIn < DateTime.Today)
            {
                throw new InvalidOperationException("Cannot make a reservation in the past.");
            }

            var totalDays = (createReservationDto.CheckOut - createReservationDto.CheckIn).TotalDays;

            var reservation = new Reservation
            {
                UserId = userId,
                UnitId = createReservationDto.UnitId,
                CheckIn = DateOnly.FromDateTime(createReservationDto.CheckIn),
                CheckOut = DateOnly.FromDateTime(createReservationDto.CheckOut),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = "Pending",
                TotalPrice = unit.Price * (decimal)totalDays,
                GuestsNum = createReservationDto.GuestsNum,
                IdentificationNumber = createReservationDto.IdentificationNumber,
                Notes = createReservationDto.Notes
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return new ReservationDto
            {
                Id = reservation.Id,
                UnitTitle = unit.Title,
                Location = $"{unit.Location.City}, {unit.Location.Country}",
                CheckIn = DateOnly.FromDateTime(reservation.CheckIn.ToDateTime(TimeOnly.MinValue)), // Fix: Convert DateOnly to DateTime
                CheckOut = DateOnly.FromDateTime(reservation.CheckOut.ToDateTime(TimeOnly.MinValue)), // Fix: Convert DateOnly to DateTime
                CreatedAt = reservation.CreatedAt,
                UpdatedAt = reservation.UpdatedAt,
                Status = reservation.Status,
                TotalPrice = reservation.TotalPrice,
                GuestsNum = reservation.GuestsNum,
                IdentificationNumber = reservation.IdentificationNumber,
                Notes = reservation.Notes
            };
        }
        public async Task<IEnumerable<ReservationDto>> GetReservationsByUserIdAsync(int userId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.UserId == userId)
                .Include(r => r.Unit)
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    UnitTitle = r.Unit.Title,
                    CheckIn = r.CheckIn,
                    CheckOut = r.CheckOut,
                    CreatedAt = r.CreatedAt,
                    Status = r.Status,
                    TotalPrice = r.TotalPrice,
                    GuestsNum = r.GuestsNum,
                    IdentificationNumber = r.IdentificationNumber,
                    Notes = r.Notes
                }).ToListAsync();

            return reservations;
        }

        public async Task<ReservationDto> UpdateReservationStatusAsync(int id, UpdateReservationDto updateReservationDto, int userId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Unit)
                .FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);

            var unit = await _context.ResidentialUnits
               .Include(u => u.Location)
               .FirstOrDefaultAsync(u => u.Id == reservation.UnitId);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            if (updateReservationDto.CheckIn.HasValue || updateReservationDto.CheckOut.HasValue)
            {
                if (updateReservationDto.CheckIn >= updateReservationDto.CheckOut)
                    throw new InvalidOperationException("Check-in date must be before check-out date.");

                if (updateReservationDto.CheckIn < DateOnly.FromDateTime(DateTime.Today))
                    throw new InvalidOperationException("Cannot make a reservation in the past.");

                var isOverlapping = await _context.Reservations.AnyAsync(r =>
                    r.UnitId == reservation.UnitId &&
                    r.Id != reservation.Id &&
                    r.Status != "Cancelled" &&
                    r.CheckIn < updateReservationDto.CheckOut &&
                    r.CheckOut > updateReservationDto.CheckIn);

                if (isOverlapping)
                    throw new InvalidOperationException("This unit is already booked for the selected dates.");

                reservation.CheckIn = updateReservationDto.CheckIn.Value;
                reservation.CheckOut = updateReservationDto.CheckOut.Value;
            }

            if (updateReservationDto.GuestsNum.HasValue)
                reservation.GuestsNum = updateReservationDto.GuestsNum.Value;

            if (updateReservationDto.IdentificationNumber.HasValue)
                reservation.IdentificationNumber = updateReservationDto.IdentificationNumber.Value;

            if (!string.IsNullOrWhiteSpace(updateReservationDto.Notes))
                reservation.Notes = updateReservationDto.Notes;

            if (!string.IsNullOrWhiteSpace(updateReservationDto.Status))
                reservation.Status = updateReservationDto.Status;

            reservation.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ReservationDto
            {
                Id = reservation.Id,
                UnitTitle = reservation.Unit.Title,
                Location = $"{unit.Location.City}, {unit.Location.Country}",
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                CreatedAt = reservation.CreatedAt,
                UpdatedAt = reservation.UpdatedAt,
                Status = reservation.Status,
                TotalPrice = reservation.TotalPrice,
                GuestsNum = reservation.GuestsNum,
                IdentificationNumber = reservation.IdentificationNumber,
                Notes = reservation.Notes
            };
        }
    }
}
