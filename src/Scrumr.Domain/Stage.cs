using System;
using Ncqrs.Domain;

namespace Scrumr.Domain
{
    public class Stage : EntityMappedByConvention
    {
        private string _name;
        private Sprint _parent;

        public Stage(AggregateRoot root, Sprint parent, Guid entityId, string name) : base(root, entityId)
        {
            _parent = parent;
            _name = name;
        }
    }
}
