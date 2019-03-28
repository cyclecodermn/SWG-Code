using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bikes.data.Interfaces.Factories;

namespace GuildCars2.Controllers
{
    public class BikesController : Controller
    {
        // GET: Bikes
        public ActionResult Details(int id)
        {
            var repo = BikesRepoFactory.GetRepo();
            var model = repo.GetById(id);

            return View(model);
        }
    }
}