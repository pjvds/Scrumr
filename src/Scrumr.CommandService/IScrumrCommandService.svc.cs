using System;
using System.Collections.Generic;
using System.ServiceModel;
using Ncqrs;
using Ncqrs.Commanding;
using Ncqrs.Commanding.ServiceModel;
using Scrumr.Commands;
using Scrumr.CommandServicing;

namespace Scrumr.CommandService
{

    public class ScrumrCommandService : IScrumrCommandService
    {
        static ScrumrCommandService()
        {
            Bootstrapper.BootUp();
        }

        public void ExecuteCommand(ICommand command)
        {
            var service = NcqrsEnvironment.Get<ICommandService>();
            service.Execute(command);
        }
    }
}
