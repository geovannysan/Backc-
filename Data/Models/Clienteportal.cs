using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backrest.Data.Models.microtik;

namespace Backrest.Data.Models
{
    public class Clienteportal
    {
        public string? estado { get; set; }
        public List<Compos>? datos { get; set; }
        public Facturacion? factura { get; set; }
        public List<Items>? items { get; set; }
        public List<Facturacion>? facturas { get; set; }
        
        public string? mensaje { get; set; }
        public string? idregistro { get; set; }
        public List<Instalaciones>? instalaciones { get; set; }
        public List<Router>?routers{get;set;}
        
       
       
    }
}
