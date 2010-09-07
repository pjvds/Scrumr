using System;

namespace Scrumr.Web.MainSite.Models
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Stage Stage { get; set; }

        public Task(string description, Stage stage)
        {
            Description = description;
            Stage = stage;
        }
    }
}