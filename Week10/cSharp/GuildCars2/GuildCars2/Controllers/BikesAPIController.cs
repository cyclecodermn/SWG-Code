using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bikes.data.Factories;

namespace GuildCars2.Controllers
{
    public class BikesAPIController : ApiController
    {
        [Route("api/contact/add/{userId]/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(string userId)
        {
            var repo = AccountRepoFactory.GetRepository();

            try
            {
                repo.AddContact(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/contact/remove/{userId]/")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult RemoveContact(string userId)
        {
            var repo = AccountRepoFactory.GetRepository();

            try
            {
                repo.RemoveContact(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}