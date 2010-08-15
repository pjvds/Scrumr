using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrumr.Commands;
using Scrumr.Web.MainSite.Commanding;

namespace Scrumr.Web.MainSite.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Create()
        {
            var cmd = new CreateNewProject();
            cmd.ProjectId = Guid.NewGuid();
           
            return View(cmd);
        }

        [HttpPost]
        public ActionResult Create(CreateNewProject cmd)
        {
            var service = new ScrumrCommandServiceClient();
            service.ExecuteCommand(cmd);
            return View();
        }
    }
}
