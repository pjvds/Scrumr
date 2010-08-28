using System;
using System.Web.Hosting;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Config.StructureMap;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.Storage.SQL;
using Scrumr.CommandExecutors;
using Scrumr.Commands;
using Ncqrs.Eventing.Storage;
using Scrumr.CommandService.Properties;
using Ncqrs.Eventing.Storage.NoDB;
using System.IO;
using Ncqrs.Eventing.ServiceModel.Bus;
using Scrumr.Web.MainSite.ReadModel.Denormalizer;

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
                c.For<IEventBus>().Use(BuildEventBus);
            });
            
            NcqrsEnvironment.Configure(config);
        }

        private static ICommandService BuildCommandService()
        {
            var commandAssembly = typeof (CreateNewProject).Assembly;

            var service = new Ncqrs.Commanding.ServiceModel.CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);

            // TODO: Create something that auto scans assembly.
            service.RegisterExecutor(new AddNewStoryToProductBacklogExecutor());

            return service;
        }

        private static IEventStore BuildEventStore()
        {
            var path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data\\EventStore");
            var store = new NoDBEventStore(path);
            return store;
        }

        private static IEventBus BuildEventBus()
        {
            var denormalizerAssembly = typeof (ProjectDenormalizer).Assembly;

            var bus = new InProcessEventBus();
            bus.RegisterAllHandlersInAssembly(denormalizerAssembly);

            return bus;
        }
    }
}
