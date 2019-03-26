using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bikes.data.Interfaces.Factories;

namespace GuildCars2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = BikesRepoFactory.GetRepo().GetFeatured();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}