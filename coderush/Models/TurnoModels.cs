using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Models
{
    public class TurnoModels
    {
        
        public int IdServicios { get; set; }
        public DateTime FechaTurna { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }
    }
}
