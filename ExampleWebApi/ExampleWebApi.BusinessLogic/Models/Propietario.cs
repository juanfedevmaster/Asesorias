using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApi.BusinessLogic.Models
{
    public class Propietario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }


    public abstract class Persona
    {
        public string Id { get; set; }
        public abstract string Profesion { get; set; }
    }

    public class Estudiante : Persona
    {
        public string Nombre { get; set; }
        public override string Profesion { get; set; }
    }

    public class Empleado : Persona
    {
        public override string Profesion { get; set; }
    }

    public class ProgramaPrincipal
    {
        public ProgramaPrincipal()
        {
            Persona p = new Empleado();
            p.Profesion = "Ingeniero";
        }
    }
}
