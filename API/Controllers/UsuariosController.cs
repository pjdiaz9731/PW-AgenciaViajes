using System.Web.Http;
using BackendViajes.Entidades; // Para ReqInsertarUsuario y ResInsertarUsuario
using BackendPr.logica;
using System.Linq;
using System; // Asegúrate de tener la referencia correcta a la lógica de negocio

namespace BackendPr.Controllers
{
    /// <summary>
    /// Controlador para las operaciones relacionadas con usuarios.
    /// </summary>
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        /// <summary>
        /// Inserta un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="req">El objeto con los datos del usuario a insertar.</param>
        /// <returns>Un objeto con el estado de la operación y los mensajes de error si los hay.</returns>
        /// <response code="200">Usuario insertado correctamente.</response>
        /// <response code="400">Solicitud incorrecta (por ejemplo, datos inválidos).</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpPost]
        [Route("insertar")]
        public IHttpActionResult InsertarUsuario([FromBody] ReqInsertarUsuario req)
        {
            // Verificamos que el objeto recibido no sea nulo
            if (req == null || req.Usuario == null)
            {
                return BadRequest("El request o el objeto usuario es nulo.");
            }

            try
            {
                // Creamos la instancia de la lógica de negocio
                var logica = new LogicaUsuario();
                var res = logica.Insertar(req);

                // Si el resultado de la lógica es falso, devolvemos el error
                if (!res.Resultado)
                {
                    var errores = string.Join(", ", res.error.Select(e => e.errorMsg));
                    return BadRequest(errores);
                }

                // Si la inserción fue exitosa, retornamos el resultado con código 200
                return Ok(res);
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción inesperada
                return InternalServerError(new Exception("Error inesperado: " + ex.Message));
            }
        }
    }
}
