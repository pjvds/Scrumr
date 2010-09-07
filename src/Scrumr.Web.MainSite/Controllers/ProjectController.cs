using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrumr.Commands;
using Scrumr.Web.MainSite.Commanding;
using Scrumr.Web.MainSite.ReadModel;
using Scrumr.Web.MainSite.Models;

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

        public ActionResult AddNewStory(Guid productId)
        {
            return Json(new AddNewStoryToProductBacklog {ProductId = productId, StoryId = Guid.NewGuid()});
        }

        [HttpPost]
        public ActionResult AddNewStory(AddNewStoryToProductBacklog command)
        {
            return RedirectToAction("Details", new {command.ProductId});
        }

        public ActionResult ScrumBoard()
        {
            return View(Models.ScrumBoard.GetSample());
        }

        [HttpPost]
        public void MoveTask(MoveTaskToStage cmd)
        {
            var service = new ScrumrCommandServiceClient();
            service.ExecuteCommand(cmd);
        }
    }
}
