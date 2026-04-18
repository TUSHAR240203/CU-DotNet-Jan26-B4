using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Repositories.Interfaces;

namespace NorthwindCatalog.Services.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductsApiController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _repo.GetByCategoryIdAsync(categoryId);
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(result);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var data = await _repo.GetCategorySummariesAsync();
            return Ok(data);
        }
    }
}