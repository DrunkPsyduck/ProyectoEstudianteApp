using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudianteApp.Helpers
{
    public class UploadService
    {
        PathProvider pathProvider;
        public UploadService(PathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
        }

    }
}
