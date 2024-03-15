**Task Manager Application**

Welcome to Task Manager - your solution for efficient task management. Task Manager allows you to perform CRUD operations for your day-to-day tasks, including creating, reading, updating, and deleting tasks with ease. Each task includes essential details such as title, description, due date, and priority.

### Live Application

You can access the live application of Task Manager by visiting "taskifypro.azurewebsites.net".

### Running Locally

To run Task Manager locally, follow these simple steps:

1. **Clone or Download the Repository**: Clone or download the Task Manager repository from "https://github.com/djshres/Taskify".

2. **Configure Local Database**:
   - Open the `appsettings.json` file located in the `src/Taskify` folder.
   - Update the connection string to point to your local database. If you prefer an in-memory database, set `"UseOnlyInMemoryDatabase": true`.

3. **Run the Application**:
   - Open a terminal window and navigate to the `Taskify` folder of the project.
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


### CI/CD Integration

Task Manager utilizes Continuous Integration and Continuous Deployment (CI/CD) practices to automate the deployment process, ensuring efficient development and deployment workflows. The application is hosted on Azure and employs GitHub Actions for seamless CI/CD integration.

## CI/CD Workflow
The CI/CD workflow for Task Manager is as follows:

GitHub Repository: Task Manager's source code is hosted on GitHub.

# Continuous Integration (CI):

Whenever changes are pushed to the repository, GitHub Actions automatically trigger the CI process.
The CI process includes tasks such as building the application, running tests, and checking for code quality.
Continuous Deployment (CD):

Upon successful completion of the CI process, GitHub Actions trigger the CD process for deploying the application to Azure.
Deployment scripts or Azure DevOps tasks are executed to deploy the application to the Azure App Service.
Deployment to Azure:

Task Manager is deployed to Azure App Service, providing a scalable and reliable hosting environment.
Azure App Service ensures high availability and seamless deployment of the application.
GitHub Actions Configuration
Task Manager's CI/CD pipeline is configured using GitHub Actions. Here's a breakdown of the GitHub Actions configuration:

Workflow File: The workflow is defined in a YAML file named ci-cd.yml located in the .github/workflows directory of the repository.

Trigger: The workflow is triggered on events such as pushes to the main branch or pull requests.

# Jobs:

Build and Test: This job builds the application, runs tests, and checks for code quality using appropriate commands (e.g., dotnet build, dotnet test).
Deployment: Upon successful completion of the build and test job, the deployment job is triggered.
Environment Variables: GitHub Secrets or Azure Service Principal credentials are used as environment variables for securely accessing Azure resources during deployment.

## Azure Integration
Task Manager is hosted on Azure, leveraging Azure services for hosting and deployment. Key Azure services used in the deployment process include:

Azure App Service: Task Manager is deployed to Azure App Service, which provides a fully managed platform for building, deploying, and scaling web applications.

Azure Database: If applicable, Task Manager may utilize Azure Database services for data storage.

Azure Resource Group: Azure resources related to Task Manager are organized within an Azure Resource Group for easier management and provisioning.