using System;

namespace Scrumr.Events.Project
{
    public class MemberAddedToProject : ProjectEvent
    {
        public Guid MemberId { get; set; }

        public MemberAddedToProject()
        {
            
        }

        public MemberAddedToProject(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
