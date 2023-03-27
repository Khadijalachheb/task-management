namespace WebAPI.Repositories;
using  WebAPI.Models;
public interface ITaskRepository
{
    TaskP GetTaskById(int taskId);
    IEnumerable<TaskP> GetAllTasks();
    void AddTask(TaskP task);
    void UpdateTask(TaskP task);
    void DeleteTask(int taskId);
}