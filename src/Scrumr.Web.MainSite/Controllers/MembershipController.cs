using System;
using System.Web.Mvc;

namespace Scrumr.Web.MainSite.Controllers
{
    public class MembershipController : Controller
    {
        //
        // GET: /Membership/
        public ActionResult Index()
        {
            return base.View();
        }
    }
}
