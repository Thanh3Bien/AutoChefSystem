using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Repositories.Entities;


namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string userName, string passWord);
        Task<CreateUserRequest> AddAsync(CreateUserRequest createUserRequest);

        Task<UpdateUserRequest> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task DeleteAsync(int id);
        Task<User?> GetByIdAsync(int id);
        Task<User> FindOrCreateUserAsync(string email);
        Task<(IEnumerable<User>, int)> GetAllAsync(int pageNumber, int pageSize);

    }
}
