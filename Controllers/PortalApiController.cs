using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Backrest.Data.Models;
using System.Text.Json.Serialization;
using Backrest.Data.Models.Pagos;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PortalApiController : ControllerBase
    {
        private readonly HttpClient _httpcliente;
        public string url = "https://portal.comnet.ec/api/v1/";

        public PortalApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpGet]
        [Route("GetClientsDetails/{cedula:int}")]
        public async Task<ActionResult> Get(string cedula)
        {
            try
            {
                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Post, url + "GetClientsDetails");
                var contents = new StringContent(
                    "{\r\n  \"token\": \"SzFpNm04STlFNkhDRE9mcFBaZWlEdz09\",\r\n  \"cedula\": \""
                        + cedula
                        + "\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(res);
                    return StatusCode(StatusCodes.Status200OK, new { result });
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        //,\r\n \"estado\":1,
        [HttpGet]
        [Route("GetInvoices/{idcliente:int}")]
        public async Task<ActionResult> Index(string idcliente)
        {
            try
            {
                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, url + "GetInvoices");

                var contents = new StringContent(
                    "{\r\n  \"token\": \"SzFpNm04STlFNkhDRE9mcFBaZWlEdz09\",\r\n  \"idcliente\": \""
                        + idcliente
                        + "\",\r\n  \"estado\": \"1\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(res);
                    return StatusCode(StatusCodes.Status200OK, new { result });
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetInvoice/{idfactura:int}")]
        public async Task<ActionResult> Obtener(int idfactura)
        {
            try
            {
                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, url + "GetInvoice");
                var contents = new StringContent(
                    "{\r\n  \"token\": \"SzFpNm04STlFNkhDRE9mcFBaZWlEdz09\",\r\n  \"idfactura\": \""
                        + idfactura
                        + "\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(res);
                    return StatusCode(StatusCodes.Status200OK, new { result });
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("PagoFactura")]
        public async Task<ActionResult> PaidInvoice([FromBody] Datos datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url + "PaidInvoice");
                var contents = new StringContent(
                    "{\r\n  \"token\": \"SzFpNm04STlFNkhDRE9mcFBaZWlEdz09\",\r\n  \"idfactura\": \""
                        + datos.idfactura
                        + "\",\r\n"
                        + "  \"pasarela\": \""
                        + datos.pasarela
                        + "\",\r\n"
                        + "  \"cantidad\": \""
                        + datos.cantidad
                        + "\",\r\n"
                        + "  \"nota\": \""
                        + datos.nota
                        + "\",\r\n"
                        + "  \"idtransaccion\": \""
                        + datos.idtransaccion
                        + "\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content= contents;
                var response = await client.SendAsync(request);
                if(response.IsSuccessStatusCode){
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject(resp);
                    return StatusCode(StatusCodes.Status102Processing, new { mensaje = result });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "No se completo el Pago" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        
        //antes de esto poner las rutas
    }
}
