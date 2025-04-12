using BackendPr.AccesoDatos;
using BackendViajes.Entidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPr.logica
{
    public class LogicaBlog
    {
        public ResInsertarBlog Insertar(ResInsertarBlog req)
        {
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
    }
}




