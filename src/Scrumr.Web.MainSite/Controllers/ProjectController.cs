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

        public ActionResult ScrumBoard()
        {
            using(var context = new ReadModelContainer())
            {
                var sampleBoardId = Guid.Parse("{1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31}");
                context.ContextOptions.LazyLoadingEnabled = false;
                context.ContextOptions.ProxyCreationEnabled = false;

                var sampleBoard = context.Scrumboards.Include("Stages").Include("Stories").Include("Stories.Tasks").Single
                (
                    board => board.Id == sampleBoardId
                );

                sampleBoard.Stages.Load();
                sampleBoard.Stories.Load();

                return View(sampleBoard);
            }
        }

        [HttpPost]
        public void MoveTask(MoveTaskToStage cmd)
        {
            var service = new ScrumrCommandServiceClient();
            service.ExecuteCommand(cmd);
        }
    }
}
