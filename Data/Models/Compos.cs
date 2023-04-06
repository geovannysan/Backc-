using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models
{
    public class Compos 
    {
        public string? id { get; set; }
        public string? nombre { get; set; }
        public string? estado { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
        public string? movil { get; set; }
        public string? cedula { get; set; }
        public string? pasarela { get; set; }
        public string? codigo { get; set; }
        public string? direccion_principal { get; set; }
        public string? Referencia_de_Vivienda { get; set; }
        public string? Tipo_de_Servicio { get; set; }
        public string? Serial_de_Equipos { get; set; }
        public string? INSTALADOR { get; set; }
        public string? MODELO_DE_EQUIPO { get; set; }
        public string? Referencia_Personal { get; set; }
        public string? Referencia_Familiar { get; set; }
        public string? ID_EXTERNO_ONU { get; set; }
        public string? Serial_Equipo_Wifi { get; set; }
        public string? Inteface_GPON { get; set; }
        public string? Ap_Asociado { get; set; }
        public string? Mac_Antena { get; set; }
        public string? ID_EXTERNO_ANTENA { get; set; }
        public string? Telefonos_Adicionales { get; set; }
        public string? ID_Ap_Asociado { get; set; }
        public string? mantenimiento { get; set; }
        public string? fecha_suspendido { get; set; }
        
        public List<Servicios>? servicios { get; set; }
        public Facturacion? facturacion {get;set;} 
       
       

       
    }
}
