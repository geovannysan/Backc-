using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backrest.Data;
using MySql.Data.MySqlClient;

namespace Backrest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ticktesApiController : ControllerBase
    {
        private ConectionMsql connectionHelper;

        public ticktesApiController()
        {
            
            connectionHelper = new ConectionMsql();
        }

        [HttpGet("listaritems")]
        public ActionResult Get()
        {
            connectionHelper.OpenConnection();
            try
            {
                string query = "SELECT * FROM localidades_items ";
                MySqlCommand command = new MySqlCommand(query, connectionHelper.GetConnection());

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Crear una lista para almacenar los resultados
                    List<object> results = new List<object>();
                    // Saltar registros hasta llegar a la página deseada
                    int pageIndex = 0;
                    int pageSize = 100; // Número de registros por página

                    for (int i = 0; i < (pageIndex * pageSize); i++)
                    {
                        if (!reader.Read())
                        {
                            // Se ha alcanzado el final de los registros disponibles
                           // return;
                        }
                    }
                    while (reader.Read())
                    {
                        // Acceder a los datos del resultado de la consulta
                        int id = reader.GetInt32("id");
                        //   string nombre = reader.GetString("nombre");

                        // Crear un objeto con los datos y agregarlo a la lista
                        var result = new { Id = id };
                        results.Add(result);
                    }

                    return StatusCode(StatusCodes.Status200OK, results);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connectionHelper.CloseConnection();
            }
        }
        //NO CANJEADO
        [HttpPut("eliminaritem")]
        public ActionResult Delete(int id)
        {
            connectionHelper.OpenConnection();

            try
            {
              string query1 =  $"UPDATE localidades_items  SET estado = 'ocupado', cedula='1724201841'  WHERE id = {id};";
                //string query = $"DELETE FROM localidades_items WHERE id = {id};";
                MySqlCommand command = new MySqlCommand(query1, connectionHelper.GetConnection());
                int rowsAffected = command.ExecuteNonQuery();
                return StatusCode(StatusCodes.Status200OK, rowsAffected);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connectionHelper.CloseConnection();
            }
        }
        [HttpPut("estado")]
        public ActionResult actuia(int id)
        {
            connectionHelper.OpenConnection();

            try
            {
              string query1 =  $"UPDATE ticket_usuarios  SET estado = 'CANJEADO'  WHERE id = {id};";
                //string query = $"DELETE FROM localidades_items WHERE id = {id};";
                MySqlCommand command = new MySqlCommand(query1, connectionHelper.GetConnection());
                int rowsAffected = command.ExecuteNonQuery();
                return StatusCode(StatusCodes.Status200OK, rowsAffected);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connectionHelper.CloseConnection();
            }
        }
        [HttpDelete("eliminaritem")]
        public ActionResult Deletes(int id)
        {
            connectionHelper.OpenConnection();

            try
            {
              //string query1 =  $"UPDATE localidades_items  SET estado = 'disponible', cedula=''  WHERE id = {id};";
                string query = $"DELETE FROM localidades_items WHERE id = {id};";
                MySqlCommand command = new MySqlCommand(query, connectionHelper.GetConnection());
                int rowsAffected = command.ExecuteNonQuery();
                return StatusCode(StatusCodes.Status200OK, rowsAffected);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                connectionHelper.CloseConnection();
            }
        }
    }
}
