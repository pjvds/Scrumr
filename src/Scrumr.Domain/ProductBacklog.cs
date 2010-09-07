using System;
using System.Linq;
using System.Collections.Generic;
using Ncqrs.Domain;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class ProductBacklog : EntityMappedByConvention
    {
        private string _name;
        private List<Story> _stories = new List<Story>();

        public IEnumerable<Story> Stories
        {
            get { return _stories; }
        }

        public ProductBacklog(Project parent, Guid entityId, string name) : base(parent, entityId)
        {
            _name = name;
        }

        public void AddStory(Guid storyId, String description)
        {
            var e = new StoryAddedToProductBacklog(storyId, description);
            ApplyEvent(e);
        }

        public void RemoveStory(Guid storyId)
        {
            if (!_stories.Exists(s => s.EntityId == storyId))
            {
                throw new DomainException("Cannot remove story that is not part of this product backlog.");
            }

            var e = new StoryRemovedFromProductBacklog(storyId);
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
            _stories.Add(new Story(this.ParentAggregateRoot, e.StoryId, e.Description));
        }

        private void OnStoryRemoved(StoryRemovedFromProductBacklog e)
        {
            _stories.RemoveAll(s => s.EntityId == e.EntityId);
        }

        private void OnProductBacklogRenamed(ProductBacklogRenamed e)
        {
            _name = e.NewName;
        }
    }
}
