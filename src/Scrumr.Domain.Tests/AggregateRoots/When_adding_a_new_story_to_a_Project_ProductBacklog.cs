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
        private string _storyDescription = "Hello world";

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new NewProjectCreated(Guid.NewGuid(), Guid.NewGuid(), "My project")
            ).ForSource(Guid.NewGuid());
        }

        protected override void When()
        {
            AggregateRoot.ProductBacklog.AddStory(_storyDescription);
        }

        [Then]
        public void Then_only_event_event_should_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [Then]
        public void And_should_be_of_type_StoryAddedToProductBacklog()
        {
            PublishedEvents.First().Should().BeOfType<StoryAddedToProductBacklog>();
        }
    }
}
