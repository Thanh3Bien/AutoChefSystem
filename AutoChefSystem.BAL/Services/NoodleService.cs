using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Models.Noodle;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.BAL.Services
{
	public class NoodleService : INoodleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public NoodleService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Noodle?> GetByIdAsync(int id) => await _unitOfWork.Noodles.GetByIdAsync(id);

		public async Task<CreateNoodleRequest> AddAsync(CreateNoodleRequest createNoodleRequest)
		{
			var noodle = new Noodle()
			{
				NoodlesName = createNoodleRequest.NoodlesName,
				IsActive = true
			};

			_unitOfWork.Noodles.AddEntity(noodle);
			await _unitOfWork.CompleteAsync();
			return createNoodleRequest;
		}

		public async Task<UpdateNoodleRequest> UpdateAsync(UpdateNoodleRequest updateNoodleRequest)
		{
			var noodle = await _unitOfWork.Noodles.GetByIdAsync(updateNoodleRequest.NoodlesId);
			if (noodle != null)
			{
				noodle.NoodlesName = updateNoodleRequest.NoodlesName;
				_unitOfWork.Noodles.UpdateEntity(noodle);
				await _unitOfWork.CompleteAsync();
				return updateNoodleRequest;
			}
			else
			{
				throw new Exception("Noodle not found");
			}
		}

		public async Task DeleteAsync(int id)
		{
			var noodle = await _unitOfWork.Noodles.GetByIdAsync(id);
			if (noodle != null)
			{
				noodle.IsActive = false;
				_unitOfWork.Noodles.UpdateEntity(noodle);
				await _unitOfWork.CompleteAsync();
			}
			else
			{
				throw new Exception("Noodle not found");
			}
		}
	}
}
