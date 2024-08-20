using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(IMapper mapper, 
        ILogger<GetDishByIdForRestaurantQueryHandler> logger, 
        IDishesRepository dishesRepository) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting dishByIdforrestaurantId: {restaurantId} , dishId: {dishId}",request.RestaurantId,request.DishId);
            var dish = await dishesRepository.GetByIdForRestaurnatAsync(request.RestaurantId,request.DishId);
            if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            var dishDto = mapper.Map<DishDto>(dish);
            return dishDto;
        }
    }
}
