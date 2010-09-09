using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class NewStageAddedToSprint : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid SprintId { get { return EntityId; } }
        public Guid StageId { get; set; }
        public String Name { get; set; }

        public NewStageAddedToSprint()
        {
            
        }

        public NewStageAddedToSprint(Guid stageId, string name)
        {
            StageId = stageId;
            Name = name;
        }
    }
}
