using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Models
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Rol { get; set; }
    }
}
