namespace WebAPI.Repositories;
using  WebAPI.Models;
public class TaskRepository : ITaskRepository
{
    private readonly MyDbContext _dbContext;

    public TaskRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TaskP? GetTaskById(int taskId)
    {
        return _dbContext.Tasks.Find(taskId);
    }

    public IEnumerable<TaskP> GetAllTasks()
    {
        return _dbContext.Tasks.ToList();
    }

    public void AddTask(TaskP task)
    {
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChanges();
    }

    public void UpdateTask(TaskP task)
    {
        _dbContext.Tasks.Update(task);
        _dbContext.SaveChanges();
    }

    public void DeleteTask(int taskId)
    {
        var task = GetTaskById(taskId);
        if (task is not null)
        {
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }
    }
}