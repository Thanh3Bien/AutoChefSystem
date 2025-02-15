using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Models.Broths;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Services
{
	public class BrothService : IBrothService
	{
		private readonly IUnitOfWork _unitOfWork;

		public BrothService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Broth?> GetByIdAsync(int id) => await _unitOfWork.Broths.GetByIdAsync(id);

		public async Task<CreateBrothRequest> AddAsync(CreateBrothRequest createBrothRequest)
		{
			var broth = new Broth()
			{
				BrothsName = createBrothRequest.BrothsName,
				IsActive = true
			};

			_unitOfWork.Broths.AddEntity(broth);
			await _unitOfWork.CompleteAsync();
			return createBrothRequest;
		}

		public async Task<UpdateBrothRequest> UpdateAsync(UpdateBrothRequest updateBrothRequest)
		{
			var broth = await _unitOfWork.Broths.GetByIdAsync(updateBrothRequest.BrothsId);
			if (broth != null)
			{
				broth.BrothsName = updateBrothRequest.BrothsName;
				_unitOfWork.Broths.UpdateEntity(broth);
				await _unitOfWork.CompleteAsync();
				return updateBrothRequest;
			}
			else
			{
				throw new Exception("Broth not found");
			}
		}

		public async Task DeleteAsync(int id)
		{
			var broth = await _unitOfWork.Broths.GetByIdAsync(id);
			if (broth != null)
			{
				broth.IsActive = false;
				_unitOfWork.Broths.UpdateEntity(broth);
				await _unitOfWork.CompleteAsync();
			}
			else
			{
				throw new Exception("Broth not found");
			}
		}
	}
}