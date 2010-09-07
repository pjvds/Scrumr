﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    public class SprintDeactivated : SourcedEntityEvent
    {
        public Guid ProjectId { get { return EventSourceId; } }
        public Guid SprintId { get { return EntityId; } }

        public SprintDeactivated()
        { }
    }
}