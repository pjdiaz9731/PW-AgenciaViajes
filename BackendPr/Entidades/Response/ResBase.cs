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
        public Usuario Usuario { get; set; }
        public bool resultado { get; set; }
        public List<Error> error { get; set; }
    }
}
