using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJson.Models
{
    internal class Persona
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Celular { get; set; }
        public string? email { get; set; }
        public DateTime FechaCumple { get; set; }
        public string? Foto { get; set; }
        public int idGrupo { get; set; }

    }
}
