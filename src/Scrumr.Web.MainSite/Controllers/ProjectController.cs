using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrumr.Commands;
using Scrumr.Web.MainSite.Commanding;
using Scrumr.Web.MainSite.ReadModel;

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

            return RedirectToAction("Details", new {cmd.ProjectId});
        }

        public ActionResult Details(Guid projectId)
        {
            using(var context = new ReadModelContainer())
            {
                var model = context.ProjectModels.Single(p => p.Id == projectId);
                return View(model);
            }
        }
    }
}
