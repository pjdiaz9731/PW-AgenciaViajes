using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendViajes.Entidades
{
    public class ResInsertarUsuario : ResBase
    {
        public Usuario Usuario { get; set; }
        public bool resultado { get; set; }
        public List<Error> error { get; set; }
    }
}
