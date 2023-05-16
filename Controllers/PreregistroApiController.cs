using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Backrest.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PreregistroApiController : ControllerBase
    {
        private readonly HttpClient _httpcliente;
        public string url = "https://portal.comnet.ec/api/v1/"; /*  */

        public class Bodyparms
        {
            [Required]
            public string? cliente { get; set; }

            [Required]
            public string? cedula { get; set; }

            [Required]
            public string? direccion { get; set; }

            [Required]
            public string? telefono { get; set; }

            [Required]
            public string? movil { get; set; }

            [Required]
            public string? email { get; set; }

            [Required]
            public string? notas { get; set; }

            [Required]
            public string? fecha_instalacion { get; set; }
        }
        public class Bodycedula{
            public string? cedula {get;set;}
        }

     
        public PreregistroApiController(HttpClient httpClient)
        {
            _httpcliente = httpClient;
        }

        [HttpPost]
        [Route("PreRegistro")]
        public async Task<ActionResult> Postres([FromBody] Bodyparms datos)
        {
            try
            {
                bool isMatch = Regex.IsMatch(datos.cedula, @"^\d+$");
                if (!isMatch)
                {
                    return StatusCode(
                        StatusCodes.Status400BadRequest,
                        new { message = "La cédula debe ser numerica" }
                    );
                }
                var cliente = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url + "NewPreRegistro");
                var body = new
                {
                    token = "NXJzUzNRNGljN0JOOWRpK252QXFzdz09",
                    cliente = datos.cliente,
                    cedula = datos.cedula,
                    direccion = datos.direccion,
                    telefono = datos.telefono,
                    movil = datos.movil,
                    email = datos.email,
                    notas = datos.notas,
                    fecha_instalacion = datos.fecha_instalacion
                };
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                var contents = new StringContent(jsonBody, null, "application/json");
                request.Content = contents;
                var response = await cliente.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(res);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    new { message = "Hubo un error" }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { error = ex.Message });
            }
        }

        [HttpPost]
        [Route("ListRegistro")]
        public async Task<ActionResult> PostList([FromBody] Bodycedula datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url + "ListInstall");
                var body = new
                {
                    token = "NXJzUzNRNGljN0JOOWRpK252QXFzdz09",
                    cedula = datos.cedula,
                };
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                var contents = new StringContent(jsonBody, null, "application/json");
                request.Content= contents;
                var response = await client.SendAsync(request);
                if(response.IsSuccessStatusCode){
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Clienteportal>(res);
                    return StatusCode(StatusCodes.Status200OK,result);
                }
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    new { message = "Hubo un error" }
                );
            }
              catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { error = ex.Message });
            }
        }
    }
}
