using System;
using Ncqrs.Eventing.Sourcing;

namespace Scrumr.Events.Project
{
    /// <summary>
    /// Represents the creation of a new project.
    /// </summary>
    public class NewProjectCreated : SourcedEvent
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        /// <value>The project id.</value>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        public string ShortCode { get; set; }

        public NewProjectCreated()
        {
            
        }

        public NewProjectCreated(Guid projectId, string name, string shortCode)
        {
            ProjectId = projectId;
            Name = name;
            ShortCode = shortCode;
        }
    }
}
