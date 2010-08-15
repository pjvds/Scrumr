using System;
using Ncqrs.Domain;

namespace Scrumr.Domain
{
    public class Story : Entity
    {
        private string _description;

        public Story(AggregateRoot parent, string description) : base(parent)
        {
            _description = description;
        }
    }
}
