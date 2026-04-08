using TaskTracker;
using TaskTracker.Models;

/*Console.WriteLine("Welcome to Task Tracker!");

Console.WriteLine("Please input your command: ");
TaskService.ShowCommands();
*/

switch (args[0])
{
    case "add":
        TaskService.AddTask(args[1]);
        break;
    case "update":
        TaskService.UpdateTask(int.Parse(args[1]), args[2]);
        break;
    case "delete":
        TaskService.DeleteTask(int.Parse(args[1]));
        break;
    case "mark-in-progress":
        TaskService.UpdateTask(int.Parse(args[1]), Status.in_progress);
        break;
    case "mark-done":
        TaskService.UpdateTask(int.Parse(args[1]), Status.done);
        break;
    case "list":
        if (args.Length == 1)
        {
            TaskService.PrintAllTasks();
            break;
        }
        switch (args[1].ToLower())
        {
            case "todo":
                TaskService.PrintTaksByStatus(Status.todo);
                break;
            case "in-progress":
                TaskService.PrintTaksByStatus(Status.in_progress);
                break;
            case "done":
                TaskService.PrintTaksByStatus(Status.done);
                break;
            default:
                Console.WriteLine("Unknown status. Use: todo, in-progress, done");
                break;
        }
        break;
    case "-help":
        TaskService.ShowCommands();
        break;
    default:
        Console.WriteLine("Unknown command, type: -help");
        break;
}

