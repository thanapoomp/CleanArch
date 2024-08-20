using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Command.DeleteDish
{
    public class DeleteDishForRestaurantCommandHandler(ILogger<DeleteDishForRestaurantCommandHandler> logger,
        IDishesRepository dishesRepository) : IRequestHandler<DeleteDishForRestaurantCommand>
    {
        public async Task Handle(DeleteDishForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting dish for restaurantId: {restaurantId} dishId: {dishId}", request.RestaurantId, request.DishId);
            var dishToDelete = await dishesRepository.GetByIdForRestaurnatAsync(request.RestaurantId,request.DishId);
            if (dishToDelete == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            await dishesRepository.DeleteAsync(dishToDelete);
        }
    }
}
