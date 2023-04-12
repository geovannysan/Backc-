using System.Threading;
using System;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data.Models.Files;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesApiController : ControllerBase
    {
        private readonly Data.DataContext _dbcontex;

        public FilesApiController(Data.DataContext logger)
        {
            _dbcontex = logger;
        }

        public class ExcelFileModel
        {
            public IFormFile? File { get; set; }
        }

        [HttpPost]
        [Route("FileProdubanco")]
        public IActionResult ReadExcelFile([FromForm] ExcelFileModel model)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    model.File.CopyTo(stream);
                    stream.Position = 0;

                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                    DataSet result = reader.AsDataSet();
                    DataTable table = result.Tables[0];
                    List<FilesClass> myObjects = new List<FilesClass>();
                    foreach (DataRow row in table.Rows)
                    {
                        FilesClass myObject = new FilesClass
                        {
                            Fecha = (row[0]).ToString(),
                            Concepto = row[2].ToString(),
                            Documento = (row[1]).ToString(),
                            Monto = (row[4]).ToString(),
                            Oficina = (row[7]).ToString(),
                            Banco = "Produbanco"
                        };
                      //  _dbcontex.Bancoscon.Add(myObject);
                     //   _dbcontex.SaveChanges();
                        myObjects.Add(myObject);
                    }
                    return StatusCode(StatusCodes.Status200OK, myObjects);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired, ex.Message);
            }
        }

        [HttpPost]
        [Route("FilePichincha")]
        public IActionResult ReadExcelFileP([FromForm] ExcelFileModel model)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    model.File.CopyTo(stream);
                    stream.Position = 0;

                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                    DataSet result = reader.AsDataSet();
                    DataTable table = result.Tables[0];
                    List<FilesClass> myObjects = new List<FilesClass>();
                    foreach (DataRow row in table.Rows)
                    {
                        FilesClass myObject = new FilesClass
                        {
                            Fecha = (row[0]).ToString(),
                            Concepto = row[2].ToString(),
                            Documento = (row[4]).ToString(),
                            Monto = (row[6]).ToString(),
                            Oficina = (row[5]).ToString(),
                            Banco = "Pîchincha"
                        };
                        //_dbcontex.Bancoscon.Add(myObject);
                     //   _dbcontex.SaveChanges();
                        myObjects.Add(myObject);
                    }
                    return StatusCode(StatusCodes.Status200OK, myObjects);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired, ex.Message);
            }
        }
    }
}
