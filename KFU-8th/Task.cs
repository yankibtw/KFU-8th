using System;
using System.CodeDom.Compiler;
using System.Threading.Tasks;

namespace KFU_8th
{
    enum TaskStatus
    {
        Assigned,
        AtWork,
        OnInspection,
        Completed
    }
    class Task
    {
        public string Name { get; }
        public string Description { get; }
        public DateTime Deadline { get; }
        public User Initiator { get; }
        public User Executor { get; private set; }
        public TaskStatus Status { get; private set; }
        public Report ReportText { get; private set; }

        public Task(string name, string description, DateTime deadline, User initiator, User executor)
        {
            Name = name;
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Executor = executor;
            Status = TaskStatus.Assigned;
        }
        public void AssignExecutor(User executor)
        {
            Executor = executor;
            Status = TaskStatus.AtWork;
        }
        public void DelegateTask(User newExecutor)
        {
            Executor = newExecutor;
            Status = TaskStatus.Assigned;
        }
        public void CompleteTask(Report reportText)
        {
            ReportText = reportText;
            Status = TaskStatus.OnInspection;
        }
        public void CompleteTask()
        {
            Status = TaskStatus.Completed;
        }
        public void RejectTask()
        {
            Executor = null;
        }
        public void SendReport()
        {
            Console.WriteLine($"Отчет по задаче: {ReportText.Text}");
        }
    }
}
