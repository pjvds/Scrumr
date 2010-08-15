using System;
using Scrumr.Events.Member;

namespace Scrumr.Domain
{
    public class Member : ScrumrAggregateRoot
    {
        private string _name;
        private EmailAddress _emailAddress;

        protected Member(string name, EmailAddress emailAddress)
        {
            var e = new NewMemberCreated {Name = name, EmailAddress = emailAddress.ToString()};
            ApplyEvent(e);
        }

        private void OnNewMemberCreated(NewMemberCreated e)
        {
            _name = e.Name;
            _emailAddress = new EmailAddress(e.EmailAddress);
        }
    }
}
