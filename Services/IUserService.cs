using System.Collections.Generic;
using WebAPI.Models;
namespace WebAPI.Services
{
    public interface IUserService
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        IEnumerable<TaskP> GetTasksByUserId(int userId);
    }
}