using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace OutreachOperations.Api.Controllers
{
    public class Version
    {
        [Key]
        public int VersionId { get; set; }
        public string DatabaseVersion { get; set; }

        [Computed]
        public string SoftwareVersion { get; set; }
    }


    [Route("version")]
    public class VersionController : Controller
    {
        private readonly IConfigurationRoot _configuration;

        public VersionController()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        [HttpGet]
        public IActionResult GetVersion()
        {
            this._configuration
                .GetConnectionString("DefaultConnection");

            Version item = null;
            try
            {
                var connectionstring = _configuration.GetConnectionString("ReadWriteConnectionString");
                using (IDbConnection sqlConnection = new SqlConnection(connectionstring))
                {
                    sqlConnection.Open();

                    item = sqlConnection.Get<Version>(1);

                    sqlConnection.Close();

                    item.SoftwareVersion = "1";
                }
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
