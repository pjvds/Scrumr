using System;
using System.Collections.Generic;

namespace Scrumr.Web.MainSite.Models
{
    public class ScrumBoard
    {
        private static ScrumBoard SampleBoard;

        public List<Story> Stories
        {
            get;
            private set;
        }

        public List<Stage> Stages
        {
            get;
            private set;
        }

        public ScrumBoard()
        {
            Stories = new List<Story>();
            Stages = new List<Stage>();
        }

        public static ScrumBoard GetSample()
        {
            if (SampleBoard == null)
            {
                SampleBoard = new ScrumBoard();

                var todo = new Stage("To do");
                var inProgress = new Stage("In Progress");
                var verify = new Stage("Verify");
                var done = new Stage("Done");

                SampleBoard.Stages.Add(todo);
                SampleBoard.Stages.Add(inProgress);
                SampleBoard.Stages.Add(verify);
                SampleBoard.Stages.Add(done);

                var story1 = new Story("Story 1");
                story1.Tasks.Add(new Task("Task 1", todo));
                SampleBoard.Stories.Add(story1);

                var story2 = new Story("Story 2");
                story2.Tasks.Add(new Task("Task 1", done));
                story2.Tasks.Add(new Task("Task 2", inProgress));
                SampleBoard.Stories.Add(story2);
            }

            return SampleBoard;
        }
    }
}