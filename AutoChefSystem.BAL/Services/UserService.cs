﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using AutoChefSystem.Services.Models.Users;

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
                Image = createUserRequest.UserImage,
                UserFullName = createUserRequest.UserFullName,
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
                user.Image = updateUserRequest.UserImage;
                user.UserFullName = updateUserRequest.UserFullName;
                user.IsActive = updateUserRequest.IsActive;
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

        public async Task<User> FindOrCreateUserAsync(string email)
        {
            var user = await _unitOfWork.Users.GetUserByFirebaseIdAsync(email);

            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Password = "1",
                    RoleId = 4,
                    IsActive = true,
                };
                _unitOfWork.Users.AddEntity(user);
                await _unitOfWork.CompleteAsync();
            }

            return user;
        }

        public async Task<(IEnumerable<UserResponse>, int)> GetAllAsync(int pageNumber, int pageSize)
        {
            var (users, totalRecords) = await _unitOfWork.Users.GetAllAsync(pageNumber, pageSize);

            var userDtos = users.Select(user => new UserResponse
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                RoleId = user.RoleId,
                IsActive = user.IsActive,
                UserFullName = user.UserFullName,
                Image = user.Image,
                RoleName = user.Role?.RoleName ?? "Unknown"
            });

            return (userDtos, totalRecords);
        }
    }
}
