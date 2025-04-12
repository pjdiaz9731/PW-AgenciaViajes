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
        
        public  bool Resultado { get; set; } 

        public List<Error> Error { get; set; }
    }
}
