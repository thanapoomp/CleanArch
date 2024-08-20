using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
    {
        public async Task<int> CreateAsync(Dish entity)
        {
            dbContext.Dishes.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Dish>> GetAllForRestaurantAsync(int restaurantId)
        {
            var dishes = await dbContext.Dishes.Where(x => x.RestaurantId == restaurantId).ToListAsync();
            return dishes;
        }

        public async Task<Dish?> GetByIdForRestaurnatAsync(int restaurantId, int dishId)
        {
            var dish = await dbContext.Dishes.Where(x => x.Id == dishId && x.RestaurantId == restaurantId).FirstOrDefaultAsync();
            return dish;
        }

        public async Task DeleteAsync(Dish dish)
        {
            dbContext.Dishes.Remove(dish);
            await dbContext.SaveChangesAsync();
        }
    }
}
