using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Command.CreatedDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
        IRestaurantsRepository restaurantRepository,
        IDishesRepository dishRepository,
        IMapper mapper) : IRequestHandler<CreateDishCommand>
    {
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish : {@request}", request);
            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dishToCreate = mapper.Map<Dish>(request);
            await dishRepository.CreateAsync(dishToCreate);       
        }
    }
}
