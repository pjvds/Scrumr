using System;

namespace Scrumr.Events.Project
{
    public class StoryAddedToProductBacklog : ProjectEvent
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
