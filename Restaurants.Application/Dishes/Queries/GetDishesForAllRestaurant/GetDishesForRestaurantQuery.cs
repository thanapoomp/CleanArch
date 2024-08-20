using MediatR;
using Restaurants.Application.Dishes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishesForAllRestaurant
{
    public class GetDishesForRestaurantQuery(int id) : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; set; } = id;
    }
}
