using System.Web.Http;

namespace api.Controllers
{
    public class Version
    {
        public int Software { get; set; }
    }

    public class VersionController : ApiController
    {

        public IHttpActionResult GetVersion()
        {
            var version = new Version(){Software = 1};

            return Ok(version);
        }
    }
}
