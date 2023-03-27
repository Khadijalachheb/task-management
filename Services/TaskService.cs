using System.Collections.Generic;
using  WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskP GetTaskById(int taskId)
        {
            return _taskRepository.GetTaskById(taskId);
        }

        public IEnumerable<TaskP> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public void AddTask(TaskP task)
        {
            _taskRepository.AddTask(task);
        }

        public void UpdateTask(TaskP task)
        {
            _taskRepository.UpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            _taskRepository.DeleteTask(taskId);
        }
    }
}