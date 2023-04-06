using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Contifico;
using Newtonsoft.Json;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactuApiController : ControllerBase
    {
        private readonly HttpClient _httpcliente;
        public string url = "https://0992782129001.contifico.com/sistema/api/v1/producto/";
        public string urlcon="ttps://api.contifico.com/sistema/api/v1/persona/";

        public FactuApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpPost]
        [Route("Crearpersona")]
        public async Task<ActionResult> Get([FromBody] Clientecontifico datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, urlcon + "?pos=<TOKEN>");
                var contents = new StringContent(
                    "{\r\n  \"tipo\": \""
                        + datos.tipo
                        + "\",\r\n"
                        + "  \"personaasociada_id\": \""
                        + datos.personaasociada_id
                        + "\",\r\n"
                        + "  \"nombre_comercial\": "
                        + datos.nombre_comercial
                        + ",\r\n"
                        + "  \"telefonos\": \""
                        + datos.telefonos
                        + "\",\r\n"
                        + "  \"ruc\": \""
                        + datos.ruc
                        + "\",\r\n"
                        + "  \"razon_social\": \""
                        + datos.razon_social
                        + "\",\r\n"
                        + "  \"direccion\": \""
                        + datos.direccion
                        + "\",\r\n"
                        + "  \"es_extranjero\": "
                        + datos.es_extranjero
                        + ",\r\n"
                        + "  \"porcentaje_descuento\": \""
                        + datos.porcentaje_descuento
                        + "\",\r\n"
                        + "  \"es_cliente\": "
                        + datos.es_cliente
                        + ",\r\n"
                        + "  \"id\": "
                        + datos.id
                        + ",\r\n"
                        + "  \"es_empleado\": "
                        + datos.es_empleado
                        + ",\r\n"
                        + "  \"email\": \""
                        + datos.email
                        + "\",\r\n"
                        + "  \"cedula\": \""
                        + datos.cedula
                        + "\",\r\n"
                        + "  \"placa\": \""
                        + datos.placa
                        + "\",\r\n"
                        + "  \"es_vendedor\": "
                        + datos.es_vendedor
                        + ",\r\n"
                        + "  \"es_proveedor\": "
                        + datos.es_proveedor
                        + ",\r\n"
                        + "  \"adicional1_cliente\": "
                        + datos.adicional1_cliente
                        + ",\r\n"
                        + "  \"adicional2_cliente\": "
                        + datos.adicional2_cliente
                        + ",\r\n"
                        + "  \"adicional3_cliente\": "
                        + datos.adicional3_cliente
                        + ",\r\n"
                        + "  \"adicional4_cliente\": "
                        + datos.adicional4_cliente
                        + ",\r\n"
                        + "  \"adicional1_proveedor\": "
                        + datos.adicional1_proveedor
                        + ",\r\n"
                        + "  \"adicional2_proveedor\": "
                        + datos.adicional2_proveedor
                        + ",\r\n"
                        + "  \"adicional3_proveedor\": "
                        + datos.adicional3_proveedor
                        + ",\r\n"
                        + "  \"adicional4_proveedor\": "
                        + datos.adicional4_proveedor
                        + "\r\n}",
                    null,
                    "application/json"
                );
                request.Headers.Add("Authorization", "eYxkPDD5SDLv0nRB7CIKsDCL6dwHppHwHmHMXIHqH8w");
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject(resp);
                    return StatusCode(StatusCodes.Status200OK, new { result });
                }

                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo el Pago" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
        }

        [HttpPost]
        [Route("PagarPRoducto")]
        public async Task<ActionResult> Getintro([FromBody] Producto datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "https://api.contifico.com/sistema/api/v1/documento"
                );
                var contents = new StringContent(
                    "{\r\n  \"codigo_barra\": \"null\",\r\n  \"nombre\": \""
                        + datos.nombre
                        + "\",\r\n"
                        + "  \"pvp1\": \""
                        + datos.pvp1
                        + "\",\r\n"
                        + "  \"codigo\": \""
                        + datos.codigo
                        + "\",\r\n \"porcentaje_iva\": \"12\",\r\n  \"tipo\": \"SER\",\r\n"
                        + "  \"para_supereasy\": \""
                        + false
                        + "  \"para_comisariato\": \""
                        + false
                        + "  \"minimo\": \""
                        + 0.0
                        + "  \"estado\": \""
                        + "A"
                        + "  \"descripcion\": \""
                        + "Servicio de Internet Banda ancha"
                        + "\"categoria_id\": \"91qdGvZgXhY6nbN8\"\r\n}",
                    null,
                    "application/json"
                );
                request.Headers.Add("Authorization", "eYxkPDD5SDLv0nRB7CIKsDCL6dwHppHwHmHMXIHqH8w");
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject(resp);
                    return StatusCode(StatusCodes.Status200OK, new { result });
                }

                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo el Pago" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });
            }
        }
    }
}
