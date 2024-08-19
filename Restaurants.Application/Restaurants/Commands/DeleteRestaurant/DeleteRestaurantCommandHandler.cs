using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant id: {RestaurantId}",request.Id);
            var restaurant = await restaurantsRepository.GetById(request.Id);
            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant",request.Id.ToString());
            }

            await restaurantsRepository.Delete(restaurant);
        }
    }
}
