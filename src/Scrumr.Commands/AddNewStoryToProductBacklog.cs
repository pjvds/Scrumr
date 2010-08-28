using System;
using Ncqrs.Commanding;

namespace Scrumr.Commands
{
    public class AddNewStoryToProductBacklog : CommandBase
    {
        public Guid ProductId { get; set; }
        public Guid StoryId { get; set; }
        public String StoryDescription { get; set; }
    }
}
