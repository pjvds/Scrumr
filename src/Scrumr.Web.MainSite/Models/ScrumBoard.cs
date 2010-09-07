using System;
using System.Collections.Generic;

namespace Scrumr.Web.MainSite.Models
{
    public class ScrumBoard
    {
        private static ScrumBoard SampleBoard;

        public List<Stage> Stages
        {
            get; private set;
        }

        public ScrumBoard()
        {
            Stages = new List<Stage>();
        }

        public static ScrumBoard GetSample()
        {
            if (SampleBoard == null)
            {
                SampleBoard = new ScrumBoard();
                SampleBoard.Stages.Add(new Stage("To do"));
                SampleBoard.Stages.Add(new Stage("In Process"));
                SampleBoard.Stages.Add(new Stage("Verify"));
                SampleBoard.Stages.Add(new Stage("Done"));
            }

            return SampleBoard;
        }
    }
}