using ExampleWebApi.BusinessLogic.Models;
using ExampleWebApi.DataBaseAccess.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ExampleWebApi.DataBaseAccess.Tables
{
    public class VehiculosAccesoDatos
    {
        private readonly IManejoVehiculos _manejoVehiculos;

        public VehiculosAccesoDatos(IManejoVehiculos manejoVehiculos)
        {
            _manejoVehiculos = manejoVehiculos;
        }

        public List<Vehiculo> GetVehiculos(int? tipoVehiculo, string placa, string marca)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            var connection = _manejoVehiculos.OpenConnection();

            var sqlCommand = new SqlCommand("ObtenerVehiculosPorParametro", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("TipoVehiculo", SqlDbType.Int) { Value = tipoVehiculo });
            sqlCommand.Parameters.Add(new SqlParameter("Placa", SqlDbType.NVarChar, 20) { Value = placa });
            sqlCommand.Parameters.Add(new SqlParameter("Marca", SqlDbType.NVarChar, 20) { Value = marca });

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.ID_Vehiculo = Convert.ToInt32(reader["ID_Vehiculo"]);
                vehiculo.ID_Propietario = Convert.ToInt32(reader["ID_Propietario"]);
                vehiculo.ID_Modelo = Convert.ToInt32(reader["ID_Modelo"]);
                vehiculo.ID_TipoVehiculo = Convert.ToInt32(reader["ID_Tipo_Vehiculo"]);
                vehiculo.Propietario = reader["Propietario"].ToString();
                vehiculo.Placa = reader["Placa"].ToString();
                vehiculo.Año = Convert.ToInt32(reader["Año"]);
                vehiculo.TipoVehiculo = reader["TipoVehiculo"].ToString();
                vehiculo.Marca = reader["Marca"].ToString();
                vehiculo.Modelo = reader["Modelo"].ToString();
                vehiculo.ID_Marca = Convert.ToInt32(reader["ID_Marca"]);

                vehiculos.Add(vehiculo);
            }

            return vehiculos;
        }

        public int CrearVehiculo(Vehiculo vehiculo)
        {
            try
            {
                var connection = _manejoVehiculos.OpenConnection();
                var sqlCommand = new SqlCommand("CrearVehiculo", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("Placa", SqlDbType.NVarChar, 20) { Value = vehiculo.Placa });
                sqlCommand.Parameters.Add(new SqlParameter("Año", SqlDbType.Int) { Value = vehiculo.Año });
                sqlCommand.Parameters.Add(new SqlParameter("ID_TipoVehiculo", SqlDbType.Int) { Value = vehiculo.ID_TipoVehiculo });
                sqlCommand.Parameters.Add(new SqlParameter("ID_Propietario", SqlDbType.Int) { Value = vehiculo.ID_Propietario });
                sqlCommand.Parameters.Add(new SqlParameter("ID_Modelo", SqlDbType.Int) { Value = vehiculo.ID_Modelo });

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool EliminarVehiculo(string placa)
        {
            var connection = _manejoVehiculos.OpenConnection();
            var sqlCommand = new SqlCommand("EliminarVehiculo", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("Placa", SqlDbType.NVarChar, 20) { Value = placa });
            var respuesta = sqlCommand.ExecuteNonQuery();

            return respuesta > 0 ? true : false;
        }

        public bool ActualizarVehiculo(Vehiculo vehiculo)
        {
            var connection = _manejoVehiculos.OpenConnection();
            var sqlCommand = new SqlCommand("ActualizarVehiculo", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("Placa", SqlDbType.NVarChar, 20) { Value = vehiculo.Placa });
            sqlCommand.Parameters.Add(new SqlParameter("Año", SqlDbType.Int) { Value = vehiculo.Año });
            sqlCommand.Parameters.Add(new SqlParameter("ID_Tipo_Vehiculo", SqlDbType.Int) { Value = vehiculo.ID_TipoVehiculo });
            sqlCommand.Parameters.Add(new SqlParameter("ID_Propietario", SqlDbType.Int) { Value = vehiculo.ID_Propietario });
            sqlCommand.Parameters.Add(new SqlParameter("ID_Modelo", SqlDbType.Int) { Value = vehiculo.ID_Modelo });
            
            var resultado = sqlCommand.ExecuteNonQuery();
            
            return resultado > 0 ? true : false;
        }
    }
}
