using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Scrumr.Commands
{
    [MapsToAggregateRootMethod("Scrumr.Domain.Project, Scrumr.Domain", "AddNewTaskToStory")]
    public class AddNewTaskToStory : CommandBase
    {
        [AggregateRootId]
        public Guid ProjectId { get; set; }

        [Parameter]
        public Guid SprintId { get; set; }
        [Parameter]
        public Guid StageId { get; set; }
        [Parameter]
        public Guid StoryId { get; set; }
        [Parameter]
        public Guid NewTaskId { get; set; }
        [Parameter]
        public string Description { get; set; }

        public AddNewTaskToStory()
        {

        }

        public AddNewTaskToStory(Guid projectId, Guid sprintId, Guid stageId, Guid storyId, Guid newTaskId, String description)
        {
            ProjectId = projectId;
            SprintId = sprintId;
            StageId = stageId;
            StoryId = storyId;
            NewTaskId = newTaskId;
            Description = description;
        }
    }
}
