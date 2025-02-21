using ExampleWebApi.BusinessLogic.Models;
using ExampleWebApi.DataBaseAccess.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ExampleWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        public VehiculoController()
        {
        }

        [HttpGet]
        [Route("api/GetVehiculosFiltrado")]
        public IActionResult GetVehiculosFiltrado(
            int? tipoVehiculo = null,
            string placa = null,
            string marca = null)
        {

            VehiculosAccesoDatos vehiculosAccesoDatos = new VehiculosAccesoDatos();

            return Ok(vehiculosAccesoDatos.GetVehiculos(tipoVehiculo, placa, marca));
        }

        [HttpPost]
        [Route("api/CrearVehiculo")]
        public IActionResult CrearVehiculo(Vehiculo vehiculo)
        {
            VehiculosAccesoDatos vehiculosAccesoDatos = new VehiculosAccesoDatos();
            var creado = vehiculosAccesoDatos.CrearVehiculo(vehiculo);
            return creado == 1 ? Ok(new { mensaje = "El vehículo se creo correctamente" }) : StatusCode(500, new { mensaje = "No se pudo crear el vehículo" });
        }

        [HttpPut]
        public IActionResult ActualizarVehiculo(Vehiculo vehiculo)
        {
            VehiculosAccesoDatos vehiculosAccesoDatos = new VehiculosAccesoDatos();
            //vehiculosAccesoDatos.ActualizarVehiculo(vehiculo);
            return Ok();
        }

        [HttpDelete]
        public IActionResult EliminarVehiculo(String placa)
        {
            VehiculosAccesoDatos vehiculosAccesoDatos = new VehiculosAccesoDatos();
            var respuesta = vehiculosAccesoDatos.EliminarVehiculo(placa);
            
            return respuesta ? Ok(new { mensaje = "El vehículo se elimino de forma correcta." }): StatusCode(500, new { mensaje = "No puedes eliminar un vehículo con mantenimiento registrados." });
        }
    }
}
