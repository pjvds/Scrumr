using System;
using Ncqrs.Domain;
using Scrumr.Events.Project;

namespace Scrumr.Domain
{
    public class Sprint : EntityMappedByConvention
    {
        private string _name;
        private DateTime _from;
        private DateTime _to;
        public bool IsActive
        {
            get; private set;
        }

        public Sprint(Project parent, Guid id, string name, DateTime from, DateTime to) : base(parent, id)
        {
        }

        public void Activate()
        {
            ApplyEvent(new SprintActivated());
        }

        public void Deactivate()
        {
            ApplyEvent(new SprintDeactivated());            
        }

        protected void OnActivated(SprintActivated e)
        {
            IsActive = true;
        }

        protected void OnDeactivated(SprintDeactivated e)
        {
            IsActive = false;
        }
    }
}
