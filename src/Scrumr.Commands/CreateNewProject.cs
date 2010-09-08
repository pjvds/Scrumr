using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Scrumr.Commands
{
    [MapsToAggregateRootConstructor("Scrumr.Domain.Project, Scrumr.Domain")]
    public class CreateNewProject : CommandBase
    {
        [Parameter(1)]
        public Guid ProjectId { get; set; }

        [Parameter(2)]
        public string Name { get; set; }

        [Parameter(3)]
        public string ShortCode { get; set; }

        public CreateNewProject()
        {
            
        }
        
        public CreateNewProject(Guid projectId, string name)
        {
            ProjectId = projectId;
            Name = name;
        }
    }
}
