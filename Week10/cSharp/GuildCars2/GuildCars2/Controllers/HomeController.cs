using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using bikes.data.Interfaces.Factories;
using bikes.models.Queries;
using GuildCars2.Utilities;
using bikes.data.ADO;
using bikes.models.Tables;
using bikes.models.VMs;
using GuildCars2.Migrations;
using Microsoft.Ajax.Utilities;

namespace GuildCars2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
            }

            var model = BikeRepoFactory.GetRepo().GetFeatured();

            return View(model);
        }

        public ActionResult NewInv()
        {
            ViewBag.Message = "New Inventory page.";
            // Left off here, need to ge a model to send to the NewInv view, which I just added.

            BikeRepoADO repo   = new BikeRepoADO();
            //IEnumerable<BikeShortItem> model = new List<BikeShortItem>();

            //model = repo.Search(new BikeSearchParameters { IsNew = true });
            
            List<DropDownPriceYear> model = new List<DropDownPriceYear>();

            //model.BikeYears = new List<int>();
            //model.BikePrice = new List<decimal>();

            int i = 0;
            for (int theYear = 2000; theYear <= DateTime.Now.Year + 1; theYear++)
            {
                model.Add(new DropDownPriceYear());
                model[i].YearId = theYear;
                model[i].BikeYear = theYear;
                i++;
            }


            return View(model);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //I added user stuff from video 32 below this line.

    }
}