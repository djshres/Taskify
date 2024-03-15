**Task Manager Application**

Welcome to Task Manager - your solution for efficient task management. Task Manager allows you to perform CRUD operations for your day-to-day tasks, including creating, reading, updating, and deleting tasks with ease. Each task includes essential details such as title, description, due date, and priority.

### Live Application

You can access the live application of Task Manager by visiting [sdfdsf.com](https://sdfdsf.com).

### Running Locally

To run Task Manager locally, follow these simple steps:

1. **Clone or Download the Repository**: Clone or download the Task Manager repository from [GitHub link here].

2. **Configure Local Database**:
   - Open the `appsettings.json` file located in the `src/Taskify` folder.
   - Update the connection string to point to your local database. If you prefer an in-memory database, set `"UseOnlyInMemoryDatabase": true`.

3. **Run the Application**:
   - Open a terminal window and navigate to the `Web` folder of the project.
   - Run the following command:
     ```
     dotnet run
     ```
   - This command will apply migrations and create the database for the application.

4. **Access the Application**:
   - Once the application is running, open your web browser and navigate to specified port.

### Task Operations

Task Manager enables you to perform the following operations:

- **Create Task**:
  - Click on the "New Task" button.
  - Fill in the task details including title, description, due date, and priority.
  - Click "Save" to create the task.

- **Read Task**:
  - View all tasks on the home page.
  - Click on a task to view its details.

- **Update Task**:
  - Click on a task to view its details.
  - Click on the "Edit" button.
  - Update the task details as required.
  - Click "Save" to update the task.

- **Delete Task**:
  - Click on a task to view its details.
  - Click on the "Delete" button.
  - Confirm the deletion.

### Additional Notes

- **User Authentication**: There is no authentication required for accessing Task Manager in this version.
