using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Models.Broths
{
	public class UpdateBrothRequest
	{
		public int BrothsId { get; set; }
		public string BrothsName { get; set; } = null!;
	}
}
