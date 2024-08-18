﻿
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public List<DishDto> Dishes { get; set; } = new();

    }
}
