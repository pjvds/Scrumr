using System;
using System.Collections.Generic;
using Ncqrs.Domain;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class Sprint : EntityMappedByConvention
    {
        private string _name;
        private DateTime _from;
        private DateTime _to;
        private List<Stage> _stages;
        private List<Story> _stories;

        public bool IsActive
        {
            get; private set;
        }

        public Sprint(Project parent, Guid id, string name, DateTime from, DateTime to) : base(parent, id)
        {
            _stages = new List<Stage>();
            _stories = new List<Story>();
        }

        public void AddNewStory(Guid storyId, string description)
        {
            ApplyEvent(new AddNewStoryToSprint(storyId, description));
        }

        public void Start()
        {
            ApplyEvent(new SprintStarted(DateTime.UtcNow));
        }

        public void AddStage(Guid stageId, string name)
        {
            ApplyEvent(new NewStageAddedToSprint(stageId, name));
        }

        public void Finish()
        {
            ApplyEvent(new SprintFinished(DateTime.UtcNow));            
        }

        protected void OnSprintStarted(SprintStarted e)
        {
            IsActive = true;
        }

        protected void OnSprintFinished(SprintFinished e)
        {
            IsActive = false;
        }

        protected void OnAddStage(NewStageAddedToSprint e)
        {
            _stages.Add(new Stage(ParentAggregateRoot, this, e.StageId, e.Name));
        }

        protected void OnAddNewStory(AddNewStoryToSprint e)
        {
            _stories.Add(new Story(ParentAggregateRoot, this, e.StoryId, e.Description));
        }
    }
}