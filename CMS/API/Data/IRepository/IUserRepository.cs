using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data.IRepository
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User entity);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(User entity);
    }
}
