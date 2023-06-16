using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Files;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Backrest.Data.Models;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class listApiController : ControllerBase
    {
        private readonly Data.DataContext _dbcontext;

        private readonly HttpClient _httpcliente;

        public class Fechas
        {
            [Required]
            public string? fecha_inicio { get; set; }

            [Required]
            public string? fecha_fin { get; set; }
        }

        public listApiController(Data.DataContext logger, HttpClient httpClient)
        {
            _dbcontext = logger;
            _httpcliente = httpClient;
        }

        [HttpPost]
        [Route("Reporte")]
        public ActionResult Lista([FromBody] Fechas datos)
        {
            List<Repostressum> lista = new List<Repostressum>();
            try
            {
                lista = _dbcontext.Reporte
                    .FromSqlInterpolated($"CALL Reporte({datos.fecha_inicio}, {datos.fecha_fin})")
                    .ToList();
                //lista = _dbContext._dbcontext.Empleado.Includes(c=> c.Cargos).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mesaje = true, response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    new { mesaje = ex.Message, response = lista }
                );
            }
        }

        [HttpPost]
        [Route("Transaciones")]
        public ActionResult Transacion([FromBody] Fechas datos)
        {
            List<Cuentacon> lista = new List<Cuentacon>();

            try
            {
                var ini = datos.fecha_inicio;
                var fin = datos.fecha_fin;
                lista = _dbcontext.cuentacon
                    .FromSqlInterpolated($"SELECT * FROM `incrementos`")
                    .ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = true, lista });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetLocalidad")]
        public async Task<ActionResult> Getls()
        {
            try {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,"https://server1.ticketfacil.ec/ticket2/ajax.pventa.php?api_wts=ticketfacil_api&action=get&typedata=local_concrt&data=1102");
                var response = await client.SendAsync(request);
                if(response.IsSuccessStatusCode){
                    string res = await response.Content.ReadAsStringAsync();
                    return StatusCode(StatusCodes.Status200OK,res);
                }
                return StatusCode(
                    StatusCodes.Status404NotFound,
                    new { mensaje = "No se completo la consulta" }
                );
             }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
