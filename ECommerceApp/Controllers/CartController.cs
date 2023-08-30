using Microsoft.AspNetCore.Mvc;
using MyECommerceApp.Models;
using MyECommerceApp.Services;

namespace ECommerceApp.Controllers;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    private readonly ILogger<CartController> _logger;

    public CartController(CartService cartService, ILogger<CartController> logger)
    {
        _cartService = cartService;
        _logger = logger;
    }


    // Create (Add to Cart)
    [HttpPost]
    public ActionResult AddToCart(CartItem item)
    {
        try
        {
            _cartService.AddToCart(item.ProductId, item.Quantity);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding to cart");
            return BadRequest();
        }
    }


    // Read (Get Cart Items)
    [HttpGet]
    public ActionResult<IEnumerable<CartItem>> GetCartItems()
    {
        return Ok(_cartService.GetCartItems());
    }

    // Update (Update Quantity)
    [HttpPut("{id}")]
    public ActionResult UpdateQuantity(int id, [FromBody] UpdateQuantityModel model)
    {
        if (_cartService.UpdateQuantity(id, model.NewQuantity))
        {
            return Ok();
        }
        return NotFound();
    }

    // Delete (Remove from Cart)
    [HttpDelete("{id}")]
    public ActionResult RemoveFromCart(int id)
    {
        if (_cartService.RemoveFromCart(id))
        {
            return Ok();
        }
        return NotFound();
    }

    public class UpdateQuantityModel
    {
        public int NewQuantity { get; set; }
    }
}
