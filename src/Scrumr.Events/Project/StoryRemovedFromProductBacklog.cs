using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class StoryRemovedFromProductBacklog : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid ProductBacklogId { get { return EntityId; }}
        public Guid StoryId { get; set; }

        public StoryRemovedFromProductBacklog()
        {
        }

        public StoryRemovedFromProductBacklog(Guid storyId)
        {
            StoryId = storyId;
        }
    }
}