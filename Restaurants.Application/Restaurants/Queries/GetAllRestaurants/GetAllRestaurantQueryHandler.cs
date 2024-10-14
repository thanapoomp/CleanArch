using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantQueryHandler(ILogger<GetAllRestaurantQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantQuery, PaginatedResult<RestaurantDto>>
    {
        public async Task<PaginatedResult<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");
            var (restaurants, totalCount) = await restaurantsRepository.GetAllMatchingAsync(
                request.SearchText, 
                request.paginatedDto.PageSize, 
                request.paginatedDto.PageNumber, 
                request.paginatedDto.SortBy, 
                request.paginatedDto.SortDirection);
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            var result = new PaginatedResult<RestaurantDto>(restaurantsDto, totalCount, request.paginatedDto.PageSize, request.paginatedDto.PageNumber);

            return result;
        }


    }
}
