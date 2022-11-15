using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Context
{
    public class ExodoDbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration _configuration;

        public ExodoDbSession(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = new SqlConnection(_configuration.GetConnectionString("DbSession"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
