using System;
using System.Collections.Generic;

namespace KFU_8th
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            for (int i = 1; i <= 10; i++)
            {
                users.Add(new User($"Пользователь {i}"));
            }
            User initiator = new User($"Заказчик");
            User teamlead = new User($"Тимлид");
            Project project = new Project("Проект 1", "Описание проекта 1", DateTime.Now.AddDays(30), initiator, teamlead);
         
            int taskIndex = 0;
            foreach (var user in users)
            {
                project.AssignTask(user, teamlead, $"Задача {taskIndex + 1}", $"Описание задачи {taskIndex + 1}", DateTime.Now.AddDays(15));
                taskIndex++;
            }
            project.ChangeStatusToExecution();
            users[0].StartTask(project.Tasks[0]);
            users[0].DelegateTask(project.Tasks[0], users[1]);
            users[1].StartTask(project.Tasks[0]);
            users[1].CompleteTask(project.Tasks[0], new Report("Все удачно завершено", DateTime.Now, users[0]));
            project.CheckTask(teamlead, project.Tasks[0], true);

        }
    }
}

