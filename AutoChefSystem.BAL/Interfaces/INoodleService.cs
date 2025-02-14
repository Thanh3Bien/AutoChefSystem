using AutoChefSystem.BAL.Models.Noodle;
using AutoChefSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Interfaces
{
	public interface INoodleService
	{
		Task<Noodle?> GetByIdAsync(int id);
		Task<CreateNoodleRequest> AddAsync(CreateNoodleRequest createNoodleRequest);
		Task<UpdateNoodleRequest> UpdateAsync(UpdateNoodleRequest updateNoodleRequest);
		Task DeleteAsync(int id);
	}
}
