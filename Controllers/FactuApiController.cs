using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Contifico;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactuApiController : ControllerBase
    {
        private readonly Data.DataContext _dbcontex;
        private readonly HttpClient _httpcliente;
        public string urlcon = "ttps://api.contifico.com/sistema/api/v1/persona/";
        public string urldoc = "https://api.contifico.com/sistema/api/v1/producto/";

        public FactuApiController(HttpClient httpClient, Data.DataContext logger)
        {
            _dbcontex = logger;
            _httpcliente = httpClient;
        }

        [HttpPost]
        [Route("incrementouno")]
        public async Task<ActionResult> Incremeto()
        {
            List<IncrementoClass> lista = new List<IncrementoClass>();
            try
            {
                lista = _dbcontex.incrementos.FromSqlInterpolated($"Incremento()").ToList();
                return StatusCode(StatusCodes.Status200OK, new { status = true, result = lista });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("incrementodos")]
        public async Task<ActionResult> Incremeto1()
        {
            List<IncrementoClass> lista = new List<IncrementoClass>();
            try
            {
                lista = _dbcontex.incrementos.FromSqlInterpolated($"Incremento1()").ToList();
                return StatusCode(StatusCodes.Status200OK, new { status = true, result = lista });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("incrementotres")]
        public async Task<ActionResult> Incremeto2()
        {
            List<IncrementoClass> lista = new List<IncrementoClass>();
            try
            {
                lista = _dbcontex.incrementos.FromSqlInterpolated($"Incremento3()").ToList();
                return StatusCode(StatusCodes.Status200OK, new { status = true, result = lista });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult> lista()
        {
            //List<IncrementoClass> lista = new List<IncrementoClass>();
            try
            {
                var lista = _dbcontex.incrementos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { status = true, result = lista });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public class Datoscon
        {
            public int contador { get; set; }
        }

        [HttpPut]
        [Route("listar/{id}")]
        public async Task<ActionResult> lista2(int id, [FromBody] Datoscon dato)
        {
            //List<IncrementoClass> lista = new List<IncrementoClass>();
            try
            {
                string consulta =
                    "UPDATE incrementos SET contadores = @nuevoContador WHERE id = @id";
                var parametros = new[]
                {
                    new MySqlParameter("@nuevoContador", dato.contador),
                    new MySqlParameter("@id", id)
                };

                int filasAfectadas = _dbcontex.Database.ExecuteSqlRaw(consulta, parametros);
                var lista = _dbcontex.incrementos.Find(id);
                return StatusCode(
                    StatusCodes.Status302Found,
                    new { status = true, filasAfectadas,lista }
                );
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /*crea producto contifico ok */
        [HttpPost]
        [Route("Crearpro")]
        public async Task<ActionResult> Creapro([FromBody] Producto datos)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, urldoc);
                var contents = new StringContent(
                    "{\r\n"
                        + "  \"codigo_barra\": null,\r\n"
                        + "  \"porcentaje_iva\": \"12\",\r\n"
                        + "  \"categoria_id\": \"null\",\r\n"
                        + "  \"pvp1\": "
                        + datos.pvp1
                        + ",\r\n"
                        + "  \"tipo\": \"SER\",\r\n"
                        + "  \"para_supereasy\": false,\r\n"
                        + "  \"para_comisariato\": false,\r\n"
                        + "  \"minimo\": \"0.0\",\r\n"
                        + "  \"descripcion\": \"Servicio de Internet Banda ancha\",\r\n"
                        + "  \"nombre\": \""
                        + datos.nombre
                        + "\",\r\n"
                        + "  \"codigo\": \""
                        + datos.codigo
                        + "\",\r\n"
                        + "  \"estado\": \"A\"\r\n"
                        + "}",
                    null,
                    "application/json"
                );
                request.Headers.Add("Authorization", "eYxkPDD5SDLv0nRB7CIKsDCL6dwHppHwHmHMXIHqH8w");
                request.Content = contents;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ServicioInternet>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    string resp2 = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Error>(resp2);

                    return StatusCode(StatusCodes.Status409Conflict, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
        }

        /*consulta producto esta ok*/
        [HttpGet]
        [Route("ConsultaProducto/{id:int}")]
        public async Task<ActionResult> Createproduc(string id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://api.contifico.com/sistema/api/v1/producto/?codigo=" + id
                );
                request.Headers.Add("Authorization", "eYxkPDD5SDLv0nRB7CIKsDCL6dwHppHwHmHMXIHqH8w");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ServicioInternet>>(resp);
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    string resp2 = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Error>(resp2);

                    return StatusCode(StatusCodes.Status409Conflict, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { ex.Message });
            }
        }
    }
}
