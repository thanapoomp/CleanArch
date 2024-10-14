using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Common
{
    public class PaginatedDtoValidator : AbstractValidator<PaginatedDto>
    {

        private readonly string[] _sortDirectionList = ["asc", "desc"];
        public PaginatedDtoValidator()
        {
            // Rule for PageSize: Must be between than 1-100
            RuleFor(r => r.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("PageSize must between 1-100.");

            // Rule for PageNumber: Must be greater than or equal to 1
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber must be at least 1.");

            // Sort direction
            RuleFor(r => r.SortDirection)
                .Must(v => _sortDirectionList.Any(item => string.Equals(item,v,StringComparison.OrdinalIgnoreCase)))
                .When(v => !string.IsNullOrEmpty(v.SortBy))
                .WithMessage("Valid sort direction is asc or desc");

        }
    }
}
