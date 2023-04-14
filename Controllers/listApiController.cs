using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Files;
namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class listApiController : ControllerBase
    {
         private readonly Data.DataContext _dbcontext;
    

        public listApiController(Data.DataContext logger)
        {
            _dbcontext = logger;
        
        }
        

        [HttpGet]
        [Route("lista")]
        public ActionResult Lista()
        {
            List<Users> lista = new List<Users>();
            try
            {
                lista = _dbcontext.cliente.ToList();
                //lista = _dbContext._dbcontext.Empleado.Includes(c=> c.Cargos).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mesaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesaje = ex.Message, response = lista });

            }
        }
    }
}