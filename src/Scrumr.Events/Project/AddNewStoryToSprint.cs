using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class AddNewStoryToSprint : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid SprintId { get { return EntityId; } }
        public Guid StoryId { get; set; }
        public String Description { get; set; }

        public AddNewStoryToSprint()
        {
            
        }

        public AddNewStoryToSprint(Guid storyId, string description)
        {
            StoryId = storyId;
            Description = description;
        }
    }
}
