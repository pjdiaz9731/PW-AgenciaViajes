using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPr.Entidades
{
    public class Reservas
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CantidadAdultos { get; set; }

    }
}
