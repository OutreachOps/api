using Microsoft.Extensions.Configuration;
using OutreachOperations.Api.Controllers;
using OutreachOperations.Api.Infrastructure;
using Xunit;

namespace OutreachOperations.Api.Test.Infrastructure
{
    public class DapperRepositoryFixture : DatabaseFixtureBase
    {
        [Fact(Skip = "Need to upgrade to .Net Core 2.1 sdk which supports enrolling in an ambient transaction")]
        public void Test()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

//            var dapperRepository = new DapperRepository(config[""]);
//            dapperRepository.Configuration = config;
//
//            var id = dapperRepository.Insert(new Version {DatabaseVersion = "A unit test version"});
            
        }
    }
}
