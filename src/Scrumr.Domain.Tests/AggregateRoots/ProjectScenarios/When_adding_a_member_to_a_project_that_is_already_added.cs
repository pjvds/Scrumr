using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Ncqrs.Spec;
using Ncqrs.Eventing.Sourcing;
using Scrumr.Events.Project;

namespace Scrumr.Domain.Tests.AggregateRoots
{
    [Specification]
    public class When_adding_a_member_to_a_project_that_is_already_added : AggregateRootTestFixture<Project>
    {
        private Guid TheProjectId = Guid.NewGuid();
        private Guid TheMemberId = Guid.NewGuid();

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new NewProjectCreated(TheProjectId, "My Project", "myproject"),
                new MemberAddedToProject(TheMemberId)
            )
            .ForSource(TheProjectId);
        }

        protected override void When()
        {
            AggregateRoot.AddMember(TheMemberId);
        }

        [Then]
        public void Then_an_DomainException_should_occure()
        {
            CaughtException.Should().BeOfType<DomainException>();
            
            CaughtException.Message.Should().StartWith("Already contains member with id");
        }
    }
}
