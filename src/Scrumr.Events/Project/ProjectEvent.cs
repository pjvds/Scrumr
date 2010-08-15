using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public abstract class ProjectEvent : SourcedEvent

    {
        public Guid ProjectId { get { return EventSourceId; } }
    }
}
