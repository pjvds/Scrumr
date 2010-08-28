using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class StoryAddedToProductBacklog : SourcedEntityEvent
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public StoryAddedToProductBacklog()
        {
            
        }

        public StoryAddedToProductBacklog(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
