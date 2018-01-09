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
        public IHttpActionResult searchAncestry(string key, bool male=false, bool female=false)
        {

            return Ok();
        }
    }
}
