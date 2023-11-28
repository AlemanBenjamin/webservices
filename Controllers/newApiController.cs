using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Reflection.Metadata.Ecma335;
using Webservices.Modelos;

namespace Webservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class newApiController : ControllerBase
    {

        private string connectionString = @"Server=localhost ;Database= BDusuarios;Uid= root;Pwd= ieX.tra2.;";


        [HttpPost]

        public IActionResult Post(Usuario usuariomodelo)
        {
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                var conex = "insert into usuarios(name, email, contraseña"+"" +
                    "values(@name, @email, @contraseña)";
                result = conn.Execute(conex, usuariomodelo);

            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Usuario> lista = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                var conex = "select id, name, email from usuarios";

                lista = conn.Query<Usuario>(conex);

            };
            return Ok(lista);
        }

        [HttpPut]
        public IActionResult Put(Usuario usuariomodelo)
        {
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                var conex = "update usuarios set name=@name, email=@email, contraseña=@contraseña"+
                    "where id= @id" ;
                result = conn.Execute(conex, usuariomodelo);

            }
            return Ok(result);

        }

        [HttpDelete]

        public IActionResult Delete(Usuario usuariomodelo)
        {
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                var conex = "delete from usuarios where id=@id";
                result = conn.Execute(conex, usuariomodelo);

            }
            return Ok(result);

        }


    } }


    