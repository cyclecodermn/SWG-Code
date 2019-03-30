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






        [Route("api/model/add/{FrameId}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddModel(BikeModelTable NewModel)
        {
            var repo = ModelRepoFactory.GetRepo();
            try
            {
                repo.Insert(NewModel);
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
