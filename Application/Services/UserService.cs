using Application.IServices;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _currentTime = currentTime;
        }
        public async Task<User> AddUser(User user)
        {
            user.Password = user.Password.Hash();

            var userList = await _unitOfWork.UserRepository.GetAllAsync();

            // Check duplicate email
            if (userList.Any(x => x.Email.ToLower().Equals(user.Email.ToLower())))
                throw new Exception("Duplicate email!!!");
            

            await _unitOfWork.UserRepository.AddAsync(user);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return user;
            else throw new Exception("Add user failed!!!");
        }

        public async Task<User> GetUserById(int id)
        {
            if (id < 0) throw new Exception("ID can not be less than 0!!!");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            user.Password = "";
            return user;
        }

        public async Task<IQueryable<User>> GetUserList()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            if (users?.Count() == null)
            {
                throw new InvalidOperationException();
            }
            foreach (var user in users)
            {
                user.Password = "";
            }
            return users.AsQueryable();
        }

        public async Task<Tuple<string, User>> LoginAndGenerateToken(string email, string password)
        {
            var userList = await _unitOfWork.UserRepository.GetAllAsync();
            var existedUser = userList.FirstOrDefault(u => u.Email == email && u.Password == password.Hash());

            if (existedUser != null)
            {
                return new Tuple<string, User>(JWTHelpers.GenerateJWT(existedUser, _currentTime.GetCurrentTime(), _configuration), existedUser);
            }
            throw new Exception("Wrong Credential");
        }



        public async Task<User> UpdateUser(User user)
        {
            user.Password = user.Password.Hash();
            _unitOfWork.UserRepository.Update(user);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }


            return user;
        }
    }
}
