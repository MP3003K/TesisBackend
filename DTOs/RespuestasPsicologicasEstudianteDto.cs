using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RespuestasPsicologicasEstudianteDto
    {
        public int? PromedioEstudiante { get; set; }
        public IList<EscalaPsicologicaDto>? EscalasPsicologicos { get; set; }
    }
}
