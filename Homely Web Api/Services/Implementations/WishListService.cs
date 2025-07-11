using Homely_Web_Api.Data;
using Homely_Web_Api.DTOs.WishListDtos;
using Homely_Web_Api.Models;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Homely_Web_Api.Services.Implementations
{
    public class WishListService : IWishListService
    {
        private readonly AppDbContext _context;
        public WishListService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddItemToWishListAsync(int userId, int unitId)
        {
            var ifExists = IsItemInWishListAsync(userId, unitId).Result;

            if (ifExists) return false;

            var wishListItem = new WishListItem
            {
                UnitId = unitId,
                UserId = userId
            };
            _context.WishList.Add(wishListItem);
             await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsItemInWishListAsync(int userId, int unitId)
        {
            var wishListItem = await _context.WishList
                .FirstOrDefaultAsync(w => w.UserId == userId && w.UnitId == unitId);

            var result = wishListItem != null ? true : false;

            return result;
        }

        public async Task<IEnumerable<WishListItemDto>> GetUserWishListItemsAsync(int userId)
        {
            var item = await _context.WishList
                .Where(w => w.UserId == userId)
                .Include(w => w.Unit)
                   .ThenInclude(u => u.Location)
                .Include(w => w.Unit)
                   .ThenInclude(u => u.Category)
                .ToListAsync();

            var wishListItems = item.Select(w => new WishListItemDto
            {
                Id = w.Id,
                UnitId = w.UnitId,
                UnitTitle = w.Unit.Title,
                UnitSubtitle = w.Unit.SubTitle,
                Location = $"{w.Unit.Location.State}, {w.Unit.Location.Country}",
                Category = w.Unit.Category.Name
            });
            return wishListItems;
        }

        public async Task<bool> RemoveItemFromWishListAsync(int userId, int Id)
        {
            var item = await _context.WishList
                .FirstOrDefaultAsync(w => w.UserId == userId && w.Id == Id);

            if (item == null) return false;

            _context.WishList.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
