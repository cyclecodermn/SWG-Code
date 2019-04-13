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

            var MakeRepo = MakeRepoFactory.GetRepo();
            model.BikeMakes = new SelectList(MakeRepo.GetAll(), "BikeMakeId", "BikeMake");

            var ModelRepo = ModelRepoFactory.GetRepo();
            model.BikeModels = new SelectList(ModelRepo.GetAll(), "BikeModelId", "BikeModel");


            List<int> Condition = new List<int>();

            model.BikeYearItems = new List<SelectListItem>();
            for (int i = DateTime.Now.Year-10; i <= DateTime.Now.Year+1; i++)
                model.BikeYearItems.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });



            model.FrameColorItems = new List<SelectListItem>();
            string[] theColors = { "Red", "Blue", "Yellow", "Orange", "Green", "Purple", "Black", "White" };
            for (int i = 1; i < theColors.Length; i++)
            {
                model.FrameColorItems.Add(new SelectListItem() { Value = i.ToString(), Text = theColors[i] });
            }

            model.FrameItems = new List<SelectListItem>();
            string[] theFrames = { "Hybrid bike", "Mountain bike", "Road bike, aluminum", "Road bike, carbon", "Road bike, steel", "Touring bike" };
            for (int i = 0; i < theFrames.Length; i++)
            {
                model.FrameItems.Add(new SelectListItem() { Value = i.ToString(), Text = theFrames[i] });
            }


            model.ConditionItems = new List<SelectListItem>();
            string[] theConditions = { "1-No scratches", "2", "3", "4", "5-5+ Scratches or nicks","6","7", "8", "9", "10-Barely road-worthy" };
            for (int i = 0; i < theConditions.Length; i++)
            {
                model.ConditionItems.Add(new SelectListItem() { Value = i.ToString(), Text = theConditions[i] });
            }


            model.BikeGearItems = new List<SelectListItem>();
            for (int i = 1; i <= 32; i++)
                model.BikeGearItems.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });

            model.Bike = new BikeTable();

            return View(model);
        }

    }
}