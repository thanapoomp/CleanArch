using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System.Linq.Dynamic.Core;

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

        public async Task<(IEnumerable<Restaurant>,int)> GetAllMatchingAsync(string? searchText, 
            int pageSize, 
            int pageNumber, 
            string? sortBy, 
            string? sortDirection)
        {
            var searchTextLower = searchText?.ToLower();

            //query
            var baseQuery = dbContext.Restaurants
                .Where(x => searchTextLower == null || (x.Description.ToLower().Contains(searchTextLower)
                                                        || x.Name.ToLower().Contains(searchTextLower)))
                .Include(x => x.Dishes).AsQueryable();

            var totalCount = await baseQuery.CountAsync();

            //sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                baseQuery = baseQuery.OrderBy(sortBy + " " + sortDirection);
             };

            var restaurants = await baseQuery
                .Skip(pageSize * (pageNumber -1))
                .Take(pageSize)
                .ToListAsync();

            return (restaurants,totalCount);
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
