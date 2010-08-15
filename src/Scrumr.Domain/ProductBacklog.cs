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
            // TODO: Improve it with simpler handler or introduction of EntityMappedByConvention class.
            RegisterHandler(
                new TypeAndCallbackThresholdedActionBasedDomainEventHandler(
                    (e) => OnStoryAdded((StoryAddedToProductBacklog) e),
                    (e) => e is StoryAddedToProductBacklog, typeof (StoryAddedToProductBacklog)));

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

        private void OnStoryAdded(StoryAddedToProductBacklog e)
        {
            // TODO: Determine what to do with entities that have a entity as parent
            // _stories.Add(new Story());
        }

        private void OnProductBacklogRenamed(ProductBacklogRenamed e)
        {
            _name = e.NewName;
        }
    }
}
