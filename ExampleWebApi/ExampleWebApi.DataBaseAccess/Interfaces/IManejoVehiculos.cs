using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.DataBaseAccess.Interfaces
{
    public interface IManejoVehiculos
    {
        SqlConnection GetSqlConnection();
        public SqlConnection OpenConnection();
    }
}
