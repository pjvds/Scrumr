using System;
using Ncqrs.Domain;

namespace Scrumr.Domain
{
    public class Story : EntityMappedByConvention
    {
        private string _description;

        public Story(AggregateRoot parent, Guid id, string description) : base(parent, id)
        {
            _description = description;
        }
    }
}
