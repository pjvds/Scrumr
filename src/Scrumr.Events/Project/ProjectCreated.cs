using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    /// <summary>
    /// Represents the creation of a new project.
    /// </summary>
    public class NewProjectCreated : ProjectEvent
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        public NewProjectCreated()
        {
            
        }

        public NewProjectCreated(string name)
        {
            Name = name;
        }
    }
}
