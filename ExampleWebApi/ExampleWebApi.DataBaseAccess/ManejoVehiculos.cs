using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.DataBaseAccess
{
    public class ManejoVehiculos
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public ManejoVehiculos()
        {
            _connectionString = "Server=JUANFE;Database=ManejoVehiculos;User Id=sa;Password=admin;TrustServerCertificate=True;";
        }

        public SqlConnection OpenConnection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
            return _sqlConnection;
        }

        public void Dispose()
        {
            this._sqlConnection?.Dispose();
        }
    }
}
