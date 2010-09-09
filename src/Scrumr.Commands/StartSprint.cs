using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Scrumr.Commands
{
    [MapsToAggregateRootMethod("Scrumr.Domain.Project, Scrumr.Domain", "StartSprint")]
    public class StartSprint : CommandBase
    {
        [AggregateRootId]
        public Guid ProjectId { get; set; }

        [Parameter(1)]
        public Guid SprintId { get; set; }

        public StartSprint()
        {
        }

        public StartSprint(Guid projectId, Guid sprintId)
        {
            ProjectId = projectId;
            SprintId = sprintId;
        }
    }
}