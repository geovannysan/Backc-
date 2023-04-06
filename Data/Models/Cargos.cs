using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backrest.Models;

namespace Backrest.Data.Models
{
    public class Cargos
    {
        public Cargos(){
            Empleados = new HashSet<Empleado>();
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public virtual ICollection <Empleado> Empleados {get;set;}
    }
}