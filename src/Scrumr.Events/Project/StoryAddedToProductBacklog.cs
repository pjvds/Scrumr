using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class StoryAddedToProductBacklog : SourcedEntityEvent
    {
        public Guid StoryId { get; set; }
        public string Description { get; set; }

        public StoryAddedToProductBacklog()
        {
            
        }

        public StoryAddedToProductBacklog(Guid storyId, string description)
        {
            StoryId = storyId;
            Description = description;
        }
    }
}
