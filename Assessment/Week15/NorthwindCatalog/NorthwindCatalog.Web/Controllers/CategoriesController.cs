using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.DTOs;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _client;

        public CategoriesController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("NorthwindApi");
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories");

            if (categories == null)
            {
                categories = new List<CategoryDto>();
            }

            return View(categories);
        }
    }
}