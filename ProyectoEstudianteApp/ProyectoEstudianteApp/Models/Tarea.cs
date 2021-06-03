using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Models
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public String NombreTarea { get; set; }
        public DateTime DueDate { get; set; } 
        public int UserId { get; set; }
    }

}
