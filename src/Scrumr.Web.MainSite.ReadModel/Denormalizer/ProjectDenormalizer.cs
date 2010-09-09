using System;
using System.Data.Objects.DataClasses;
using System.Linq;
using Ncqrs.Eventing.ServiceModel.Bus;
using Scrumr.Events.Project;

namespace Scrumr.Web.MainSite.ReadModel.Denormalizer
{
    public class ProjectDenormalizer : IEventHandler<NewProjectCreated>,
        IEventHandler<SprintAddedToProject>, IEventHandler<SprintStarted>, IEventHandler<SprintFinished>, IEventHandler<NewStageAddedToSprint>, IEventHandler<AddNewStoryToSprint>
    {
        public void Handle(NewProjectCreated evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var newProject = new Project
                {
                    Id = evnt.ProjectId,
                    Name = evnt.Name,
                    ShortCode = evnt.ShortCode
                };

                context.AddToProjects(newProject);
                context.SaveChanges();
            }
        }

        public void Handle(SprintAddedToProject evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var newSprint = new Sprint
                    {
                        Id = evnt.SprintId,
                        ProjectId = evnt.ProjectId,
                        Name = evnt.Name,
                        From = evnt.From,
                        To = evnt.To
                    };

                context.AddToSprints(newSprint);
                context.SaveChanges();
            }
        }

        public void Handle(SprintStarted evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var sprint = context.Sprints.Single(s => s.Id == evnt.SprintId);
                sprint.IsActive = true;
            }
        }

        public void Handle(SprintFinished evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var sprint = context.Sprints.Single(s => s.Id == evnt.SprintId);
                sprint.IsActive = false;
            }
        }

        public void Handle(NewStageAddedToSprint evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var sprint = context.Sprints.Single(s => s.Id == evnt.SprintId);
                var newStage = new Stage
                    {
                        Id = evnt.StageId,
                        Name = evnt.Name,
                        Sprint = sprint
                    };

                context.AddToStages(newStage);
                context.SaveChanges();
            }
        }

        public void Handle(AddNewStoryToSprint evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var sprint = context.Sprints.Single(s => s.Id == evnt.SprintId);
                var newStory = new Story
                    {
                        Id = evnt.StoryId,
                        Description = evnt.Description,
                        Sprint =  sprint
                    };

                context.AddToStories(newStory);
                context.SaveChanges();
            }
        }
    }
}