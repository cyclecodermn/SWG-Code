using DvdListService1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdListService1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(DvdRepoMock.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            DVD found = DvdRepoMock.Get(id);

            if (found == null)
                return NotFound();

            return Ok(found);
        }

        [Route("dvd/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD dvd)
        {
            DvdRepoMock.Create(dvd);

            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, DVD dvd)
        {
            DvdRepoMock.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            DvdRepoMock.Delete(id);
        }
    }

}
