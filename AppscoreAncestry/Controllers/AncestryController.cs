using AppscoreAncestry.DataLayer;
using AppscoreAncestry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppscoreAncestry.Controllers
{
    [Route("api/Ancestry")]
    public class AncestryController : ApiController
    {
        // GET: api/ancestry/search
        [HttpGet]
        [Route("api/Ancestry/search")]
        //public IHttpActionResult searchAncestry([FromBody]string key, [FromBody]bool male, [FromBody]bool female)
        public IHttpActionResult searchAPeople(string key, bool male=false, bool female=false, int pageRequired=1)
        {
            IEnumerable<Person> people = Datastore.Instance.People;
            string genderKey = "";
            if (male && !female)
                genderKey = "M";
            else if (!male && female)
                genderKey = "F";

            IEnumerable<Person> selected;
            if (string.IsNullOrEmpty(genderKey))
            {
                selected = (from p in people
                            where p.name.Contains(key)
                            select p);
            }
            else
            {
                selected = (from p in people
                            where p.name.Contains(key) && p.gender == genderKey
                            select p);
            }

            return Ok(selected.Take(10));
            //return Ok(new { people = selected.Skip(10*(pageRequired-1)).Take(10), page= pageRequired, total_pages=(selected.Count()+9) /10});
        }
    }
}
