using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class TaskAddedToStory : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid StoryId { get { return EntityId; } }
        public Guid SprintId { get; set; }
        public Guid TaskId { get; set; }
        public string Name { get; set; }

        public TaskAddedToStory(Guid sprintId, Guid taskId, string name)
        {
            SprintId = sprintId;
            TaskId = taskId;
            Name = name;
        }
    }
}
