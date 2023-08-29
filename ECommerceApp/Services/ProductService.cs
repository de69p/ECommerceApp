using MyECommerceApp.Models;

namespace MyECommerceApp.Services;

public class ProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Create
    public void AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    // Read
    public IEnumerable<Product> GetProducts()
    {
        return _dbContext.Products.ToList();
    }

    // Read Single
    public Product GetProductById(int id)
    {
        return _dbContext.Products.Find(id);
    }

    // Update
    public bool UpdateProduct(int id, Product updatedProduct)
    {
        var existingProduct = _dbContext.Products.Find(id);
        if (existingProduct != null)
        {
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Description = updatedProduct.Description;
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }

    // Delete
    public bool DeleteProduct(int id)
    {
        var product = _dbContext.Products.Find(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }
}