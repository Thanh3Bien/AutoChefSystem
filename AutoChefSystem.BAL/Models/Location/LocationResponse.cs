using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Location
{
    public class LocationResponse
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
