using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<IQueryable<User>> GetUserList();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
        Task<Tuple<string, User>> LoginAndGenerateToken(string email, string rawPassword);
    }
}
