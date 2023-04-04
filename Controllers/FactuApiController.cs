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

        public FactuApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpPost]
        [Route("Creaproducto")]
        public async Task<ActionResult> Get([FromBody] Producto datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url + "PaidInvoice");
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
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
