using System;
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

namespace Backrest.Controllers
{
    [EnableCors("CorsReglas")]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly Data.DataContext _dbcontext;

        public EmpleadoController(Data.DataContext logger)
        {
            _dbcontext = logger;
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
    }

}