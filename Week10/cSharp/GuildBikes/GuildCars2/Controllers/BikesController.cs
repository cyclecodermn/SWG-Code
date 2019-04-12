using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bikes.data.ADO;
using bikes.data.Interfaces;
using bikes.data.Interfaces.Factories;
using bikes.data.Interfaces.FactoriesFactories;
using bikes.models.Tables;
using bikes.models.VMs;

namespace GuildBikes.Controllers
{
    public class BikesController : Controller
    {
        // GET: Bikes
        public ActionResult Details(int id)
        {
            var repo = BikeRepoFactory.GetRepo();
            var model = repo.GetById(id);

            return View(model);
        }

        public ActionResult Add()
        {
            BikeAddViewModel model = new BikeAddViewModel();
            model.BikeGearItems = new List<SelectListItem>();

            model.FrameColorItems = new List<SelectListItem>();

            var MakeRepo = MakeRepoFactory.GetRepo();
            var ModelRepo = ModelRepoFactory.GetRepo();

            //List<string> Colors = new List<string>()
            //    {"Red", "Blue", "Yellow", "Orange", "Green", "Purple", "Black", "White"};


            List<int> Years = new List<int>();
            //List<SelectListItem> model.BikeGears = new List<SelectListItem>();
            List<int> Condition = new List<int>();

            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year + 1; i++)
                Years.Add(i);

            for (int i = 1; i <= 32; i++)
                model.BikeGearItems.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });


            string[] theColors = { "Red", "Blue", "Yellow", "Orange", "Green", "Purple", "Black", "White" };
            for (int i = 1; i <= 7; i++)
            {
                model.FrameColorItems.Add(new SelectListItem() { Value = i.ToString(), Text = theColors[i] });
            }

            for (int i = 1; i <= 10; i++)
                Condition.Add(i);


            model.BikeMakes = new SelectList(MakeRepo.GetAll(), "BikeMakeId", "BikeMake");
            model.BikeModels = new SelectList(ModelRepo.GetAll(), "BikeModelId", "BikeModel");


            //model.BikeColors = new SelectList(Colors, "BikeColorId", "BikeColor");


            model.BikeYears = new SelectList(Years, "BikeYearId", "BikeYear");
            //model.BikeGears = new SelectList();

            model.Bike = new BikeTable();

            return View(model);
        }

    }
}