using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Backrest.Data;
using Backrest.Data.Models;
using Backrest.Models;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usersController : ControllerBase
    {
        private readonly Data.DataContext _dbcontex;
        private readonly HttpClient _httpcliente;

        public usersController(Data.DataContext logger, HttpClient httpClient)
        {
            _httpcliente = httpClient;
            _dbcontex = logger;
        }

        public class Datosf
        {
            public string? cedula { get; set; }
            public string? password { get; set; }
        }

        [HttpPost("getuser/{id}")]
        public async Task<ActionResult> Listuser([FromBody] Datosf f, int id)
        {
            try
            {
                bool existe = _dbcontex.admin.Any(p => p.cedula == f.cedula);
                if (existe)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(
                        HttpMethod.Post,
                        "url" + "GetClientsDetails"
                    );
                    var contents = new StringContent(
                        "{\r\n  \"token\": \""
                            + "newproces.Obtenertoken(datos.operador)"
                            + "\",\r\n  \"cedula\": \""
                            + f.cedula
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
                    // info = _dbcontex.admin.Find(id);
                    //  return StatusCode(StatusCodes.Status200OK, new { info });
                }
                return StatusCode(StatusCodes.Status200OK, new { succes=false});
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Crearuser")]
        public ActionResult Guardaruser([FromBody] Usuario datos)
        {
            try
            {
                bool existe = _dbcontex.admin.Any(p => p.cedula == datos.cedula);
                if (!existe)
                {
                    _dbcontex.admin.Add(datos);

                    _dbcontex.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, new { success = true, datos });
                }
                return StatusCode(StatusCodes.Status200OK, new { succes=false});
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
