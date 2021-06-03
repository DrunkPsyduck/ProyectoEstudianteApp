using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Models
{
    public class Mensaje
    {
        public int IdMensaje { get; set; }
        public int IdUserFrom { get; set; }
        public int IdUserTo { get; set; }
        public String Message { get; set; }
        public String UsernameFrom { get; set; }
        public String UsernameTo { get; set; }
    }
}
