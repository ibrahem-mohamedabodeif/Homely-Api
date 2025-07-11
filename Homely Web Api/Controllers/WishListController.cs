using Homely_Web_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homely_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishListController(IWishListService service) : ControllerBase
    {
        private readonly IWishListService _service = service;

        [HttpPost("{unitId}")]
        public async Task<IActionResult> AddItemToWishList(int unitId)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _service.AddItemToWishListAsync(userId, unitId);
                if (result)
                {
                    return Ok(new { message = "Item added to wish list successfully" });
                }
                return BadRequest(new { message = "Item already exists in wish list" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveItemFromWishList(int Id)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _service.RemoveItemFromWishListAsync(userId, Id);
                if (result)
                {
                    return Ok(new { message = "Item removed from wish list successfully" });
                }
                return NotFound(new { message = "Item not found in wish list" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWishListItems()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var wishListItems = await _service.GetUserWishListItemsAsync(userId);
                return Ok(wishListItems);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
