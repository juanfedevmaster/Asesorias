using ExampleWebApi.BusinessLogic.Models;
using ExampleWebApi.DataBaseAccess;
using ExampleWebApi.DataBaseAccess.Interfaces;
using ExampleWebApi.DataBaseAccess.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Numerics;

namespace ExampleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly VehiculosAccesoDatos _vehiculosAccesoDatos;
        public VehiculoController(IManejoVehiculos manejoVehiculos)
        {
            _vehiculosAccesoDatos = new VehiculosAccesoDatos(manejoVehiculos);
        }

        [HttpGet]
        [Route("api/GetVehiculosFiltrado")]
        public IActionResult GetVehiculosFiltrado(
            int? tipoVehiculo = null,
            string placa = null,
            string marca = null)
        {

            return Ok(_vehiculosAccesoDatos.GetVehiculos(tipoVehiculo, placa, marca));
        }

        [HttpPost]
        [Route("api/CrearVehiculo")]
        public IActionResult CrearVehiculo(Vehiculo vehiculo)
        {
            var creado = _vehiculosAccesoDatos.CrearVehiculo(vehiculo);
            return creado == 1 ? Ok(new { mensaje = "El vehículo se creo correctamente" }) : StatusCode(500, new { mensaje = "No se pudo crear el vehículo" });
        }

        [HttpPut]
        [Route("api/ActualizarVehiculo")]
        public IActionResult ActualizarVehiculo(Vehiculo vehiculo)
        {
            var respuesta = _vehiculosAccesoDatos.ActualizarVehiculo(vehiculo);
            return respuesta ? Ok(new { mensaje = "El vehículo se actualizo correctamente" }) : StatusCode(500, new { mensaje = $"El vehículo de placas {vehiculo.Placa} no exite." });
        }

        [HttpDelete]
        public IActionResult EliminarVehiculo(String placa)
        {
            var respuesta = _vehiculosAccesoDatos.EliminarVehiculo(placa);

            return respuesta ? Ok(new { mensaje = "El vehículo se elimino de forma correcta." }) : StatusCode(500, new { mensaje = "No puedes eliminar un vehículo con mantenimiento registrados." });
        }
    }
}
