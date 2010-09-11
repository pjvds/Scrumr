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
        public ActionResult Create(CreateNewProject createCommand)
        {
            var service = new ScrumrCommandServiceClient();
            var sprintId = Guid.NewGuid();

            service.ExecuteCommand(createCommand);
            service.ExecuteCommand(new AddNewSprintToProject(createCommand.ProjectId, sprintId, "Sprint 0", DateTime.UtcNow, DateTime.UtcNow.AddDays(7 * 4)));
            service.ExecuteCommand(new StartSprint(createCommand.ProjectId, sprintId));

            return RedirectToAction("ScrumBoard", new {createCommand.ProjectId});
        }

        public ActionResult AddTaskToStory(Guid projectId, Guid sprintId, Guid stageId, Guid storyId, String description)
        {
            var taskId = Guid.NewGuid();
            var cmd = new AddNewTaskToStory(projectId, sprintId, stageId, storyId, taskId, description);
            var service = new ScrumrCommandServiceClient();
            service.ExecuteCommand(cmd);

            return Json(taskId);
        }

        public ActionResult AddStory(Guid projectId, Guid sprintId, string description)
        {
            Guid storyId = Guid.NewGuid();
            var cmd = new AddNewStoryToSprint(projectId, sprintId, storyId, description);
            var service = new ScrumrCommandServiceClient();
            service.ExecuteCommand(cmd);

            return Json(storyId);
        }

        public ActionResult ScrumBoard(Guid sprintId)
        {
            using(var context = new ReadModelContainer())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                context.ContextOptions.ProxyCreationEnabled = false;

                var sprint = context.Sprints.Include("Stages").Include("Stories").Include("Stories.Tasks").Single
                (
                    s => s.Id == sprintId
                );

                return View(sprint);
            }
        }

        [HttpPost]
        public void MoveTask(MoveTaskToStage cmd)
        {
            //var service = new ScrumrCommandServiceClient();
            //service.ExecuteCommand(cmd);
        }
    }
}
