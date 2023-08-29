using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Models;

namespace MyECommerceApp.Services;

public class CartService
{
    private readonly ApplicationDbContext _dbContext;

    public CartService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddToCart(int productId, int quantity)
    {
        var item = _dbContext.CartItems.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            _dbContext.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity });
        }
        _dbContext.SaveChanges();
    }

    public IEnumerable<CartItem> GetCartItems()
    {
        return _dbContext.CartItems.Include(c => c.Product).ToList();
    }


    public bool RemoveFromCart(int id)
    {
        var item = _dbContext.CartItems.Find(id);
        if (item != null)
        {
            _dbContext.CartItems.Remove(item);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public bool UpdateQuantity(int id, int newQuantity)
    {
        var item = _dbContext.CartItems.Find(id);
        if (item != null)
        {
            item.Quantity = newQuantity;
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }
}