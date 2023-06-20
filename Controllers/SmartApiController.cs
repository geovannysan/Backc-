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
    [Route("api/[controller]")]
    public class SmartApiController : ControllerBase
    {
        private readonly HttpClient _httpcliente;
        private string url = "https://comnet.smartolt.com";

        public SmartApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpGet("oltdetal/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    url + "/api/system/get_olt_cards_details/" + id
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
                var results = JsonConvert.DeserializeObject<result>(resps);
                return StatusCode(StatusCodes.Status200OK, results);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
