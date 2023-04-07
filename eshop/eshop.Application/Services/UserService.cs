using eshop.Entities;

namespace eshop.Application.Services
{
    public class UserService : IUserService
    {

        private List<User> _users = new List<User>();
        public UserService()
        {
            _users.Add(new User { Id = 1, UserName = "turkay", Name = "türkay", Password = "123", Email = "abc@def.com", Role = "Admin" });
            _users.Add(new User { Id = 2, UserName = "aybike", Name = "Aybike", Password = "123", Email = "abc@def.com", Role = "Editor" });
            _users.Add(new User { Id = 3, UserName = "onur", Name = "Onur Mert", Password = "123", Email = "abc@def.com", Role = "Client" });

        }
        public User ValidateUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.UserName == username && u.Password == password);

        }
    }
}
