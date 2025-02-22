using ExampleWebApi.BusinessLogic.Infraestructura.Options;
using ExampleWebApi.BusinessLogic.Models;
using ExampleWebApi.DataBaseAccess.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.DataBaseAccess
{
    public class ManejoVehiculos : IManejoVehiculos, IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;
        private readonly int _idRandom;

        public ManejoVehiculos(IOptions<OpcionesDeConexion> opcionesConexion, IOptions<Configuracion> config)
        {
            if (config.Value.Variable.Equals("JuanFe"))
            {
                _connectionString = opcionesConexion.Value.ConnectionStringJuanFe;
            }
            else { 
                _connectionString = opcionesConexion.Value.ConnectionStringJuan; 
            }

            _idRandom = new Random().Next(1, 100);
        }

        public SqlConnection OpenConnection()
        {
            _sqlConnection = GetSqlConnection();
            _sqlConnection.Open();
            return _sqlConnection;
        }

        public void Dispose()
        {
            this._sqlConnection?.Dispose();
        }

        public SqlConnection GetSqlConnection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            return _sqlConnection;
        }
    }
}
