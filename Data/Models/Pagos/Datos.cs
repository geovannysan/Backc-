using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Backrest.Data.Models.Pagos
{
    public class Datos
    {
        [BindRequired]
        public string idfactura { get; set; }
        [BindRequired]
        public string pasarela { get; set; }
        [BindRequired]
        public string cantidad { get; set; }

        [BindRequired]
        public string idtransaccion { get; set; }
        public string nota{get;set;}
    }
}
