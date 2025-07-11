using Homely_Web_Api.DTOs.WishListDtos;

namespace Homely_Web_Api.Services.Interfaces
{
    public interface IWishListService
    {
        Task<bool> AddItemToWishListAsync(int userId, int unitId);
        Task<bool> RemoveItemFromWishListAsync(int userId, int Id);
        Task<IEnumerable<WishListItemDto>> GetUserWishListItemsAsync(int userId);
        Task<bool> IsItemInWishListAsync(int userId, int unitId);
    }
}
