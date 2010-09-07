using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Scrumr.Commands
{
    public class MoveTaskToStage : CommandBase
    {
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public Guid StageId { get; set; }
    }
}
