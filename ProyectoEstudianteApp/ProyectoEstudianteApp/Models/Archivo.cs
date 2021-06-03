using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Models
{
    public class Archivo
    {
        public int IdArchivo { get; set; }
        public String NombreArchivo { get; set; }
        public String Path { get; set; }
        public int UserId { get; set; }
    }
}
