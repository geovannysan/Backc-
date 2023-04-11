using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Backrest.Data.Models.Pagos
{
    public class Datos
    {
        public string? idfactura { get; set; }
     
        public string? pasarela { get; set; }
       
        public string? cantidad { get; set; }

        public string? idtransaccion { get; set; }
        public string? nota{get;set;}
    }
}
