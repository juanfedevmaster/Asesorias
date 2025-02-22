using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.BusinessLogic.Models
{
    public class Vehiculo
    {
        public Vehiculo() { }

        public int? ID_Vehiculo { get; set; }
        public string Placa { get; set; }
        public int? Año { get; set; }
        public string? TipoVehiculo { get; set; }  
        public string? Propietario { get; set; }   
        public string? Modelo { get; set; }        
        public string? Marca { get; set; }

        public int? ID_TipoVehiculo { get; set; }
        public int? ID_Propietario { get; set; }
        public int? ID_Modelo { get; set; }
        public int? ID_Marca { get; set; }

    }

}
