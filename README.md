# TaskTracker
## Usage

Run the project from the command line with `dotnet run --` followed by a command and its arguments.

### Available commands

```bash
dotnet run -- add "description"
dotnet run -- update <id> "new description"
dotnet run -- delete <id>
dotnet run -- mark-in-progress <id>
dotnet run -- mark-done <id>
dotnet run -- list
dotnet run -- list todo
dotnet run -- list in-progress
dotnet run -- list done
dotnet run -- -help
```

### Examples

Add a new task:

```bash
dotnet run -- add "Buy groceries"
```

Update a task description:

```bash
dotnet run -- update 1 "Buy groceries and cook dinner"
```

Delete a task:

```bash
dotnet run -- delete 1
```

Mark a task as in progress:

```bash
dotnet run -- mark-in-progress 1
```

Mark a task as done:

```bash
dotnet run -- mark-done 1
```

List all tasks:

```bash
dotnet run -- list
```

List only tasks with `todo` status:

```bash
dotnet run -- list todo
```

List only tasks with `in-progress` status:

```bash
dotnet run -- list in-progress
```

List only tasks with `done` status:

```bash
dotnet run -- list done
```

Show help:

```bash
dotnet run -- -help
```

### Notes

- Tasks are stored in a `tasks.json` file.
- If `tasks.json` does not exist, it is created automatically.
- Supported task statuses are:
  - `todo`
  - `in-progress`
  - `done`

### Task JSON format

Each task is stored with the following fields:

- `Id`
- `Description`
- `Status`
- `CreatedAt`
- `UpdatedAt`
