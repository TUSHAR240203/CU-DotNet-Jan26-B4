using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.DTOs;
using System.Net.Http.Json;

namespace NorthwindCatalog.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly HttpClient _client;

        public SummaryController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("NorthwindApi");
        }

        public async Task<IActionResult> Index()
        {
            var summary = await _client.GetFromJsonAsync<List<CategorySummaryDto>>("api/products/summary");

            if (summary == null)
            {
                summary = new List<CategorySummaryDto>();
            }

            return View(summary);
        }
    }
}