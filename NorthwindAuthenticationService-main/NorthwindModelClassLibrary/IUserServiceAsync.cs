using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModelClassLibrary
{
    public interface IUserServiceAsync
    {
        Task<UserModel> AuthenticateAsync(AuthenticationRequest model);
        Task<UserModel> GetUserDetails(int userId);
    }

    public class UserService : IUserServiceAsync
    {
        private readonly List<UserModel> _usersList = new List<UserModel>
        {
            new UserModel{UserId=1, FirstName="Rueben", LastName="Gupta", RoleName="Admin", Email="rueben.gupta@email.com",
            Username="admin", Password="admin"},
            new UserModel{UserId=1, FirstName="Sharan", LastName="Purohit", RoleName="Operator", Email="sharan.purohit@email.com", Username="operator", Password="operator"},
        };

        public Task<UserModel> AuthenticateAsync(AuthenticationRequest model)
        {
            var user = _usersList.FirstOrDefault(c => c.Username == model.Username && c.Password == model.Password);
            return Task.Run(() => user);
        }
        public Task<UserModel> GetUserDetails(int userId)
        {
            var user = _usersList.FirstOrDefault(c => c.UserId==userId);
            return Task.Run(() => user);
        }
    }
}
