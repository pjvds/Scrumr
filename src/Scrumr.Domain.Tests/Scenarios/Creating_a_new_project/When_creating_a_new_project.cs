using System;
using System.Linq;
using FluentAssertions;
using Ncqrs.Spec;
using Scrumr.Commands;

namespace Scrumr.Domain.Tests.Scenarios.Creating_a_new_project
{
    [Specification]
    public class When_creating_a_new_project : AutoMappedCommandTestFixture<CreateNewProject>
    {
        protected override CreateNewProject When()
        {
            return new CreateNewProject
            {
                ProjectId = Guid.NewGuid(),
                Name = "My Project"
            };
        }

        [Then]
        public void Then_published_events_count_should_be_one()
        {
            PublishedEvents.Count().Should().Be(1);
        }
    }
}
