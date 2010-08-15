using System;

namespace Scrumr.Events.Project
{
    public class ProductBacklogRenamed : ProjectEvent
    {
        public string NewName { get; set; }

        public ProductBacklogRenamed()
        {
        }

        public ProductBacklogRenamed(string newName)
        {
            NewName = newName;
        }
    }
}
