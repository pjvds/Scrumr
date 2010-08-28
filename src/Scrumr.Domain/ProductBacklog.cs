using System;
using System.Collections.Generic;
using Ncqrs.Domain;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class ProductBacklog : EntityMappedByConvention
    {
        private string _name;
        private List<Story> _stories = new List<Story>();

        public ProductBacklog(Project parent, Guid entityId, string name) : base(parent, entityId)
        {
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
