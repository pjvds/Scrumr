using System;
using System.Linq;
using FluentAssertions;
using Ncqrs.Spec;
using Scrumr.Events;
using Scrumr.Events.Project;

namespace Scrumr.Domain.Tests.AggregateRoots
{
    [Specification]
    public class When_creating_a_new_Project : AggregateRootTestFixture<Project>
    {
        private Guid TheId = Guid.NewGuid();
        private String TheName = "My Project";

        protected override void When()
        {
            AggregateRoot = new Project(TheId, TheName);
        }

        [Then]
        public void Then_the_EventSourceId_should_be_set_to_the_ProjectId()
        {
            var evnt = (NewProjectCreated)PublishedEvents.First();
            AggregateRoot.EventSourceId.Should().Be(evnt.ProjectId);
        }

        [Then]
        public void Then_one_event_NewProjectCreated_should_have_been_published()
        {
            PublishedEvents.Count().Should().Be(1);
            PublishedEvents.First().Should().BeOfType<NewProjectCreated>();
        }

        [Then]
        public void Then_project_id_and_name_should_be_published_as_given_at_construct()
        {
            var evnt = PublishedEvents.First().As<NewProjectCreated>();
            
            evnt.ProjectId.Should().Be(TheId);
            
            evnt.Name.Should().Be(TheName);

            evnt.ProductBacklogId.Should().NotBe(Guid.Empty);
        }
    }
}
