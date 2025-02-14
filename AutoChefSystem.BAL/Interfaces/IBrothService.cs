using AutoChefSystem.BAL.Models.Broths;
using AutoChefSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Interfaces
{
	public interface IBrothService
	{
		Task<Broth?> GetByIdAsync(int id);
		Task<CreateBrothRequest> AddAsync(CreateBrothRequest createBrothRequest);
		Task<UpdateBrothRequest> UpdateAsync(UpdateBrothRequest updateBrothRequest);
		Task DeleteAsync(int id);
	}
}
