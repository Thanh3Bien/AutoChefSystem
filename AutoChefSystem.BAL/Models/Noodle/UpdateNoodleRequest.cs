﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Models.Noodle
{
	public class UpdateNoodleRequest
	{
		public int NoodlesId { get; set; }
		public string NoodlesName { get; set; } = null!;
	}
}
