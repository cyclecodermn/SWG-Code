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

        [Route("dvds/{category}/{term}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetaByTerm(string category, string term)
        {
            IEnumerable<DVD> found = GetSearchResults(category, term);

            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        List<DVD> GetSearchResults(string category, string term)
        {
            List<DVD> foundList = new List<DVD>();

            foreach (DVD dvd in DvdRepoMock.GetAll())
            {
                switch (category)
                {
                    case "title":
                        if (dvd.Title.Contains(term))
                        {
                            foundList.Add(dvd);
                        }
                        break;
                    case "year":
                        if (dvd.realeaseYear.ToString().Contains(term.ToString()))
                        {
                            foundList.Add(dvd);
                        }
                        break;
                    case "director":
                        if (dvd.Director.Contains(term))
                        {
                            foundList.Add(dvd);
                        }
                        break;
                    case "rating":
                        if (dvd.Rating.Contains(term))
                        {
                            foundList.Add(dvd);
                        }
                        break;
                    default:
                        return null;
                }
            }
            return foundList;
        }


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
