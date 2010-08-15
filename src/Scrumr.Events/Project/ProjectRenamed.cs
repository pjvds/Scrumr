using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class ProjectRenamed : ProjectEvent
    {
        public string NewName { get; set; }

        public ProjectRenamed()
        {
        }

        public ProjectRenamed(string newName)
        {
            NewName = newName;
        }
    }
}
