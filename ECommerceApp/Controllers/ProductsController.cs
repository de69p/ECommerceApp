using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    private readonly ILogger<CartController> _logger;

    public ProductController(ProductService productService, ILogger<CartController> logger)
    {
        _logger = logger;
        _productService = productService;
    }

    // Create
    [HttpPost]
    public ActionResult AddProduct(Product product)
    {
        _productService.AddProduct(product);
        return Ok();
    }

    // Read
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts(string? type = null)
    {
        return Ok(_productService.GetProducts(type));
    }

    // Read Single
    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        return Ok(product);
    }

    // Update
    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        if (_productService.UpdateProduct(id, updatedProduct))
        {
            return Ok();
        }

        return NotFound();
    }

    // Delete
    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        if (_productService.DeleteProduct(id))
        {
            return Ok();
        }

        return NotFound();
    }
}