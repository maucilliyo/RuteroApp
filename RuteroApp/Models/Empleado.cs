using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RuteroApp.Models
{
    public class Empleado
    {
        [Key]
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}
