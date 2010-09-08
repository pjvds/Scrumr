using System;
using System.Collections.Generic;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class Story : EntityMappedByConvention
    {
        private Sprint _sprint;
        private string _name;
        private string _description;

        private List<Task> _tasks;

        public Story(AggregateRoot parent, Sprint sprint, Guid id, string description)
            : base(parent, id)
        {
            _sprint = sprint;
            _description = description;
        }

        public void AddTask(Guid taskId, string name)
        {
            ApplyEvent(new TaskAddedToStory(_sprint.EntityId, taskId, name));
        }
    }
}
