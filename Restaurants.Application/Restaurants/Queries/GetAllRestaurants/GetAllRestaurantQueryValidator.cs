using FluentValidation;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantQueryValidator : AbstractValidator<GetAllRestaurantQuery>
    {
        private string[] allowedSortBy = [
            nameof(RestaurantDto.Name),
            nameof(RestaurantDto.Description),
            nameof(RestaurantDto.Category)];

        public GetAllRestaurantQueryValidator(IValidator<PaginatedDto> paginatedDtoValidator)
        {
            // Validate paginatedDto using the nested validator
            RuleFor(r => r.paginatedDto)
                .NotNull().WithMessage("PaginatedDto is required.")
                .SetValidator(paginatedDtoValidator); // Use a separate validator for PaginatedDto

            // Validate SearchText: Optional, can be null or empty
            RuleFor(r => r.SearchText)
                .MaximumLength(100).WithMessage("SearchText cannot be longer than 100 characters.");

            RuleFor(r => r.paginatedDto.SortBy)
                .Must(v => allowedSortBy.Any(item => string.Equals(item, v, StringComparison.OrdinalIgnoreCase)))
                .When(r => r.paginatedDto != null && !string.IsNullOrEmpty(r.paginatedDto.SortBy))
                .WithMessage($"Sort by must be in [{string.Join(",", allowedSortBy)}]");
        }
    }
}
