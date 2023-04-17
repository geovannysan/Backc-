using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Backrest.Data.Models.Files
{
    public class Transacciones
    {
        [Key]
        public int id {get;set;}
        public string? cliente {get;set;}
        public string? idtranse {get;set;}
        public string? factura {get;set;}
        public string? legal {get;set;}
        public string? transacciones {get;set;}
        public string? forma_pago {get;set;}
        public string? Operador{get;set;}
        public string? comision{get;set;}
        public string? neto{get;set;}
        public string? name {get;set;}
        public DateTime fecha {get;set;}
        public string? cobrado {get;set;}
        public string? cedula {get;set;}
    }
}