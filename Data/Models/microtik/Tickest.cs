using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.microtik
{
    public class Tickest
    {
         
        public string? id { get; set; }
        public string? idcliente { get; set; }
        public string? idsoporte { get; set; }
        public string? asunto { get; set; }
        public string? fecha_soporte { get; set; }
        public string? estado { get; set; }
        public string? fecha_cerrado { get; set; }
        public string? solicitante { get; set; }
        public string? fechavisita { get; set; }
        public string? turno { get; set; }
        public string? agendado { get; set; }
        public string? lastdate { get; set; }
        public string? dp { get; set; }
        public string? motivo_cierre { get; set; }
        public string? oculto { get; set; }
        public List<Mensajes>? mensajes{get;set;}
        
    }
}
