using System;

namespace LabIProject
{
    public class Task
    {
        private const string DEFAULT_TITLE = "No Title";
        private const string DEFAULT_DESCRIPTION = "No Description";
        private const string DEFAULT_ASSIGNEE = "No Assignee";
        private string Assignee;
        private string Description;
        private int Estimation;
        private Guid Id;
        private DateTime StartDate;
        private string Title;

        public Task()
        {
            Id = Guid.NewGuid();
            Title = DEFAULT_TITLE;
            Description = DEFAULT_DESCRIPTION;
            StartDate = default(DateTime);
            Assignee = DEFAULT_ASSIGNEE;
            Estimation = 0;
        }

        public Task(string title, string description, DateTime startDate, string assignee, int estimation)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            StartDate = startDate;
            Assignee = assignee;
            Estimation = estimation;
        }

        public Guid IdPropriety
        {
            get => Id;
            private set
            {
                if (value != null)
                    Id = value;
            }
        }

        public string TitlePropriety
        {
            get => Title;
            set
            {
                if (value != null)
                    Title = value;
            }
        }


        public string AssigneePropriety
        {
            get => Assignee;
            set
            {
                if (value != null)
                    Assignee = value;
            }
        }


        public string DescriptionPropriety
        {
            get => Description;
            set
            {
                if (value != null)
                    Description = value;
            }
        }

        public int EstimationPropriety
        {
            get => Estimation;
            set
            {
                if (value != null)
                    Estimation = value;
            }
        }

        public DateTime StartDatePropriety
        {
            get => StartDate;
            set
            {
                if (value != null)
                    StartDate = value;
            }
        }

        public bool IsOnTrack()
        {
            if (Estimation - (DateTime.Now - StartDate).TotalDays < 0)
            {
                return false;
            }

            return true;
        }

        public int CalculateRemainingEstimate()
        {
            if ((DateTime.Now - StartDate).TotalDays < 0)
                return Estimation;
            if ((DateTime.Now - StartDate).TotalDays > Estimation)
                return 0;
            return Estimation - (int) (DateTime.Now - StartDate).TotalDays;
        }
    }
}