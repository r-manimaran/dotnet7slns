using ObjectMappings.Models;

namespace ObjectMappings.Services
{

    public class UserService : IUserService
    {
        public User GetUser()
        {
            User newUser = new User()
            {
                FirstName="Alex",
                LastName="Ben",
                Email="mail@email.com",
                Department="Computers"
            };
            return newUser;
        }
    }
}
