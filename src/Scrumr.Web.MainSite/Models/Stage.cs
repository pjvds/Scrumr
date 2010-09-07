using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrumr.Web.MainSite.Models
{
    public class Stage
    {
        public String Name { get; set; }
        public List<Task> Tasks { get; private set; }

        public Stage(string name)
        {
            Name = name;
        }
    }
}