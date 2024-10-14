using Restaurants.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Common
{
    public class PaginatedResult<T>
    {
        public int PageSize { get; set; }
        public PaginatedResult(IEnumerable<T> items, int totalCount,int pageSize,int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            PageSize = pageSize;
            if (Items.Count() > 0)
            {
                ItemsFrom = pageSize * (pageNumber - 1) + 1;
                ItemsTo = ItemsFrom + pageSize - 1;
                ItemsTo = (ItemsTo > TotalItemsCount) ? TotalItemsCount : ItemsTo;
                PageNumber = pageNumber;
                PageIndex = pageNumber - 1;
            }
        }
        public IEnumerable<T>  Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int PageNumber { get; set; }
        public int PageIndex { get; set; }
    }
}
