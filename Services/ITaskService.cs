// Services/ITaskService.cs
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITaskService
    {
        TaskP GetTaskById(int taskId);
        IEnumerable<TaskP> GetAllTasks();
        void AddTask(TaskP task);
        void UpdateTask(TaskP task);
        void DeleteTask(int taskId);
    }
}