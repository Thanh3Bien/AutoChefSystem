using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.DAL.Entities;

namespace AutoChefSystem.BAL.Interfaces
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string userName, string passWord);
        Task<CreateUserRequest> AddAsync(CreateUserRequest createUserRequest);

        Task<UpdateUserRequest> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task DeleteAsync(int id);
        Task<User?> GetByIdAsync(int id);

    }
}
