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
    public class Blog
    {
        public ResInsertarBlog Insertar(ResInsertarBlog req)
        {
            ResInsertarBlog res = new ResInsertarBlog();
            //Se omiten validacion
            int? idBD = 0;
            int? errorIDBD = 0;
            string errorDesc = "";

            using (LinqConnecDataContext linq = new LinqConnecDataContext())
            {
                linq.sp_Blog_Insertar(req.Blog.Titulo, req.Blog.Contenido, req.Blog.Imagen, ref idBD);


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
        }
    }
}



