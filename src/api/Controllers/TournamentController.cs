using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OutreachOperations.Api.Controllers
{
    [Produces("application/json")]
    [Route("Tournament")]
    public class TournamentController : Controller
    {
        public class Tournament
        {
            public string Name { get; set; }

        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateTournaments([FromBody] Tournament request)
        {
            return Ok();
        }

    }
}