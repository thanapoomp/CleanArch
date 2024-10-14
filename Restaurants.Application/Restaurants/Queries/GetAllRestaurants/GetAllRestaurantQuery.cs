using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantQuery : IRequest<PaginatedResult<RestaurantDto>>
    {
        public string? SearchText { get; set; }

        public required PaginatedDto paginatedDto { get; set; }
    }
}
