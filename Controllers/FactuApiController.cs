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
        public string urlcon = "ttps://api.contifico.com/sistema/api/v1/persona/";
        public string urldoc = "https://api.contifico.com/sistema/api/v1/producto/";

        public FactuApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        //*falta validar si funciona y como trae la informacion para crear el objeto
        /*  [HttpPost]
          [Route("Crearpersona")]
          public async Task<ActionResult> Get([FromBody] Clientecontifico datos)
          {
              try
              {
                  var client = new HttpClient();
                  var request = new HttpRequestMessage(HttpMethod.Post, urlcon);
                  var contents = new StringContent(
                      "{\r\n  \"tipo\": \"N\",\r\n  \"personaasociada_id\": null,\r\n  \"nombre_comercial\": \""
                          + datos.nombre_comercial
                          + "\",\r\n  \"telefonos\": \""
                          + datos.telefonos
                          + "\",\r\n  \"razon_social\": \""
                          + datos.nombre_comercial
                          + "\",\r\n  \"direccion\": \""
                          + datos.direccion
                          + "\",\r\n  \"porcentaje_descuento\": \"0\",\r\n  \"es_cliente\": true,\r\n  \"origen\": \"Panel de Facturacion\",\r\n  \"email\": \""
                          + datos.email
                          + "\",\r\n  \"cedula\": \""
                          + datos.cedula
                          + "\",\r\n  \"Provincia\": \"Guayaquil\",\r\n  \"adicional1_cliente\": \"Cliente de Internet\"\r\n}\r\n",
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
                      return StatusCode(StatusCodes.Status200OK, result);
                  }
                  else
                  {
                      string resp2 = await response.Content.ReadAsStringAsync();
                      var result = JsonConvert.DeserializeObject<Error>(resp2);
  
                      return StatusCode(StatusCodes.Status409Conflict, result);
                  }
              }
              catch (Exception ex)
              {
                  return StatusCode(StatusCodes.Status200OK, ex.Message);
              }
          }
              */
        /*crea producto contifico ok */
        [HttpPost]
        [Route("Crearpro")]
        public async Task<ActionResult> Creapro([FromBody] Producto datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, urldoc);
                var contents = new StringContent(
                    "{\r\n"
                        + "  \"codigo_barra\": null,\r\n"
                        + "  \"porcentaje_iva\": \"12\",\r\n"
                        + "  \"categoria_id\": \"null\",\r\n"
                        + "  \"pvp1\": "
                        + datos.pvp1
                        + ",\r\n"
                        + "  \"tipo\": \"SER\",\r\n"
                        + "  \"para_supereasy\": false,\r\n"
                        + "  \"para_comisariato\": false,\r\n"
                        + "  \"minimo\": \"0.0\",\r\n"
                        + "  \"descripcion\": \"Servicio de Internet Banda ancha\",\r\n"
                        + "  \"nombre\": \""
                        + datos.nombre
                        + "\",\r\n"
                        + "  \"codigo\": \""
                        + datos.codigo
                        + "\",\r\n"
                        + "  \"estado\": \"A\"\r\n"
                        + "}",
                    null,
                    "application/json"
                );
                request.Headers.Add("Authorization", "eYxkPDD5SDLv0nRB7CIKsDCL6dwHppHwHmHMXIHqH8w");
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ServicioInternet>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    string resp2 = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Error>(resp2);

                    return StatusCode(StatusCodes.Status409Conflict, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
        }

        /*consulta producto esta ok*/
        [HttpGet]
        [Route("ConsultaProducto/{id:int}")]
        public async Task<ActionResult> Createproduc(string id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://api.contifico.com/sistema/api/v1/producto/?codigo=" + id
                );
                request.Headers.Add("Authorization", "eYxkPDD5SDLv0nRB7CIKsDCL6dwHppHwHmHMXIHqH8w");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ServicioInternet>>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    string resp2 = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Error>(resp2);

                    return StatusCode(StatusCodes.Status409Conflict, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });
            }
        }
    }
}
