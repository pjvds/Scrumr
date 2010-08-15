using System;
using System.Collections.Generic;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class ProductBacklog : Entity
    {
        private string _name;
        private List<Story> _stories = new List<Story>();

        public ProductBacklog(Project parent, string name) : base(parent)
        {
            RegisterHandler(new RedirectingSourcedEventHandler<ProductBacklogRenamed>(OnProductBacklogRenamed));

            _name = name;
        }

        public void AddStory(string description)
        {
            var e = new StoryAddedToProductBacklog(Guid.NewGuid(), description);
            ApplyEvent(e);
        }

        public void Renamed(string newName)
        {
            var e = new ProductBacklogRenamed(newName);
            ApplyEvent(e);
        }

        private void OnProductBacklogRenamed(ProductBacklogRenamed e)
        {
            _name = e.NewName;
        }
    }
}
