using System;
using System.Collections.Generic;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class Project : ScrumrAggregateRoot
    {
        private string _name;
        private List<Guid> _members = new List<Guid>();

        protected Project()
        {
            // Needed for Ncqrs.
        }

        public Project(Guid id, string name)
        {
            ValidateName(name);

            EventSourceId = id;

            var e = new NewProjectCreated(name);
            ApplyEvent(e);
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
            var e = new MemberAddedToProject(memberId);
            ApplyEvent(e);
        }

        public void RemoveMember(Guid memberId)
        {
            var e = new MemberRemovedFromProject(memberId);
            ApplyEvent(e);
        }

        private void OnProjectCreated(NewProjectCreated e)
        {
            EventSourceId = e.ProjectId;
            _name = e.Name;
        }

        private void OnProjectRenamed(ProjectRenamed e)
        {
            _name = e.NewName;
        }
    }
}
