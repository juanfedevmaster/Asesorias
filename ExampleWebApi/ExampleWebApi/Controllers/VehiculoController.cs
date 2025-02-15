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
            return creado == 1 ? Ok(new { message = "El vehículo se creo correctamente" }) : StatusCode(500, new { message = "No se pudo crear el vehículo" });
        }

        [HttpPut]
        public IActionResult ActualizarVehiculo(Vehiculo vehiculo)
        {
            VehiculosAccesoDatos vehiculosAccesoDatos = new VehiculosAccesoDatos();
            //vehiculosAccesoDatos.ActualizarVehiculo(vehiculo);
            return Ok();
        }

        [HttpDelete]
        public IActionResult EliminarVehiculo(BigInteger idVehiculo)
        {
            VehiculosAccesoDatos vehiculosAccesoDatos = new VehiculosAccesoDatos();
            //vehiculosAccesoDatos.EliminarVehiculo(idVehiculo);
            return Ok();
        }
    }
}
