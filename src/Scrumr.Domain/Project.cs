using System;
using System.Collections.Generic;
using System.Linq;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class Project : ScrumrAggregateRoot
    {
        private string _name;
        private string _shortCode;
        private List<Guid> _members = new List<Guid>();
        private List<Sprint> _sprints = new List<Sprint>();

        protected Project()
        {
        }

        public Project(Guid id, string name, string shortCode) : base(id)
        {
            ValidateName(name);

            ApplyEvent(new NewProjectCreated(id, name, shortCode));
        }

        public void StartSprint(Guid sprintId)
        {
            var sprintToStart = _sprints.SingleOrDefault(sprint => sprint.EntityId == sprintId);
            sprintToStart.Start();
        }

        public void FinishSprint(Guid sprintId)
        {
            var sprintToFinish = _sprints.SingleOrDefault(sprint => sprint.EntityId == sprintId);
            sprintToFinish.Finish();
        }

        protected void ValidateName(string name)
        {
            const int NameMaxLenght = 50;

            if(string.IsNullOrEmpty(name))
            {
                throw new DomainException("The name of a project cannot be empty.");
            }
            if(name.Length > NameMaxLenght)
            {
                throw new DomainException("The name of a project cannot be longer then "+NameMaxLenght+".");
            }
        }

        public void Rename(string newName)
        {
            ValidateName(newName);

            var e = new ProjectRenamed(newName);
            ApplyEvent(e);
        }

        public void AddMember(Guid memberId)
        {
            if(_members.Contains(memberId)) throw new DomainException(string.Format("Already contains member with id {0}.", memberId));

            var e = new MemberAddedToProject(memberId);
            ApplyEvent(e);
        }

        public void AddNewStoryToSprint(Guid sprintId, Guid storyId, String description)
        {
            var sprint = _sprints.Single(s => s.EntityId == sprintId);
            sprint.AddNewStory(storyId, description);
        }

        public void AddSprint(Guid sprintId, string name, DateTime from, DateTime to)
        {
            // TODO: Add constrains.
            ApplyEvent(new SprintAddedToProject(sprintId, name, from, to));

            var sprint = _sprints.Single(s => s.EntityId == sprintId);
            sprint.AddStage(Guid.NewGuid(), "Unstarted");
            sprint.AddStage(Guid.NewGuid(), "Ongoing");
            sprint.AddStage(Guid.NewGuid(), "Completed");
        }

        protected  void OnProjectCreated(NewProjectCreated e)
        {
            _name = e.Name;
            _shortCode = e.ShortCode;
        }

        protected void OnSprintAdded(SprintAddedToProject e)
        {
            var sprint = new Sprint(this, e.SprintId, e.Name, e.From, e.To);
            _sprints.Add(sprint);
        }

        public void RemoveMember(Guid memberId)
        {
            var e = new MemberRemovedFromProject(memberId);
            ApplyEvent(e);
        }

        private void OnProjectRenamed(ProjectRenamed e)
        {
            _name = e.NewName;
        }

        private void OnMemberAdded(MemberAddedToProject e)
        {
            _members.Add(e.MemberId);
        }

        private void OnMemberRemoved(MemberRemovedFromProject e)
        {
            _members.Remove(e.MemberId);
        }
    }
}
