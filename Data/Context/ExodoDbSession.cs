using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Context
{
    public class ExodoDbSession
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration _configuration;

        public ExodoDbSession()
        {
            Connection = new SqlConnection(_configuration.GetConnectionString("ExodoDev"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
