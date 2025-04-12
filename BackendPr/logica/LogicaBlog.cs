using BackendPr.AccesoDatos;
using BackendViajes.Entidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Text;
=======
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
using System.Threading.Tasks;

namespace BackendPr.logica
{
    public class LogicaBlog
    {
        public ResInsertarBlog Insertar(ResInsertarBlog req)
        {
<<<<<<< HEAD
            // Inicialización de la respuesta
            ResInsertarBlog res = new ResInsertarBlog();
            res.error = new List<Error>();

            // Variables para manejar el resultado de la operación en la base de datos
            int? idBD = 0;
            int? errorIDBD = 0;
            string errorDesc = "";

            // Uso del contexto de datos para ejecutar el procedimiento almacenado
            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                // Llamada al procedimiento almacenado para insertar un blog
                linq.sp_Blog_Insertar(
                    req.Blog.Titulo,      
                    req.Blog.Contenido,   
                    req.Blog.Autor,       
                    req.Blog.UsuarioID,   
                    ref idBD,             
                    ref errorDesc     
                );

                // Verificación del resultado de la operación
                if (idBD > 0)
                {
                    // Si se generó un ID válido, la operación fue exitosa
                    res.resultado = true;
                }
                else
                {
                    // Si no se generó un ID válido, la operación falló
                    res.resultado = false;
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.errorEnBaseDatos, // Código de error
                        errorMsg = errorDesc != "" ? errorDesc : "Algo falló al insertar el blog" // Mensaje de error
                    });
                }

                // Retorno de la respuesta
                return res;
            }
        }
=======
            ResInsertarBlog res = new ResInsertarBlog();
            //Se omiten validacion
            int? idBD = 0;
            int? errorIDBD = 0;
            string errorDesc = "";
            List<sp_Blog_ObtenerResult> miListaTipoComplejo = new List<sp_Blog_ObtenerResult>();

            // Validación: si el request o el objeto usuario son nulos
            if (req == null || req.usuario == null)
            {

                res.error.Add(new Error
                {
                    codigoError = enumErrores.reqNulo,
                    errorMsg = "El request o el objeto usuario es nulo"
                });
                res.Resultado = false;
                return res;
            }

            // Validaciones del usuario
            if (string.IsNullOrWhiteSpace(req.Blog.nombre))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.nombreInvalido,
                    errorMsg = "Nombre completo requerido"
                });
            }

            if (string.IsNullOrWhiteSpace(req.Blog.email))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.correoFaltante,
                    errorMsg = "Correo requerido"
                });
            }
            else if (!EsCorreoValido(req.Blog.email))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.correoNoValido,
                    errorMsg = "Correo no válido"
                });
            }

            if (!EsLinkValido(req.Blog.sitioWeb))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.NoLink,
                    errorMsg = "Ingrese algun link propio de referencia"
                });
            }
            else if (string.IsNullOrWhiteSpace(req.Blog.comentario))
            {
                res.error.Add(new Error
                {
                    codigoError = enumErrores.Nocoment,
                    errorMsg = "Ingrese su comentario"
                });
            }

            // Si hubo errores en la validación, regresamos el resultado con errores
            if (res.error.Any())
            {
                res.Resultado = false;
                return res;
            }
            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                linq.sp_ComentariosBlog_Insertar(req.Blog.nombre, req.Blog.email, req.Blog.comentario, req.Blog.sitioWeb,
                    ref errorDesc, ref idBD, ref  errorIDBD);

                miListaTipoComplejo = linq.sp_Blog_Obtener(req.usuarioID).ToList();
            }
            if (idBD > 0)
            {
                res.resultado = true;
            }
            else
            {
                Error error = new Error();
                error.codigoError = enumErrores.errorEnBaseDatos;
                error.errorMsg = "Algo fallo";
                res.error.Add(error);
            }

            return res;
        }
        private bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }
        private bool EsLinkValido(string link)
        {
            try
            {
                // Expresión regular para validar URL
                var regex = new Regex(@"^(https?://)?(www\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}(/.*)?$");
                return regex.IsMatch(link);
            }
            catch
            {
                return false;
            }
        }

>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
    }
}



<<<<<<< HEAD

=======
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
