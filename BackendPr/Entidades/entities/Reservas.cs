using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPr.Entidades
{
    public class Reservas
    {
        public int UsuarioID { get; set; }
        public int CantidadPersonas { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        

    }
}
