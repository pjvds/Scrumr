using System;

namespace Scrumr.Events.Project
{
    public class MemberRemovedFromProject : ProjectEvent
    {
        public Guid MemberId { get; set; }

        public MemberRemovedFromProject()
        {

        }

        public MemberRemovedFromProject(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
