using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantQueryHandler (ILogger<GetAllRestaurantQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository): IRequestHandler<GetAllRestaurantQuery, PageResult<RestaurantDto>>
    {
        public async Task<PageResult<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");
            var (restaurants,totalCount) = await restaurantsRepository.GetAllMatchingAsync(request.SearchText, request.PageSize, request.PageNumber);
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            var result = new PageResult<RestaurantDto>(restaurantsDto, totalCount,request.PageSize, request.PageNumber);

            return result;
        }


    }
}
