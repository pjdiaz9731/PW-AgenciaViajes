using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendViajes.Entidades.Request
{
    public class ReqInsertarBlog
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Autor { get; set; }
        public int UsuarioID { get; set; }
    }
}
