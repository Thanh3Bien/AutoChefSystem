using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Order
{
    public class GetAllOrderResponse
    {
        public int OrderId { get; set; }

        //public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!;

        public int LocationId { get; set; }

        public int RobotId { get; set; }

        public DateTime OrderedTime { get; set; }

        public DateTime? CompletedTime { get; set; }

        public string Status { get; set; } = null!;
    }
}
