using System;
using Ncqrs.Eventing.ServiceModel.Bus;
using Scrumr.Events.Project;

namespace Scrumr.Web.MainSite.ReadModel.Denormalizer
{
    public class ProjectDenormalizer : IEventHandler<NewProjectCreated>
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
    }
}