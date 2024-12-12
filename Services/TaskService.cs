using team_project.Models;

namespace team_project.Services
{
    public class TaskService
    {
        private static List<TaskItem> _tasks = new List<TaskItem>();

        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }

        public TaskItem? GetTaskById(string id)
        {
            TaskItem task =  _tasks.Find(t => t.Id == id);
            if(task == null){
                return null;
            } 
            else {
                return task;
            }
        }
        
        public string CreateTask(string taskName, string description, string priority, DateTime dueDate, bool isCompleted)
        {
            var id = Guid.NewGuid().ToString();
            try
            {
                TaskItem task = new TaskItem
                {
                    Id = id,
                    TaskName = taskName,
                    Description = description,
                    Priority = priority,
                    DueDate = dueDate,
                    IsCompleted = isCompleted
                };
                _tasks.Add(task);  // Adding the task to the static list
                return "Success";  // Return success if everything works fine
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";  // Handle any exceptions and return an error message
            }
        }


        public void UpdateTask(TaskItem task)
        {
            var existingTask = GetTaskById(task.Id);
            if (existingTask != null)
            {
                // Find the task by matching its Id
                int index = _tasks.FindIndex(t => t.Id == task.Id);
                if (index != -1)
                {
                    _tasks[index] = task; 
                }
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

        public void CompleteTask(string id)
        {
            var task = GetTaskById(id);

            if (task != null)
            {
                task.IsCompleted = true;
                int index = _tasks.IndexOf(task);
                _tasks[index] = task;
            }
        }
    }
}