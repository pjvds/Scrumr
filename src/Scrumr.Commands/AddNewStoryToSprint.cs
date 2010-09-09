using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Scrumr.Commands
{
    [MapsToAggregateRootMethod("Scrumr.Domain.Project, Scrumr.Domain", "AddNewStoryToSprint")]
    public class AddNewStoryToSprint : CommandBase
    {
        [AggregateRootId]
        public Guid ProjectId { get; set; }

        [Parameter]
        public Guid SprintId { get; set; }

        [Parameter]
        public Guid StoryId { get; set; }

        [Parameter]
        public String Description { get; set; }

        public AddNewStoryToSprint()
        {
        
        }

        public AddNewStoryToSprint(Guid projectId, Guid sprintId, Guid storyId, string description)
        {
            ProjectId = projectId;
            SprintId = sprintId;
            StoryId = storyId;
            Description = description;
        }
    }
}