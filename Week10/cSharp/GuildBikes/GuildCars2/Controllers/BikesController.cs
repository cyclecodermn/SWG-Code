﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bikes.data.ADO;
using bikes.data.Interfaces;
using bikes.data.Interfaces.Factories;
using bikes.data.Interfaces.FactoriesFactories;
using bikes.models.Tables;
using bikes.models.VMs;
using GuildBikes.Utilities;

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

            model = ModelUtilities.PopulateBikeModel(model);

            return View(model);
        }


        //[Authorize]
        [HttpPost]
        public ActionResult Add(BikeAddViewModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var repo = BikeRepoFactory.GetRepo();

                try
                {
                    //model.Bike.UserId = AuthorizeUtilities.GetUserId(this);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Bike.BikePictName = Path.GetFileName(filePath);
                    }

                    repo.Insert(model.Bike);

                    //return RedirectToAction("Edit", new { id = model.Listing.ListingId });

                    //model = ModelUtilities.PopulateBikeModel(model);
                    //Inserted the line above to fix exception error after sucessfully adding
                    //a new bike.
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

                model = ModelUtilities.PopulateBikeModel(model);

                //var statesRepo = StatesRepositoryFactory.GetRepository();
                //var bathroomRepo = BathroomTypesRepositoryFactory.GetRepository();

                //model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
                //model.BathroomTypes = new SelectList(bathroomRepo.GetAll(), "BathroomTypeId", "BathroomTypeName");

                return View(model);
            }
            model = ModelUtilities.PopulateBikeModel(model);
            // I added the line above as an intermedite step to fix an err:
            // Remove the line in future revisions
            return View(model);
            //// I added the line above as an intermedite step to fix the err:
            /// Not all paths return something.
            /// >>>---> Remove the line above soon
        }


    }
}