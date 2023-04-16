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
        public List<Users> Lista()
        {
            List<Users> lista = new List<Users>();
            try
            {
                lista = _dbcontext.admin.ToList();
              
                return lista;
            }
            catch (System.Exception )
            {
                   throw;

            }
        }
    }
}