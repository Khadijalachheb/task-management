namespace WebAPI.Repositories;
using  WebAPI.Models;
public class UserRepository : IUserRepository
{
    private readonly MyDbContext _dbContext;

    public UserRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetUserById(int userId)
    {
        return _dbContext.Users.Find(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = GetUserById(userId);
        if (user is not null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }

    public IEnumerable<TaskP> GetTasksByUserId(int userId)
    {
        var user = GetUserById(userId);
        if (user is not null)
        {
            return user.Tasks;
        }
        return Enumerable.Empty<TaskP>();
    }
}