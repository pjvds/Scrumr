using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Scrumr.Commands
{
    public class ChangeProductBacklogStoryDescription : CommandBase
    {
        public Guid ProjectId { get; set; }
        public Guid StoryId { get; set; }
        public Guid NewDescription { get; set; }
    }
}
