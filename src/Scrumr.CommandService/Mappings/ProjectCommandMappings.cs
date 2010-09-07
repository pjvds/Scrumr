using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Scrumr.Commands;
using Scrumr.Domain;
using Ncqrs.Commanding;

namespace Scrumr.CommandService.Mappings
{
    public class ProjectCommandMappings
    {
        //public IEnumerable<ICommandExecutor<ICommand>> Test()
        //{
        //    yield return Map
        //        .Command<CreateNewProject>()
        //        .ToAggregateRoot<Project>()
        //        .CreateNew(c => new Project(c.ProjectId, c.Name));

        //    yield return Map
        //        .Command<AddNewStoryToProductBacklog>()
        //        .ToAggregateRoot<Project>()
        //        .WithId(c => c.ProductId)
        //        .ToCallOn((c, a) => a.ProductBacklog.AddStory(c.StoryId, c.StoryDescription));

        //    //yield return Map
        //    //    .Command<ChangeProductBacklogStoryDescription>()
        //    //    .ToAggregateRoot<Project>()
        //    //    .WithId(c=>c.ProjectId)
        //    //    .ToCallOn((c,a)=>a.ProductBacklog.Stories.Where(s=> s.Renamed(c.NewDescription)))
        //}
    }
}