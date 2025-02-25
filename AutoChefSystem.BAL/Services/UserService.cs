using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;

namespace AutoChefSystem.Repositories.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User?> LoginAsync(string userName, string passWord)
            => await _unitOfWork.Users.LoginAsync(userName, passWord);

        public async Task<CreateUserRequest> AddAsync(CreateUserRequest createUserRequest)
        {
            var user = new User()
            {
                UserName = createUserRequest.UserName,
                Password = createUserRequest.Password,
                RoleId = createUserRequest.RoleId,
                IsActive = true,
            };
            _unitOfWork.Users.AddEntity(user);
            await _unitOfWork.CompleteAsync();
            return createUserRequest;
        }


        public async Task<UpdateUserRequest> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(updateUserRequest.UserId);
            if(user != null)
            {
                user.UserName = updateUserRequest.UserName;
                user.Password = updateUserRequest.Password;
                user.RoleId = updateUserRequest.RoleId;
                _unitOfWork.Users.UpdateEntity(user);
                await _unitOfWork.CompleteAsync();
                return updateUserRequest;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if(user != null)
            {
                user.IsActive = false;
                _unitOfWork.Users.UpdateEntity(user);
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<User?> GetByIdAsync(int id) => await _unitOfWork.Users.GetByIdAsync(id);
    }
}
