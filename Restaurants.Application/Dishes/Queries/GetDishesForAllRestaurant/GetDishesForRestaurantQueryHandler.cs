using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesForAllRestaurant
{
    public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> logger, 
        IDishesRepository dishesRepository, 
        IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting dishes for restaurantId: {restaurantId}", request.RestaurantId);
            var dish = await dishesRepository.GetAllForRestaurantAsync(request.RestaurantId);
            var dishesDto = mapper.Map<IEnumerable<DishDto>>(dish);
            return dishesDto;
        }
    }
}
