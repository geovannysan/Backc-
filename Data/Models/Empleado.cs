using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Backrest.Data.Models;
namespace Backrest.Data.Models
{
    
    public class Empleado
    {
        
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public decimal? Sueldo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? edad { get; set; }  
         public string Obtenertoken (int opera){
        return"";
       }
          
    }
    //[JsonIgnore]
    //public virtual ICollection <Cargos> Cargos {get;set;} =null;
    
}