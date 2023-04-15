using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Files;
using Backrest.Data;
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
        public string Lista()
        {
            List<Users> lista = new List<Users>();
            try
            {
              
                return" Dataconexion.Consultar()";
            }
            catch (System.Exception )
            {
                   throw;

            }
        }
    }
}