
using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(dto => dto.ContactEmail).EmailAddress().When(dto => !string.IsNullOrEmpty(dto.ContactEmail));
        }
    }
}
