﻿using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand,bool>
    {
        public async Task<bool>Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant id: {request.Id}");
            var restaurant = await restaurantsRepository.GetById(request.Id);
            if (restaurant == null)
            {
                return false;
            }

            await restaurantsRepository.Delete(restaurant);
            return true;
        }
    }
}
