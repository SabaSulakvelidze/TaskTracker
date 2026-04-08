using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskTracker.Models;

namespace TaskTracker
{
    public class TaskService
    {
        public static readonly string tasksFilePath = Path.Combine(Directory.GetCurrentDirectory(), "tasks.json");

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public static void ShowCommands()
        {
            string commands =
                """
                    add "description"
                    update <id> "new description"
                    delete <id>
                    mark-in-progress <id>
                    mark-done <id>
                    list
                    list done
                    list todo
                    list in_progress
                    exit
                """;
            Console.WriteLine(commands);

        }

        public static void InitializeTasksFile()
        {
            if (!File.Exists(tasksFilePath))
                File.WriteAllText(tasksFilePath, "[]");
        }

        public static List<TaskModel> GetAllTasks()
        {
            InitializeTasksFile();

            var json = File.ReadAllText(tasksFilePath);

            var tasks = JsonSerializer.Deserialize<List<TaskModel>>(json, JsonOptions);

            return tasks ?? [];
        }

        public static void SaveTasks(List<TaskModel> tasks)
        {
            InitializeTasksFile();

            var json = JsonSerializer.Serialize(tasks, JsonOptions);

            File.WriteAllText(tasksFilePath, json);
        }

        public static void AddTask(string description)
        {
            var tasks = GetAllTasks();

            int newId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

            TaskModel newTask = new()
            {
                Id = newId,
                Description = description,
                Status = Status.todo,
                CreatedAt = DateTime.Now
            };

            tasks.Add(newTask);
            SaveTasks(tasks);
            Console.WriteLine($"New task with Id {newTask.Id} added successfully");
        }

        public static void DeleteTask(int id)
        {
            var tasks = GetAllTasks();

            tasks.RemoveAll(t => t.Id == id);

            SaveTasks(tasks);
            Console.WriteLine($"Task with Id {id} deleted successfully");
        }

        public static void UpdateTask(int id, string newDescription)
        {
            var tasks = GetAllTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task not found");
                return;
            }
            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;

            SaveTasks(tasks);
            Console.WriteLine($"Task with Id {id} updated successfully");
        }

        public static void UpdateTask(int id, Status newStatus)
        {
            var tasks = GetAllTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task not found");
                return;
            }
            task.Status = newStatus;
            task.UpdatedAt = DateTime.Now;

            SaveTasks(tasks);
            Console.WriteLine($"Task with Id {id} updated successfully");
        }

        public static void PrintAllTasks()
        {
            foreach (var item in GetAllTasks())
            {
                Console.WriteLine(JsonSerializer.Serialize(item, JsonOptions));
            }
        }

        public static void PrintTaksByStatus(Status status)
        {
            var tasks = GetAllTasks();

            foreach (var item in tasks.FindAll(t => t.Status == status))
            {
                Console.WriteLine(JsonSerializer.Serialize(item, JsonOptions));
            }
        }
    }
}
