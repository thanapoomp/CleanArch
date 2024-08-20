using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Command.CreatedDish;
using Restaurants.Application.Dishes.Command.DeleteDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishesForAllRestaurant;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/dishes")]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            var dishId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId,dishId }, null);
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute]int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dishes = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId,dishId));
            return Ok(dishes);
        }

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            await mediator.Send(new DeleteDishForRestaurantCommand(restaurantId,dishId));
            return NoContent();
        }
    }
}
