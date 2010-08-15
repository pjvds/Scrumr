using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Member
{
    public abstract class MemberEvent : SourcedEvent
    {
        public Guid MemberId
        {
            get { return EventSourceId; }
        }
    }
}
