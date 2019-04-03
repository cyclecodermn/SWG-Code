﻿using System;
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


            return View();
        }

        [Route("~/Home/Contact/{serialNo?}")]
        public ActionResult Contact(string serialNo)
        {
            ViewBag.Message = "Your contact page.";

            return View(serialNo as object);
        }

        //I added user stuff from video 32 below this line.

    }
}