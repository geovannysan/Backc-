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

                return StatusCode(StatusCodes.Status200OK, resps);
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
                    "http://45.224.96.51:2334/devices/98006A-ONU%252DF660-ZTEKQG2LBA16342/tasks?connection_request"
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
