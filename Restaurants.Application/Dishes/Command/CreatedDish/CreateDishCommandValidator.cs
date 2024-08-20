using FluentValidation;

namespace Restaurants.Application.Dishes.Command.CreatedDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Price).GreaterThanOrEqualTo(1);
            RuleFor(dish => dish.Name).MinimumLength(1).MaximumLength(200)  ;
            RuleFor(dish => dish.Description).MinimumLength(1).MaximumLength(200) ;
        }
    }
}
