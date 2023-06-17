using WebApiSecurity.Models;

namespace WebApiSecurity;

public class AppRepository
{
    public List<User> Users => new()
    {
        new User { Id=1,Name="John",Email="John@email.com",BaseSalary=64000},
        new User { Id=2,Name="Smith",Email="Smith@email.com",BaseSalary=50000},
        new User { Id=3,Name="Pattrick",Email="patty@email.com",BaseSalary=45000}
    };

    public User GetUser(int id)
    {
        var user = Users.Where(x=>x.Id == id).FirstOrDefault();
        return user!;
    }
}
