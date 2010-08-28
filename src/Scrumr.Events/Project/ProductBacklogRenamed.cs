using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class ProductBacklogRenamed : SourcedEntityEvent
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
