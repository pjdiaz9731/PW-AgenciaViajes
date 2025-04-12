using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Blog
    {
       
        public string nombre {  get; set; }
        public string email { get; set; }
        public string sitioWeb { get; set; }
        public string comentario { get; set; }
        public int? usuarioID { get; set; }
       
      
    }
}
