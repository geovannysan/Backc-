using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.microtik
{
    public class Creatickte
    {
        // public string?token {get;set;}
        public string? idcliente { get; set; }

        // "dp": 1,
        public string? asunto { get; set; }
        public string? solicitante { get; set; }
        public string? fechavisita { get; set; }
        public string? turno { get; set; }
        public string? agendado { get; set; }
        public string? contenido { get; set; } //: "Hola,<br> Necesito ayuda para mi conexión de internet."
    }
}
