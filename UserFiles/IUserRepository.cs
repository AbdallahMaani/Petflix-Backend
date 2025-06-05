using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.UserFiles;

namespace FullPetflix.UserFiles
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> Search(string name, Gender? gender);
        Task<Users> GetUser(int UserId);
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserByEmail(string Email);
        Task<Users> GetUserByUsername(string Username);
        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task DeleteUser(int UserId);
        Task<Users> UpdateUserPassword(int userId, string oldPassword, string newPassword); // New method

    }
}