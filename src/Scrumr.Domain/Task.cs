using System;
using Ncqrs.Domain;

namespace Scrumr.Domain
{
    public class Task : EntityMappedByConvention
    {
        private Sprint _parent;
        private Guid _stageId;
        private string _description;

        public Task(AggregateRoot root, Sprint parent, Guid stageId, Guid taskId, String description)
            : base(root, taskId)
        {
            _parent = parent;
            _stageId = stageId;
            _description = description;
        }
    }
}
