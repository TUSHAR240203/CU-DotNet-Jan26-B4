using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}