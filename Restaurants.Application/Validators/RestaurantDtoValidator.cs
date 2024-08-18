
using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Validators
{
    public class RestaurantDtoValidator : AbstractValidator<RestaurantDtoToCreate>
    {
        public RestaurantDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(dto => dto.ContactEmail).EmailAddress().When(dto => !string.IsNullOrEmpty(dto.ContactEmail));
        }
    }
}
