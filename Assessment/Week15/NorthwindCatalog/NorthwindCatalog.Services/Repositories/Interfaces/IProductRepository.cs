using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}