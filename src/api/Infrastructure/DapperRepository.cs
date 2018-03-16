using System;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using OutreachOperations.Api.Domain;

namespace OutreachOperations.Api.Infrastructure
{
    public class DapperRepository : IRepository
    {
        public IConfiguration Configuration { get; set; }


        public long Insert<T>(T item) where T : class
        {
            long id;
            var connectionstring = Configuration.GetConnectionString("ReadWriteConnectionString");
            using (IDbConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();

                id = sqlConnection.Insert(item);

                sqlConnection.Close();
            }

            return id;
        }

        public void Remove<T>(T item)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item)
        {
            throw new NotImplementedException();
        }

        public T FindById<T>(int id) where T : class
        {
            T item;
            var connectionstring = Configuration.GetConnectionString("ReadWriteConnectionString");
            using (IDbConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();

                item = sqlConnection.Get<T>(id);

                sqlConnection.Close();
            }

            return item;
        }
    }
}