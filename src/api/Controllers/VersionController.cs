using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using Dapper.Contrib.Extensions;

namespace api.Controllers
{


    public class Version
    {
        [Key]
        public int VersionId { get; set; }
        public string DatabaseVersion { get; set; }

        [Computed]
        public string SoftwareVersion { get; set; }
    }

    public class VersionController : ApiController
    {

        public IHttpActionResult GetVersion()
        {


            Version item = null;
            try
            {
                var connectionstring = ConfigurationManager.ConnectionStrings["ReadWriteConnectionString"];
                using (IDbConnection sqlConnection = new SqlConnection(connectionstring.ConnectionString))
                {
                    sqlConnection.Open();

                    item = sqlConnection.Get<Version>(1);

                    sqlConnection.Insert(new Version {DatabaseVersion = "A New DatabaseVersion"});

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
