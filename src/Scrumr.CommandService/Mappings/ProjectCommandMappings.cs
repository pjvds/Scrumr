using System;
using Scrumr.Commands;
using Scrumr.Domain;
using Ncqrs.Commanding.CommandExecution.Mapping;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;

namespace Scrumr.CommandService.Mappings
{
    //public class ProjectMappings : MappingFor<Project>
    //{
    //    public override void RegisterExecutors(Ncqrs.Commanding.ServiceModel.CommandService service)
    //    {
    //        MapCreate<CreateNewProject>((c) => new Project(c.ProjectId, c.Name, c.ShortCode));
    //        Map<AddNewSprintToProject>().WithId()
    //    }
    //}

    //public class ProjectCommandMappings
    //{
    //    public void AddExecutorsToService(Ncqrs.Commanding.ServiceModel.CommandService service)
    //    {
    //        service.RegisterExecutor(
    //            Map.Command<CreateNewProject>()
    //                .ToAggregateRoot<Project>()
    //                .CreateNew(c => new Project(c.ProjectId, c.Name, c.ShortCode)));

    //        Map
    //            .Command<AddNewSprintToProject>()
    //            .ToAggregateRoot<Project>()
    //            .WithId(c => c.ProjectId)
    //            .ToCallOn((c, a) => a.AddSprint(c.SprintId, c.Name, c.From, c.To));

    //        Map
    //            .Command<ChangeProductBacklogStoryDescription>()
    //            .ToAggregateRoot<Project>()
    //            .WithId(c=>c.ProjectId)
    //            .ToCallOn((c,a)=>a.ProductBacklog.Stories.Where(s=> s.Renamed(c.NewDescription)))
    //    }
    //}
}