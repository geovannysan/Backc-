using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.microtik
{
    public class Info
    {
        public string? abierto {get;set;}
        public string? cerrados {get;set;}
        public string? respondidos{get;set;}
        public string? respuesta_cliente{get;set;}
        public List<Tickest>? tickets{get;set;}
        
    }
    
    public class Infoticket{
    
        public string? estado { get; set; }
         
        public string? mensaje { get; set; }
        
         public Info? data  {get;set;}
       
   
    }
}