using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Scrumr.Commands;
using Ncqrs.Spec;

namespace Scrumr.Domain.Tests.Scenarios.Creating_a_new_project
{
    [Specification]
    public class When_creating_project_with_a_too_long_name : AutoMappedCommandTestFixture<CreateNewProject>
    {
        protected override CreateNewProject When()
        {
            return new CreateNewProject
            (
                Guid.NewGuid(),
                "ThisNameIsWaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaayTooLong"
            );
        }

        [Then]
        public void Then_we_expect_an_exception_to_occure()
        {
            CaughtException.Should().BeOfType<DomainException>();
        }

        [And]
        public void And_no_events_should_be_published()
        {
            PublishedEvents.Should().BeEmpty();
        }
    }
}
