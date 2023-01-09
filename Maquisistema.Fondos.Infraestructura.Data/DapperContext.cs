using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Maquisistema.Fondos.Infraestructura.Data
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration _configuration)
        {
            this.configuration = _configuration;
            this.connectionString = _configuration.GetConnectionString("ComercioConnection").ToString();
        }

        public IDbConnection createConnection() => new SqlConnection(connectionString);

    }
}
