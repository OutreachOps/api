using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using OutreachOperations.Api.Domain.Security;

namespace OutreachOperations.Api.Infrastructure
{
    public class FindUserQueryDapper : FindUserQuery
    {
        private readonly IConfiguration _configuration;

        public FindUserQueryDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public User Execute(string userName)
        {
            List<User> users;

            var connectionstring = _configuration.GetConnectionString("ReadWriteConnectionString");
            using (IDbConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();

                users = sqlConnection.Query<User>($"SELECT * FROM Users WHERE UserName='{userName}'").ToList();

                sqlConnection.Close();
            }

            return users.Count != 1 ? null : users.First();
        }

        public class FindUserQueryByEmailDapper : FindUserQueryByEmail
        {
            private readonly IConfiguration _configuration;

            public FindUserQueryByEmailDapper(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public User Execute(string emailAddress)
            {
                List<User> users;

                var connectionstring = _configuration.GetConnectionString("ReadWriteConnectionString");
                using (IDbConnection sqlConnection = new SqlConnection(connectionstring))
                {
                    sqlConnection.Open();

                    //                "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID; SELECT * FROM InvoiceItem WHERE InvoiceID = @InvoiceID;"

                    users = sqlConnection.Query<User>($"SELECT * FROM Users WHERE EmailAddress='{emailAddress}'").ToList();

                    sqlConnection.Close();
                }

                return users.Count != 1 ? null : users.First();
            }
        }
    }



}
