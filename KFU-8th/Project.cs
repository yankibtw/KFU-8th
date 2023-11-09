using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace KFU_8th
{
    enum ProjectStatus
    {
        Project,
        InProgress,
        Closed
    }
    class Project
    {
        public string Name {get;}
        public string Description { get; }
        public DateTime Deadline { get; }
        public User Initiator { get; }
        public User ProjectManager { get; }
        public List<Task> Tasks { get; }
        public ProjectStatus Status { get; private set; }

        public Project(string name, string description, DateTime deadline, User initiator, User projectManager)
        {
            Name = name;
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            ProjectManager = projectManager;
            Tasks = new List<Task>();
            Status = ProjectStatus.Project;
        } 
        public void AssignTask(User executor, User initiator, string taskName, string taskDescription, DateTime taskDeadline)
        {
            if (Status == ProjectStatus.Project)
            {
                Task task = new Task(taskName, taskDescription, taskDeadline, initiator, executor);
                Tasks.Add(task);
            }
            else
            {
                Console.WriteLine("Нельзя добавить задачу к закрытому проекту.");
            }
        }
        public void ChangeStatusToExecution()
        {
            Status = ProjectStatus.InProgress;
        }
        public void CheckTask(User checker, Task task, bool approved)
        {
            if (task.Status == TaskStatus.OnInspection && checker == ProjectManager)
            {
                if (approved)
                {
                    task.CompleteTask();
                    task.SendReport();
                    Console.WriteLine("Задача утверждена.");
                }
                else
                {
                    Console.WriteLine("Задача требует доработки.");
                }
            }
            else
            {
                Console.WriteLine("Невозможно проверить задачу.");
            }
        }

    }
}
