using Capa.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Models
{
    public class ServicesModels : Services
    {
        public int IdSer { get; set; }
        public int IdCom { get; set; }
        public string Nom { get; set; }
        public TimeSpan HoraApertur { get; set; }
        public TimeSpan HoraCierr { get; set; }
        public string Duracio { get; set; }
    }
}
