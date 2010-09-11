using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class NewTaskAddedToStory : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid StoryId { get { return EntityId; } }
        public Guid SprintId { get; set; }
        public Guid TaskId { get; set; }
        public Guid StageId { get; set; }
        public string Description { get; set; }

        public NewTaskAddedToStory(Guid sprintId, Guid stageId, Guid taskId, string description)
        {
            SprintId = sprintId;
            StageId = stageId;
            TaskId = taskId;
            Description = description;
        }
    }
}
