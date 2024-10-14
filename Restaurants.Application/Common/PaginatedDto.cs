using Restaurants.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Common
{
    public class PaginatedDto
    {
        public int PageSize { get; set; } 
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public string SortDirection { get; set; } = "asc"!;
    }
}
