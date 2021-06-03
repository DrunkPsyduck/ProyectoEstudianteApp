using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Models
{
    public class Relacion
    {
        public int IdRelacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdAmigo { get; set; }
        public String Username { get; set; }
        public String UsernameAmigo { get; set; }
    }
}
