using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data;
using Backrest.Data;
using Backrest.Models;
using Backrest.Data.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Backrest.Controllers
{
    [EnableCors("CorsReglas")]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly Data.DataContext _dbcontext;
        private readonly HttpClient _httpcliente;

        public EmpleadoController(Data.DataContext logger, HttpClient httpClient)
        {
            _dbcontext = logger;
            _httpcliente = httpClient;
        }
        private List<T> Deserializar<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonStr);
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                lista = _dbcontext.Empleado.ToList();
                //lista = _dbContext._dbcontext.Empleado.Includes(c=> c.Cargos).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mesaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesaje = ex.Message, response = lista });

            }
        }
        [HttpGet]
        [Route("Obtener/{idEmpeado:int}")]
        public IActionResult Obtener(int idEmpeado)
        {
            Empleado oEmpleado = _dbcontext.Empleado.Find(idEmpeado);
            if (oEmpleado == null)
            {
                return BadRequest("Empleado no Encontrado");
            }
            try
            {
                oEmpleado = _dbcontext.Empleado.Where(p => p.Id == idEmpeado).FirstOrDefault();
                //lista = _dbContext._dbcontext.Empleado.Includes(c=> c.Cargos).ToList();.Where(p=> p.Id == idEmpeado).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mesaje = "ok", response = oEmpleado });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesaje = ex.Message, response = oEmpleado });

            }
        }
        [HttpPost]
        [Route("Crear")]
        public IActionResult CreaEmpleado([FromBody] Empleado objeto)
        {
            try
            {
                _dbcontext.Empleado.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Empleado objeto)
        {
            Empleado oEmpleado = _dbcontext.Empleado.Find(objeto.Id);

            if (oEmpleado == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {
                oEmpleado.Nombre = objeto.Nombre is null ? oEmpleado.Nombre : objeto.Nombre;
                oEmpleado.Apellido = objeto.Apellido is null ? oEmpleado.Apellido : objeto.Apellido;
                oEmpleado.Sueldo = objeto.Sueldo is null ? oEmpleado.Sueldo : objeto.Sueldo;
                oEmpleado.Fecha = objeto.Fecha is null ? oEmpleado.Fecha : objeto.Fecha;



                _dbcontext.Empleado.Update(oEmpleado);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }




        }

        [HttpDelete]
        [Route("Eliminar/{idEmpeado:int}")]
        public IActionResult Eliminar(int idEmpeado)
        {

            Empleado oEmpleado = _dbcontext.Empleado.Find(idEmpeado);

            if (oEmpleado == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                _dbcontext.Empleado.Remove(oEmpleado);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }
        public class Results
        {
            public string name { get; set; }
            public string url { get; set; }

        }
        public class Pokemo
        {
            public int count { get; set; }
            public string next { get; set; }
            public string previous { get; set; }
            public List<Results> results { get; set; }


        }



        [HttpGet]
        [Route("Apiload")]
        public async Task<ActionResult> Get()
        {
            try
            {
                // Object moreNumbers = new Dictionary<int, string>;
                // List<moreNumbers> pke = new List<moreNumbers>();
                string url = "https://pokeapi.co/api/v2/pokemon";
                HttpResponseMessage response = await _httpcliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Pokemo>(res);
                //    var lista = JsonConvert.DeserializeObject<string[]>((string)result.results);
                    //  var json_serializer = new JavaScriptSerializer();
                    //  MyObj routes_list = json_serializer.Deserialize<MyObj>("{ \"test\":\"some data\" }");


                    return StatusCode(StatusCodes.Status200OK, new {  result });
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "No se completo la consulta" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }

    }

}