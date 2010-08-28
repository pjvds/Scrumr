using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ncqrs.Spec;
using Scrumr.Events.Project;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Domain.Tests.AggregateRoots
{
    [Specification]
    public class When_adding_a_new_story_to_a_Project_ProductBacklog : AggregateRootTestFixture<Project>
    {
        private Guid TheStoryId = Guid.NewGuid();
        private string TheStoryDescription = "Hello world";

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new NewProjectCreated(Guid.NewGuid(), Guid.NewGuid(), "My project")
            ).ForSource(Guid.NewGuid());
        }

        protected override void When()
        {
            AggregateRoot.ProductBacklog.AddStory(TheStoryId, TheStoryDescription);
        }

        [Then]
        public void Then_only_event_event_should_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_StoryAddedToProductBacklog()
        {
            PublishedEvents.First().Should().BeOfType<StoryAddedToProductBacklog>();
        }

        [And]
        public void And_event_info_should_contain_given_details()
        {
            var evnt = PublishedEvents.First().As<StoryAddedToProductBacklog>();
            evnt.StoryId.Should().Be(TheStoryId);
            evnt.Description.Should().Be(TheStoryDescription);
        }

        [And]
        public void And_the_owner_should_be_the_ProductBacklog()
        {
            var evnt = PublishedEvents.First().As<StoryAddedToProductBacklog>();
            evnt.EntityId.Should().Be(AggregateRoot.ProductBacklog.EntityId);
        }
    }
}
