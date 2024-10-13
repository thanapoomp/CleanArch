using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchText,int pageSize, int pageNumber);
        Task<Restaurant?> GetByIdAsync(int id);
        Task<int> CreateAsync(Restaurant entity);
        Task DeleteAsync(Restaurant restaurant);
        Task SaveChangesAsync();
    }
}
