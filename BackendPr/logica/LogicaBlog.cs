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
            ResInsertarBlog res = new ResInsertarBlog();
            res.error = new List<Error>();

            //Se omiten validacion
            int? idBD = 0;
            int? errorIDBD = 0;
            string errorDesc = "";

            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                linq.sp_Blog_Insertar(
                    req.Blog.Titulo,
                    req.Blog.Contenido,
                    req.Blog.Autor,
                    req.Blog.UsuarioID,
                    ref idBD,
                    ref errorDesc
                );

                if (idBD > 0)
                {
                    res.resultado = true;
                }
                else
                {
                    res.resultado = false;
                    res.error.Add(new Error
                    {
                        codigoError = enumErrores.errorEnBaseDatos,
                        errorMsg = errorDesc != "" ? errorDesc : "Algo falló al insertar el blog"
                    });
                }

                return res;
            }
        }
    }
}