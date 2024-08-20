using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IDishesRepository
    {
        Task<int> CreateAsync(Dish entity);
        Task<IEnumerable<Dish>> GetAllForRestaurantAsync(int restaurantId);
        Task<Dish?> GetByIdForRestaurnatAsync(int restaurantId, int dishId);
        Task DeleteAsync(Dish dish);
    }
}
