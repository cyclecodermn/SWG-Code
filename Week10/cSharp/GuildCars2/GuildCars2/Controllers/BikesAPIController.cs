using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bikes.data.ADO;
using bikes.data.Interfaces;
using bikes.data.Interfaces.FactoriesFactories;
using bikes.models.Tables;

namespace GuildCars2.Controllers
{
    public class BikesAPIController : ApiController
    {
//        private static IDvdRepository _repo = DvdFactory.Create();
        //private IModelRepo _ModelRepo = ModelRepoFactory.GetRepo();
        //[Route("dvds/{category}/{term}")]




        [Route("api/model/add/{newModel}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddModel(BikeModelTable newModel)
        {
            var repo = ModelRepoFactory.GetRepo();
            try
            {
                repo.Insert(newModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/model/getall/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllModels()
        {
            var repo = ModelRepoFactory.GetRepo();
            try
            {
                return Ok(repo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("api/model/add/{newMake}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddMake(BikeMakeTable newMake)
        {
            var repo = MakeRepoFactory.GetRepo();
            try
            {
                repo.Insert(newMake);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}
