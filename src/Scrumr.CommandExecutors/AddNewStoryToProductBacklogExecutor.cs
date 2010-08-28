using System;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using Scrumr.Commands;
using Scrumr.Domain;

namespace Scrumr.CommandExecutors
{
    public class AddNewStoryToProductBacklogExecutor : CommandExecutorBase<AddNewStoryToProductBacklog>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, AddNewStoryToProductBacklog command)
        {
            var project = context.GetById<Project>(command.ProductId);
            project.ProductBacklog.AddStory(command.StoryId, command.StoryDescription);

            context.Accept();
        }
    }
}
