using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.DTOs;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;

        public ProductsController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("NorthwindApi");
        }

        public async Task<IActionResult> ByCategory(int id)
        {
            var products = await _client.GetFromJsonAsync<List<ProductDto>>($"api/products/by-category/{id}");

            if (products == null)
            {
                products = new List<ProductDto>();
            }

            ViewBag.CategoryId = id;
            return View(products);
        }
    }
}