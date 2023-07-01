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
using Backrest.Data.Models.Pagos;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usersController : ControllerBase
    {
        private readonly Data.DataContext _dbcontex;
        private readonly HttpClient _httpcliente;
        private readonly PasswordHeader passworHeader;

        public usersController(Data.DataContext logger, HttpClient httpClient)
        {
            _httpcliente = httpClient;
            _dbcontex = logger;
            passworHeader = new PasswordHeader();
        }

        public class Datosf
        {
            public string? cedula { get; set; }
            public string? password { get; set; }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Listuser([FromBody] Datosf f)
        {
            try
            {
                bool existe = _dbcontex.admin.Any(p => p.cedula == f.cedula);
                if (!existe)
                {
                    return StatusCode(
                        StatusCodes.Status200OK,
                        new { statue = false, mensaje = "Usuario no Registrado " }
                    );
                }
                var users = _dbcontex.admin.Where(p => p.cedula == f.cedula).ToList();
                bool isPasswordValid = passworHeader.Verificarpws(f.password, users[0].password);
                if (isPasswordValid)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(
                        HttpMethod.Post,
                        "https://portal.comnet.ec/api/v1/GetClientsDetails"
                    );
                    var contents = new StringContent(
                        "{\r\n  \"token\": \""
                            + "azZrUHB4UnRMaTZaZkRYUW1YRXFDUT09"
                            + "\",\r\n  \"cedula\": \""
                            + users[0].cedula
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
                        var token = JwtHelper.GenerateToken(res);
                        if (result.estado == "exito")
                        {
                            return StatusCode(
                                StatusCodes.Status200OK,
                                new { result.estado, token }
                            );
                        }
                        return StatusCode(StatusCodes.Status200OK, new { result });
                    }
                    // info = _dbcontex.admin.Find(id);
                    //  return StatusCode(StatusCodes.Status200OK, new { info });
                }
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { succes = false, mensaje = "Acceso denegado" }
                );
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
                string hashedPassword = passworHeader.HasPasword(datos.password);
                bool existe = _dbcontex.admin.Any(p => p.cedula == datos.cedula);
                if (!existe)
                {
                    Usuario guarda = new Usuario()
                    {
                        username = datos.username,
                        cedula = datos.cedula,
                        password = hashedPassword,
                        imag = "" + datos.imag,
                        repuestauno = datos.repuestauno,
                        respuestados = datos.respuestados,
                        respuestatres = datos.respuestatres,
                    };
                    _dbcontex.admin.Add(guarda);

                    _dbcontex.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, new { success = true, guarda });
                }
                return StatusCode(StatusCodes.Status200OK, new { succes = false });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
