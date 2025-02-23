using AutoChefSystem.Services.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Recipe
{
    public class PaginatedOrderResponse
    {
        public List<GetAllOrderResponse> Orders { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

}
