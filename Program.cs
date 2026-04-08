using TaskTracker;
using TaskTracker.Models;

Console.WriteLine("Welcome to Task Tracker!");

Console.WriteLine("Please input your command: ");
TaskService.ShowCommands();

var command = args[0];

switch (command)
{
    case "add":
        TaskService.AddTask(args[1]);
        break;
    case "update":

        break;
    case "delete":

        break;
    case "mark-in-progress":

        break;
    case "mark-done":

        break;
    case "list":
        switch (args[1])
        {
            case nameof(Status.todo):

                break;
            case nameof(Status.in_progress):

                break;
            case nameof(Status.done):

                break;
        }
        break;

    case "Exit":

        break;
    case "-help":
        TaskService.ShowCommands();
        break;
    default:
        Console.WriteLine("Unknown command, type: -help");
        break;
}

