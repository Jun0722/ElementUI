using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using API.Data.IRepository;
using API.Models;
using Dapper;

namespace API.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        public async Task<bool> AddAsync(User entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"insert into user(name,password,email,telno,createDateTime) values(@Name,@Password,@Email,@TelNo,@CreateDateTime)";
                return await conn.ExecuteAsync(sql, entity) > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"delete from user where id=@Id";
                return await conn.ExecuteAsync(sql, new { Id = id })>0;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                return await conn.QueryAsync<User>(@"select * from user");
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"select * from user where Id=@id";
                return await conn.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
            }
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            using (IDbConnection conn = DbConfig.GetSqlConnection())
            {
                string sql = @"update user set name=@Name,password=@Password,email=@Email,telno=@TelNo,createdatetime=@CreateDateTime where id=@Id";
                return await conn.ExecuteAsync(sql, entity) > 0;
            }
        }
    }
}
