using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using Ncqrs.Commanding;
using Scrumr.Commands;

namespace Scrumr.CommandService
{
    [ServiceContract]
    [ServiceKnownType(typeof(CreateNewProject))]
    public interface IScrumrCommandService
    {
        [OperationContract]
        void ExecuteCommand(ICommand command);
    }
}
