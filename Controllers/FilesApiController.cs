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
using System.Globalization;
using System.Text.RegularExpressions;

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
                    var num = 0;
                    List<FilesClass> myObjects = new List<FilesClass>();
                    stream.Position = 0;
                    IExcelDataReader readeruno = ExcelReaderFactory.CreateReader(stream);
                    DataSet resultado = readeruno.AsDataSet();
                    DataTable tablauno = resultado.Tables[0];
                    DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
                    string regexPattern = "[^0-9]";
                    foreach (DataRow row in tablauno.Rows)
                    {
                        DateTime fechaHora;
                        DateTime fecha = Convert.ToDateTime(row[0].ToString(), usDtfi);
                        FilesClass myObject = new FilesClass
                        {
                            fecha = fecha,
                            codigo = row[1].ToString(),
                            documento = (row[1]).ToString(),
                            monto = row[4].ToString().Replace(",", ""),
                            oficina = (row[7]).ToString(),
                            banco = "Produbanco"
                        };
                        string co = row[1].ToString();
                        bool existe = _dbcontex.Bancoscon.Any(p => p.codigo == co);
                        myObjects.Add(myObject);
                        myObjects.Add(myObject);
                        if (!existe)
                        {
                            _dbcontex.Bancoscon.Add(myObject);
                            _dbcontex.SaveChanges();
                            num = num + 1;
                        }
                    }

                    return StatusCode(StatusCodes.Status200OK, new { myObjects });
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
                    var num = 0;
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                    DataSet result = reader.AsDataSet();
                    DataTable table = result.Tables[0];
                    List<FilesClass> myObjects = new List<FilesClass>();

                    foreach (DataRow row in table.Rows)
                    {
                        DateTime fecha = Convert.ToDateTime(row[0]);
                        FilesClass myObject = new FilesClass
                        {
                            fecha = fecha,
                            codigo = row[2].ToString(),
                            documento = (row[4]).ToString(),
                            monto = (row[6]).ToString(),
                            oficina = (row[5]).ToString(),
                            banco = "Pichincha"
                        };
                        //_dbcontex.Bancoscon.Add(myObject);
                        //   _dbcontex.SaveChanges();
                        myObjects.Add(myObject);
                        bool existe = _dbcontex.Bancoscon.Any(
                            p => p.codigo == row[2].ToString() 
                        );
                        // myObjects.Add(myObject);

                        if (!existe)
                        {
                            _dbcontex.Bancoscon.Add(myObject);
                            _dbcontex.SaveChanges();
                            num = num + 1;
                        }
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
        [Route("FilePacifico")]
        public IActionResult ReadExcelFilePro([FromForm] ExcelFileModel model)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    model.File.CopyTo(stream);
                    var num = 0;
                    List<FilesClass> myObjects = new List<FilesClass>();
                    stream.Position = 0;
                    IExcelDataReader readeruno = ExcelReaderFactory.CreateReader(stream);
                    DataSet resultado = readeruno.AsDataSet();
                    DataTable tablauno = resultado.Tables[0];

                    string regexPattern = "[^0-9]";
                    foreach (DataRow row in tablauno.Rows)
                    {
                        DateTime fecha = Convert.ToDateTime(row[0]);
                        FilesClass myObject = new FilesClass
                        {
                            fecha = fecha,
                            codigo = Regex
                                .Replace(row[10].ToString(), regexPattern, "")
                                .Substring(
                                    0,
                                    Regex.Replace(row[10].ToString(), regexPattern, "").Length - 2
                                ),
                            documento = (row[10]).ToString(),
                            monto = row[5].ToString().Replace(",", ""),
                            oficina = (row[4]).ToString(),
                            banco = "Pacifico"
                        };
                        string co = Regex
                            .Replace(row[10].ToString(), regexPattern, "")
                            .Substring(
                                0,
                                Regex.Replace(row[10].ToString(), regexPattern, "").Length - 2
                            );
                        bool existe = _dbcontex.Bancoscon.Any(
                            p => p.codigo == co && p.fecha == fecha
                        );
                        // myObjects.Add(myObject);
                        myObjects.Add(myObject);
                        if (!existe)
                        {
                            _dbcontex.Bancoscon.Add(myObject);
                            _dbcontex.SaveChanges();
                            num = num + 1;
                        }
                    }

                    return StatusCode(StatusCodes.Status200OK, new { myObjects });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired, ex.Message);
            }
        }
    }
}
