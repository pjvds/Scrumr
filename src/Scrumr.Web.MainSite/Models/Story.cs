using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scrumr.Web.MainSite.Models
{
    public class Story
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; private set; }
        
        public Story(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }
    }
}
