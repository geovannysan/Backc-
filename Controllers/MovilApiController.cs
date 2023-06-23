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
    public class MovilApiController : ControllerBase
    {
        private readonly HttpClient? _httpcliente;

        public class Infonus
        {
            public string? info { get; set; }
            public string? booleas { get; set; }
        }

        public MovilApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpPost("ssid")]
        public async Task<ActionResult> SSivisible([FromBody] Infonus info)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "http://45.224.96.51:2334/devices/?query={\"_id\": \""
                        + info.info
                        + "\"}&projection=InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.SSIDAdvertisementEnabled"
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

        
        
         public class Onu
        {
            public string? onu { get; set; }
        }

        [HttpPost("hide")]
        public async Task<ActionResult> hide([FromBody] Onu onu)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "http://45.224.96.51:2334/devices/?query={\"_id\": \""
                        + onu.onu
                        + "\"}&projection=InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.SSIDAdvertisementEnabled"
                );
                //request.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject<result>(resp);
                    return StatusCode(StatusCodes.Status200OK, resp);
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
        [HttpPost("changessi")]
        public async Task<ActionResult> Ssichange([FromBody] Infonus info)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "http://45.224.96.51:2334/devices/" + info.info + "/tasks"
                );
                var data = new
                {
                    name = "setParameterValues",
                    parameterValues = new[]
                    {
                        new object[]
                        {
                            "InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.SSIDAdvertisementEnabled",
                            "" + info.booleas,
                            "xsd:boolean"
                        }
                    }
                };

                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var contents = new StringContent(jsonBody, null, "application/json");
                request.Content = contents;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                string resps = await response.Content.ReadAsStringAsync();

                return StatusCode(StatusCodes.Status200OK,resps);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }
        [HttpPost("passwordssi")]
        public async Task<ActionResult> Ssipassword([FromBody] Infonus info)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "http://45.224.96.51:2334/devices/" + info.info + "/tasks"
                );
                var data = new
                {
                    name = "setParameterValues",
                    parameterValues = new[]
                    {
                        new object[]
                        {
                            "InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.PreSharedKey.1.PreSharedKey",
                            "" + info.booleas,
                            "xsd:string"
                        }
                    }
                };

                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var contents = new StringContent(jsonBody, null, "application/json");
                request.Content = contents;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                string resps = await response.Content.ReadAsStringAsync();

                return StatusCode(StatusCodes.Status200OK,resps);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }
        [HttpPost("namessi")]
        public async Task<ActionResult> Ssiname([FromBody] Infonus info)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "http://45.224.96.51:2334/devices/" + info.info + "/tasks"
                );
                var data = new
                {
                    name = "setParameterValues",
                    parameterValues = new[]
                    {
                        new object[]
                        {
                            "InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.SSID",
                            "" + info.booleas,
                            "xsd:string"
                        }
                    }
                };

                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var contents = new StringContent(jsonBody, null, "application/json");
                request.Content = contents;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                string resps = await response.Content.ReadAsStringAsync();

                return StatusCode(StatusCodes.Status200OK,resps);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { mensaje = ex.Message });
            }
        }

        [HttpPost("refres")]
        public async Task<ActionResult> refres([FromBody] Infonus info)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "http://45.224.96.51:2334/devices/"+info.info+"/tasks?connection_request"
                );
                 var contents = new StringContent(
                    "{\r\n  \"name\": \""
                        +"refreshObject" 
                        + "\",\r\n  \"objectName\": \""
                        + "InternetGatewayDevice.LANDevice.1.WLANConfiguration.1.SSIDAdvertisementEnabled"
                        + "\"\r\n}",
                    null,
                    "application/json"
                );
                request.Content = contents;
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
    }
}
