using System;

namespace KFU_8th
{
    class Report
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public User Assignee { get; set; }

        public Report(string Text, DateTime Date, User Assignee)
        {
            this.Text = Text;
            this.Date = Date;
            this.Assignee = Assignee;
        }
    }
}
