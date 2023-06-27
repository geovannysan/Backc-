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

        [HttpGet]
        [Route("get_onu_status/{idolt:int}")]
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

        [HttpGet("get_onu_details/{idolt:int}")]
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

        [HttpGet]
        [Route("get_speed_profiles")]
        public async Task<ActionResult> Obtenerprofile()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://comnet.smartolt.com/api/system/get_speed_profiles"
                );
                request.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject(resp);
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

        [HttpGet]
        [Route("get_onu_signal/{idolt:int}")]
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

        [HttpGet("get_olt_pon_ports_details/{idolt:int}")]
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

        [HttpGet("get_onu_speed_profiles/{id}")]
        public async Task<ActionResult> Getonus(int id)
        {
            try
            {
                var client = new HttpClient();
                var reques = new HttpRequestMessage(
                    HttpMethod.Get,
                    url + "/api/onu/get_onu_speed_profiles/" + id
                );
                reques.Headers.Add("X-Token", "a068dcbce5ab4b3591e57f8d8a4348e9");
                var response = await client.SendAsync(reques);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var resul = JsonConvert.DeserializeObject(res);
                    return StatusCode(StatusCodes.Status200OK, res);
                }
                string resps = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject(resps);
                return StatusCode(StatusCodes.Status200OK, results);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("get_olt_cards_details/{id}")]
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
