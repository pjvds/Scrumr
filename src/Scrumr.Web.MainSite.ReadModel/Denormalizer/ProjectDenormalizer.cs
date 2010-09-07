using System;
using System.Linq;
using Ncqrs.Eventing.ServiceModel.Bus;
using Scrumr.Events.Project;

namespace Scrumr.Web.MainSite.ReadModel.Denormalizer
{
    public class ProjectDenormalizer : IEventHandler<NewProjectCreated>,
                                       IEventHandler<StoryAddedToProductBacklog>,
                                       IEventHandler<StoryRemovedFromProductBacklog>
    {
        public void Handle(NewProjectCreated evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var newModel = new ProjectModel
                {
                    Id = evnt.ProjectId,
                    Name = evnt.Name
                };

                context.AddToProjectModels(newModel);
                context.SaveChanges();
            }
        }

        public void Handle(StoryAddedToProductBacklog evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var newModel = new StoryModel
                {
                    Id = evnt.StoryId,
                    Description = evnt.Description,
                };

                var project = context.ProjectModels.Single(p => p.Id == evnt.ProjectId);
                project.ProductBacklogStoryModels.Add(newModel);

                context.AddToStoryModels(newModel);
                context.SaveChanges();
            }
        }

        public void Handle(StoryRemovedFromProductBacklog evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var modelToDelete = context.StoryModels.Single(e=> e.Id == evnt.StoryId);
                context.DeleteObject(modelToDelete);

                context.SaveChanges();
            }
        }
    }
}