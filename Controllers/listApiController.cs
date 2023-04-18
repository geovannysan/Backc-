using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Files;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class listApiController : ControllerBase
    {
        private readonly Data.DataContext _dbcontext;

        public class Fechas
        {
            [Required]
            public string? fecha_inicio { get; set; }
            [Required]
            public string? fecha_fin { get; set; }
        }

        public listApiController(Data.DataContext logger)
        {
            _dbcontext = logger;
        }

        [HttpPost]
        [Route("Reporte")]
        public ActionResult Lista([FromBody] Fechas datos)
        {
            List<Repostressum> lista = new List<Repostressum>();
            try
            {
                lista = _dbcontext.Reporte.FromSqlInterpolated($"CALL Reporte({datos.fecha_inicio}, {datos.fecha_fin})").ToList();
                //lista = _dbContext._dbcontext.Empleado.Includes(c=> c.Cargos).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mesaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status200OK,
                    new { mesaje = ex.Message, response = lista }
                );
            }
        }
    }
}
