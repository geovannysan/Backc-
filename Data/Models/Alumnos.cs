using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models
{
    public class Alumnos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime Fecha { get; set; }
        public int edad { get; set; }
    }
}