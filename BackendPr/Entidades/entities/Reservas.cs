using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPr.Entidades
{
    public class Reservas
    {
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public int? CantidadAdultos { get; set; }
        
        

    }
}
