using System;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OutreachOperations.Api.Domain;

namespace OutreachOperations.Api.Controllers
{
    public class Version
    {
        [Key]
        public int Id { get; set; }

        public int Major { get; set; }

        public int Minor { get; set; }  

        public int Revision { get; set; }


        [Computed]
        public string SoftwareVersion { get; set; }
    }


    [Route("version")]
    public class VersionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;

        public VersionController(IConfiguration config,IRepository repository)
        {
            _configuration = config;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetVersion()
        {
            Version item = null;
            try
            {
                item = _repository.FindById<Version>(1);
            }
            catch (Exception ex)
            {
                if (item == null)
                    item = new Version();

                item.SoftwareVersion = ex.ToString();
            }

            return Ok(item);
        }
    }
}
