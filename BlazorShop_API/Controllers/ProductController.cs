using BlazorShop_Business.Repository.IRepository;
using BlazorShop_Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productRepository.GetAll());
    }
    
    [HttpGet("{productId}")]
    public async Task<IActionResult> Get(int? productId)
    {
        if (productId == null || productId == 0)
        {
            return BadRequest(new ErrorModelDTO()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                ErrorMessage = "Invalid ID"
            });
        }
        
        var product = await _productRepository.Get(productId.Value);
        if (product == null)
        {
            return BadRequest(new ErrorModelDTO()
            {
                StatusCode = StatusCodes.Status404NotFound,
                ErrorMessage = "Product not found!"
            });
        }

        return Ok(product);
    }
}