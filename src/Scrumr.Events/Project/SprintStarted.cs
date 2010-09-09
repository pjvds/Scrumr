using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class SprintStarted : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid SprintId { get { return EntityId; } }
        public DateTime StartDate { get; set; }

        public SprintStarted()
        {}

        public SprintStarted(DateTime startDate)
        {
            StartDate = startDate;
        }
    }
}
