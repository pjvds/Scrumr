using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Domain;

namespace Scrumr.CommandService.Mappings
{
    public abstract class MappingFor<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        protected MappedCommandToAggregateRootConstructor<TCommand, TAggregateRoot> MapCreate<TCommand>(Func<TCommand, TAggregateRoot> createCallback) where TCommand : ICommand
        {
            return Ncqrs.Commanding.CommandExecution.Mapping.Fluent.Map.Command<TCommand>().ToAggregateRoot<TAggregateRoot>().CreateNew(createCallback);
        }

        protected MappedCommandToAggregateRoot<TCommand, TAggregateRoot> Map<TCommand>() where TCommand : ICommand
        {
            return Ncqrs.Commanding.CommandExecution.Mapping.Fluent.Map.Command<TCommand>().ToAggregateRoot<TAggregateRoot>();
        }

        public abstract void RegisterExecutors(Ncqrs.Commanding.ServiceModel.CommandService service);
    }
}
