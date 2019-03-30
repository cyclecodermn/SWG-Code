using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bikes.data.ADO;
using bikes.data.Interfaces.FactoriesFactories;
using bikes.models.Tables;

namespace GuildCars2.Controllers
{
    public class BikesAPIController : ApiController
    {


        //[Route("api/contact/add/{userId}/{listingId}")]
        //[AcceptVerbs("POST")]
        //public IHttpActionResult AddContact(string userId, int listingId)
        //{
        //    var repo = AccountRepositoryFactory.GetRepository();

        //    try
        //    {
        //        repo.AddContact(userId, listingId);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}



        [Route("api/model/add/{newModel}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddModel(string newModel)
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


        


        [Route("api/make/add/{makeId}/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Addmake(string userId, int listingId)
        {
            var repo = ModelRepoFactory.GetRepo();

            try
            {
                repo.GetAll();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
