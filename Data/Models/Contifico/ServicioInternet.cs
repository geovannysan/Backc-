using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.Contifico
{
    public class ServicioInternet
    {
        public int porcentaje_iva { get; set; }
    public string? costo_maximo { get; set; }
    public string? imagen { get; set; }
    public string? minimo { get; set; }
    public string? descripcion { get; set; }
    public bool generacion_automatica { get; set; }
    public string? cuenta_costo_id { get; set; }
    public string? pvp2 { get; set; }
    public bool pvp_manual { get; set; }
    public string? tipo { get; set; }
    public string? estado { get; set; }
    public string? fecha_creacion { get; set; }
    public string? id { get; set; }
    public string? tipo_producto { get; set; }
    public string? pvp3 { get; set; }
    public string? codigo_proveedor { get; set; }
    public string? pvp1 { get; set; }
    public string? id_integracion_proveedor { get; set; }
    public string? pvp4 { get; set; }
    public string? nombre { get; set; }
    public string? lead_time { get; set; }
    public string? codigo_barra { get; set; }
    public string? variantes { get; set; }
    public string? cuenta_venta_id { get; set; }
    public string? categoria_id { get; set; }
    public string? peso_hasta { get; set; }
    public string? pvp_peso { get; set; }
    public string? nombre_producto_base { get; set; }
    public string? marca_id { get; set; }
    public string? marca_nombre { get; set; }
    public bool para_pos { get; set; }
    public string? codigo { get; set; }
    public string? personalizado1 { get; set; }
    public string? peso_desde { get; set; }
    public string? personalizado2 { get; set; }
    public string? producto_base_id { get; set; }
    public List<object>? detalle_variantes { get; set; }
    public string? cuenta_compra_id { get; set; }
    public int cantidad_stock { get; set; }
    }
}