using team_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace team_project.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new();

        public TaskService()
        {
            // Initialize with some default tasks (optional)
        }

        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }

        public TaskItem GetTaskById(string id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void CreateTask(TaskItem newTask)
        {
            newTask.Id = Guid.NewGuid().ToString();
            _tasks.Add(newTask);
        }

        public void UpdateTask(TaskItem updatedTask)
        {
            var existingTask = GetTaskById(updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.Priority = updatedTask.Priority;
                existingTask.Deadline = updatedTask.Deadline;
                existingTask.Category = updatedTask.Category;
                existingTask.IsCompleted = updatedTask.IsCompleted;
            }
        }

        public void DeleteTask(string id)
        {
            var taskToDelete = GetTaskById(id);
            if (taskToDelete != null)
            {
                _tasks.Remove(taskToDelete);
            }
        }
    }
}