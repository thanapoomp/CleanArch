using FluentValidation;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(dto => dto.ContactEmail).EmailAddress().When(dto => !string.IsNullOrEmpty(dto.ContactEmail));
        }
    }
}
