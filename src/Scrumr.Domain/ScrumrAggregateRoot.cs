using System;
using Ncqrs.Domain;

namespace Scrumr.Domain
{
    public abstract class ScrumrAggregateRoot : AggregateRootMappedByConvention
    {
        protected ScrumrAggregateRoot()
        {
        }

        protected ScrumrAggregateRoot(Guid id) : base(id)
        {
        }
    }
}
