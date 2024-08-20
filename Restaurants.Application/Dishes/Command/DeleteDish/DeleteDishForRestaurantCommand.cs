using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Command.DeleteDish
{
    public class DeleteDishForRestaurantCommand(int restaurantId, int dishId) : IRequest
    {
        public int RestaurantId { get; set; } = restaurantId;
        public int DishId { get; set; } = dishId;
    }
}
