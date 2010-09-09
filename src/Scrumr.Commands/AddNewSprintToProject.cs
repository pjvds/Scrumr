using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Scrumr.Commands
{
    [MapsToAggregateRootMethod("Scrumr.Domain.Project, Scrumr.Domain", "AddSprint")]
    public class AddNewSprintToProject : CommandBase
    {
        [AggregateRootId]
        public Guid ProjectId { get; set; }

        [Parameter(1)]
        public Guid SprintId { get; set; }

        [Parameter(2)]
        public String Name { get; set; }

        [Parameter(3)]
        public DateTime From { get; set; }

        [Parameter(4)]
        public DateTime To { get; set; }

        public AddNewSprintToProject()
        {
            
        }

        public AddNewSprintToProject(Guid projectId, Guid sprintId, string name, DateTime from, DateTime to)
        {
            ProjectId = projectId;
            SprintId = sprintId;
            Name = name;
            From = from;
            To = to;
        }
    }
}
