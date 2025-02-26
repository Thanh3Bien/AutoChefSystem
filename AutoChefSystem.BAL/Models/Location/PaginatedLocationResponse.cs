using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Location
{
    public class PaginatedLocationResponse
    {
        public List<LocationResponse> Locations { get; set; } = new();
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
