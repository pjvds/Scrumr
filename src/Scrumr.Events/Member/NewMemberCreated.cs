using System;

namespace Scrumr.Events.Member
{
    public class NewMemberCreated : MemberEvent
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
