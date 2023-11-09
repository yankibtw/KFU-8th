using System;

namespace KFU_8th
{
    class User
    {
        public string Name { get; }
        public User(string name)
        {
            Name = name;
        }
        public void StartTask(Task task)
        {
            if (task.Status == TaskStatus.Assigned && task.Executor == this)
            {
                task.AssignExecutor(this);
                Console.WriteLine($"Пользователь {Name} начал выполнение задачи '{task.Name}'.");
            }
            else
            {
                task.RejectTask();
                Console.WriteLine($"Пользователь {Name} не может начать выполнение этой задачи.");
            }
        }
        public void DelegateTask(Task task, User newExecutor)
        {
            if (task.Executor == this && task.Status == TaskStatus.AtWork)
            {
                task.DelegateTask(newExecutor);
                Console.WriteLine($"Пользователь {Name} делегировал задачу '{task.Name}' пользователю {newExecutor.Name}.");
            }
            else
            {
                Console.WriteLine($"Пользователь {Name} не может делегировать эту задачу.");
            }
        }
        public void CompleteTask(Task task, Report reportText)
        {
            if (task.Executor == this && task.Status == TaskStatus.AtWork)
            {
                task.CompleteTask(reportText);
                Console.WriteLine($"Пользователь {Name} завершил задачу '{task.Name}'.");
            }
            else
            {
                Console.WriteLine($"Пользователь {Name} не может завершить эту задачу.");
            }
        }
    }
}
