using BackendPr.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResBase
    {
        public Contacto Contacto { get; set; }
       public string contrasena { get; set; }
        public string usuario { get; set; }
        public Reservas Reservas { get; set;  }
        public bool resultado { get; set; }
        public List<Error> error { get; set; }
        public bool Resultado { get; set; }
        
       
    }
}
