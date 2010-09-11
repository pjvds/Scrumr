using System;
using System.Collections.Generic;
using Ncqrs.Domain;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class Story : EntityMappedByConvention
    {
        private Sprint _sprint;
        private string _name;
        private string _description;

        private List<Task> _tasks = new List<Task>();

        public Story(AggregateRoot parent, Sprint sprint, Guid id, string description)
            : base(parent, id)
        {
            _sprint = sprint;
            _description = description;
        }

        public void AddNewTask(Guid taskId, Guid stageId, string description)
        {
            ApplyEvent(new NewTaskAddedToStory(_sprint.EntityId, stageId, taskId, description));
        }

        protected void OnNewTaskAddedToStory(NewTaskAddedToStory e)
        {
            _tasks.Add(new Task(ParentAggregateRoot, _sprint, e.StageId, e.TaskId, e.Description));
        }
    }
}
