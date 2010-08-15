using System;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Config.StructureMap;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.Storage.SQL;
using Scrumr.Commands;
using Ncqrs.Eventing.Storage;
using Scrumr.CommandService.Properties;

namespace Scrumr.CommandServicing
{
    public static class Bootstrapper
    {
        public static void BootUp()
        {
            var config = new StructureMapConfiguration(c=>
            {
                c.For<ICommandService>().Use(BuildCommandService);
                c.For<IEventStore>().Use(BuildEventStore);
            });
            
            NcqrsEnvironment.Configure(config);
        }

        private static ICommandService BuildCommandService()
        {
            var commandAssembly = typeof (CreateNewProject).Assembly;

            var service = new Ncqrs.Commanding.ServiceModel.CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);

            return service;
        }

        private static IEventStore BuildEventStore()
        {
            var store = new MsSqlServerEventStore(Settings.Default.EventStoreConnectionString);
            return store;
        }
    }
}
