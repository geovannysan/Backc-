using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models
{
    public class Clienteportal
    {
        public string? estado { get; set; }
        public List<Compos>? datos { get; set; }
         public Facturacion? factura {get;set;}
         public List<Items>? items {get;set;}
         public List<Facturacion>? facturas {get;set;}
      
    }

  
}
