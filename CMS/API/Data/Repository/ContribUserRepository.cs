using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using API.Data.IRepository;
using API.Models;
using Dapper.Contrib.Extensions;

namespace API.Data.Repository
{
    public class ContribUserRepository:IUserRepository
    {
        public async Task<bool> AddAsync(User entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.InsertAsync(entity) > 0;
            }
        }
    
        public async Task<bool> DeleteAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                var entity = await conn.GetAsync<User>(id);
                return await conn.DeleteAsync(entity);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.GetAllAsync<User>();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.GetAsync<User>(id);
            }
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.UpdateAsync(entity);
            }
        }
    }
}
