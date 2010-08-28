using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ncqrs.Eventing.Sourcing;
using Ncqrs.Spec;
using Scrumr.Events.Project;

namespace Scrumr.Domain.Tests.AggregateRoots
{
    [Specification]
    class When_renaming_a_Project : AggregateRootTestFixture<Project>
    {
        private Guid TheId = Guid.NewGuid();
        private Guid TheProductBacklogId = Guid.NewGuid();
        private string OldName = "My old project";
        private string NewName = "My new project";

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new NewProjectCreated(TheId, TheProductBacklogId, OldName)
            )
            .ForSource(TheId);
        }

        protected override void When()
        {
            AggregateRoot.Rename(NewName);
        }

        [Then]
        public void Then_the_ProjectRenamed_event_been_published()
        {
            PublishedEvents.Count().Should().Be(1);

            var evnt = (ProjectRenamed) PublishedEvents.First();
            evnt.EventSourceId.Should().Be(TheId);
            evnt.NewName.Should().Be(NewName);
        }
    }
}
