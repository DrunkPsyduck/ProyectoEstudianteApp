using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProyectoEstudianteApp.Helpers
{
    public enum Folders
    {
        MyDocuments = 1 
    }
    public class PathProvider
    {
        public String MapPath(String documentPath, String filename)
        {
            //String carpeta = "";
            //if(documentPath == Folders.MyDocuments)
            //{
            //    carpeta = "MyDocuments";
            //}

            String path = Path.Combine(documentPath,
                filename);
            return path;
        }
    }
}
