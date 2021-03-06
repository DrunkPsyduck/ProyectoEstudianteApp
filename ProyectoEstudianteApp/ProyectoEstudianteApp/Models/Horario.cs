using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Models
{
    public class Horario
    {
        [JsonProperty("idClase")]
        public int IdClase { get; set; }

        [JsonProperty("asignatura")]
        public String Asignatura { get; set; }

        [JsonProperty("horaEmpiece")]
        public String HoraEmpiece { get; set; }

        [JsonProperty("horaFinal")]
        public String HoraFinal { get; set; }

        [JsonProperty("dia")]
        public String dia { get; set; }

        [JsonProperty("userId")]
        public int IdUsuario { get; set; }
    }
}
