using System;
using System.ServiceModel;
using Ncqrs.Commanding;
using Scrumr.Commands;

namespace Scrumr.CommandService
{
    [ServiceContract]
    [ServiceKnownType(typeof(AddNewSprintToProject))]
    [ServiceKnownType(typeof(CreateNewProject))]
    [ServiceKnownType(typeof(StartSprint))]
    public interface IScrumrCommandService
    {
        [OperationContract]
        void ExecuteCommand(ICommand command);
    }
}
