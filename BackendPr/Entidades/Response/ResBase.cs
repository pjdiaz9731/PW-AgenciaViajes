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
<<<<<<< HEAD
        public Usuario Usuario { get; set; }

        public Reservas Reservas { get; set;  }
        public bool resultado { get; set; }
        public List<Error> error { get; set; }
=======
       public string contrasena { get; set; }
        public string usuario { get; set; }
        public Reservas Reservas { get; set;  }
        public bool resultado { get; set; }
        public List<Error> error { get; set; }
        public bool Resultado { get; set; }
        
       
>>>>>>> 3f593ee82dcad5985bccb27237c4af37ade93c64
    }
}
