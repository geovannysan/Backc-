using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Backrest.Data;
using Backrest.Data.Models;
using System.Text.Json.Serialization;
using Backrest.Data.Models.Pagos;
using Backrest.Data.Models.microtik;
using Newtonsoft.Json.Linq;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PortalApiController : ControllerBase
    {
        private readonly HttpClient _httpcliente;

        public class Proceso
        {
            public string? cedula { get; set; }
            public string? operador { get; set; }
        }

        public string url = "https://portal.comnet.ec/api/v1/";
        Procesos newproces = new Procesos();

        public PortalApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpPost]
        [Route("GetClientsDetails")]
        public async Task<ActionResult> Get([FromBody] Proceso datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url + "GetClientsDetails");
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + newproces.Obtenertoken(datos.operador)
                        + "\",\r\n  \"cedula\": \""
                        + datos.cedula
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
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { estado= "errro" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("GetClientsDetailsdos")]
        public async Task<ActionResult> Getd([FromBody] Proceso datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url + "GetClientsDetails");
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                        + "\",\r\n  \"cedula\": \""
                        + datos.cedula
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
                    if (result.estado == "exito")
                    {
                        var fact = result.datos.Find(e => e.estado == "ACTIVO");
                        var clients = new HttpClient();
                        var requestdos = new HttpRequestMessage(
                            HttpMethod.Get,
                            "https://portal.comnet.ec/api/v1/GetInvoices"
                        );
                        var contentsdos = new StringContent(
                            "{\r\n  \"token\": \"azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09\",\r\n  \"idcliente\": \""
                                + fact.id
                                + "\",\r\n  \"limit\": \""
                                + 1
                                + "\"\r\n}",
                            null,
                            "application/json"
                        );
                        requestdos.Content = contentsdos;
                        var responses = await clients.SendAsync(requestdos);
                        if (responses.IsSuccessStatusCode)
                        {
                            string resdos = await responses.Content.ReadAsStringAsync();
                            var resultdos = JsonConvert.DeserializeObject<Clienteportal>(resdos);
                            if (resultdos.estado == "exito")
                            {
                                var clientres = new HttpClient();
                                var requesttres = new HttpRequestMessage(
                                    HttpMethod.Get,
                                    url + "GetInvoice"
                                );
                                var contentstres = new StringContent(
                                    "{\r\n  \"token\": \""
                                        + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                                        + "\",\r\n  \"idfactura\": \""
                                        + resultdos.facturas[0].id
                                        + "\"\r\n}",
                                    null,
                                    "application/json"
                                );
                                requesttres.Content = contentstres;
                                var responsetres = await clientres.SendAsync(requesttres);
                                if (responsetres.IsSuccessStatusCode)
                                {
                                    string restres = await responsetres.Content.ReadAsStringAsync();
                                    var resulttres = JsonConvert.DeserializeObject<Clienteportal>(
                                        restres
                                    );
                                    return StatusCode(
                                        StatusCodes.Status200OK,
                                        new
                                        {
                                            resulttres.estado,
                                            // fact.id,
                                            // resultdos,
                                            resulttres.items,
                                            fact.facturacion
                                        }
                                    );
                                }
                                return StatusCode(
                                    StatusCodes.Status200OK,
                                    new
                                    {
                                        // fact.id,
                                        // resultdos,
                                        fact.facturacion
                                    }
                                );
                            }
                        }
                        return StatusCode(
                            StatusCodes.Status200OK,
                            new { mensaje = "No se completo la consulta" }
                        );
                    }
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetInvoices/{idcliente:int}/{operador:int}")]
        public async Task<ActionResult> Index(string idcliente, string operador)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://portal.comnet.ec/api/v1/GetInvoices"
                );
                var contents = new StringContent(
                    "{\r\n  \"token\": \"azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09\",\r\n  \"idcliente\": \""
                        + idcliente
                        + "\",\r\n  \"limit\": \""
                        + 2
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
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("GetInvoices")]
        public async Task<ActionResult> GetInvoices([FromBody] Apiportal datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://portal.comnet.ec/api/v1/GetInvoices"
                );
                var contents = new StringContent(
                    "{\r\n  \"token\": \"azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09\",\r\n  \"idcliente\": \""
                        + datos.idcliente
                        + "\",\r\n  \"limit\": \""
                        + datos.limit
                        + "\",\r\n  \"estado\": \""
                        + datos.estado
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
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetInvoice/{idfactura:int}/{operador:int}")]
        public async Task<ActionResult> Obtener(int idfactura, string operador)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url + "GetInvoice");
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + newproces.Obtenertoken(operador)
                        + "\",\r\n  \"idfactura\": \""
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
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("GetInvoice")]
        public async Task<ActionResult> GetInvoice([FromBody] Apiportal datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url + "GetInvoice");
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                        + "\",\r\n  \"idfactura\": \""
                        + datos.idfactura
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
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("ListTicket")]
        public async Task<ActionResult> ListTicket([FromBody] Apiportal datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url + "ListTicket");
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                        + "\",\r\n  \"idcliente\": \""
                        + datos.idcliente
                        + "\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Infoticket>(res);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Listequipo/{id}")]
        public async Task<ActionResult> Ticket(int id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url + "GetRouters");
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                        + "\",\r\n  \"id\": \""
                        + id
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
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mensaje = "No se completo la consulta" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUser datos)
        {
            try
            {
                /* var client = new HttpClient();
                 var request = new HttpRequestMessage(
                     HttpMethod.Post,
                     "http://45.224.96.50/api/v1/UpdateUser"
                 );*/
                var data = new
                {
                    token = "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09",
                    idcliente = "294",
                    datos = new
                    {
                        //nombre = datos.nombre,
                        correo = datos.correo,
                        telefono = datos.telefono,
                        movil = datos.movil,
                        // cedula = datos.cedula,
                        //codigo = datos.codigo,
                        //  direccion_principal = datos.direccion_principal
                    }
                };

                var client = new HttpClient();

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    "http://45.224.96.50/api/v1/UpdateUser",
                    content
                );
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                string resps = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<Clienteportal>(resps);
                return StatusCode(StatusCodes.Status200OK, results);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public class Infonu
        {
            public string? info { get; set; }
        }

        /*
                [HttpPost("Devices")]
                public async Task<ActionResult> Devices([FromBody] Infonu info)
                {
                    try
                    {
                        var client = new HttpClient();
                        var request = new HttpRequestMessage(
                            HttpMethod.Get,
                            "http://45.224.96.51:2334/devices/?query={\"_id\": \""
                                + info.info
                                + "\"}&projection=InternetGatewayDevice.LANDevice.1.Hosts.Host"
                        );
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        //Console.WriteLine(await response.Content.ReadAsStringAsync());
                        string resps = await response.Content.ReadAsStringAsync();
        
                        return StatusCode(StatusCodes.Status200OK, resps);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
                    }
                }
        
                [HttpPost("ssi")]
                public async Task<ActionResult> SSi([FromBody] Infonu info)
                {
                    try
                    {
                        var client = new HttpClient();
                        var request = new HttpRequestMessage(
                            HttpMethod.Get,
                            "http://45.224.96.51:2334/devices/?query={\"_id\": \""
                                + info.info
                                + "\"}&projection=InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.SSID"
                        );
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        //Console.WriteLine(await response.Content.ReadAsStringAsync());
                        string resps = await response.Content.ReadAsStringAsync();
        
                        return StatusCode(StatusCodes.Status200OK, resps);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
                    }
                }
        */
        /*
        pagar factura ok
        */
        [HttpPost]
        [Route("PagosdelPortal/{operador:int}")]
        public async Task<ActionResult> Postpago(string operador, [FromBody] Datos datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "https://portal.comnet.ec/api/v1/PaidInvoice"
                );
                var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + newproces.Obtenertoken(operador)
                        + "\",\r\n  \"idfactura\": \""
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
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                string resps = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<Clienteportal>(resps);
                return StatusCode(StatusCodes.Status200OK, results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }
       
       
        [HttpPost("CreaTicket")]
        public async Task<ActionResult> Postticket ([FromBody] Creatickte datos ){
            try
            {
                  var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "https://portal.comnet.ec/api/v1/NewTicket"
                );
                 var contents = new StringContent(
                    "{\r\n  \"token\": \""
                        + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                        + "\",\r\n  \"idcliente\": \""
                        + datos.idcliente
                        + "\",\r\n"
                        + "  \"asunto\": \""
                        + datos.asunto
                        + "\",\r\n"
                        + "  \"dp\": \""
                        + "1"
                        + "\",\r\n"
                        + "  \"solicitante\": \""
                        + datos.solicitante
                        + "\",\r\n"
                        + "  \"fechavisita\": \""
                        + datos.fechavisita
                        + "\",\r\n"
                        + "  \"turno\": \""
                        + datos.turno
                        + "\",\r\n"
                        + "  \"agendado\": \""
                        + datos.agendado
                        + "\",\r\n"
                        + "  \"contenido\": \""
                        + datos.contenido
                        + "\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                string resps = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<Clienteportal>(resps);
                return StatusCode(StatusCodes.Status200OK, results);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        /*
                [HttpGet]
                [Route("estdoolt/{idolt:int}")]
                public async Task<ActionResult> Obtenerolt(string idolt)
                {
                    try
                    {
                        var client = new HttpClient();
                        var request = new HttpRequestMessage(
                            HttpMethod.Get,
                            "https://comnet.smartolt.com/api/onu/get_onu_signal/" + idolt
                        );
                        request.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                        var response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<result>(resp);
                            return StatusCode(StatusCodes.Status200OK, result);
                        }
                        string resps = await response.Content.ReadAsStringAsync();
                        var results = JsonConvert.DeserializeObject<result>(resps);
                        return StatusCode(StatusCodes.Status200OK, results);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
        
                [HttpGet]
                [Route("estado/{idolt:int}")]
                public async Task<ActionResult> ObtenerStuatus(string idolt)
                {
                    try
                    {
                        var client = new HttpClient();
                        var request = new HttpRequestMessage(
                            HttpMethod.Get,
                            "https://comnet.smartolt.com/api/onu/get_onu_status/" + idolt
                        );
                        request.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                        var response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<result>(resp);
                            return StatusCode(StatusCodes.Status200OK, result);
                        }
                        string resps = await response.Content.ReadAsStringAsync();
                        var results = JsonConvert.DeserializeObject<result>(resps);
                        return StatusCode(StatusCodes.Status200OK, results);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
        
                [HttpGet("detalleolt/{idolt:int}")]
                public async Task<ActionResult> Detalleolt(string idolt)
                {
                    try
                    {
                        var client = new HttpClient();
                        var request = new HttpRequestMessage(
                            HttpMethod.Get,
                            "https://comnet.smartolt.com/api/onu/get_onu_details/" + idolt
                        );
                        request.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                        var response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<result>(resp);
                            return StatusCode(StatusCodes.Status200OK, resp);
                        }
                        string resps = await response.Content.ReadAsStringAsync();
                        var results = JsonConvert.DeserializeObject(resps);
                        return StatusCode(StatusCodes.Status200OK, resps);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
        
                [HttpGet("detalleoltport/{idolt:int}")]
                public async Task<ActionResult> Detalleoltport(string idolt)
                {
                    try
                    {
                        var client = new HttpClient();
                        var request = new HttpRequestMessage(
                            HttpMethod.Get,
                            "https://comnet.smartolt.com/api/system/get_olt_pon_ports_details/" + idolt
                        );
                        request.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                        var response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<result>(resp);
                            return StatusCode(StatusCodes.Status200OK, result);
                        }
                        string resps = await response.Content.ReadAsStringAsync();
                        var results = JsonConvert.DeserializeObject<result>(resps);
                        return StatusCode(StatusCodes.Status200OK, results);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
        */
        //antes de esto poner las rutas
    }
}
