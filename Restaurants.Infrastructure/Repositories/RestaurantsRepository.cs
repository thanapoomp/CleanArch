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
    internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
    {
        public async Task<int> CreateAsync(Restaurant entity)
        {
            dbContext.Restaurants.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            dbContext.Remove(restaurant);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.Include(x=>x.Dishes).ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants.Include(x => x.Dishes).Where(x => x.Id == id).FirstOrDefaultAsync();
            return restaurant;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
