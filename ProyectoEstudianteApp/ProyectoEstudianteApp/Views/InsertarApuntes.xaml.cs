using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.FilePicker;
using ProyectoEstudianteApp.Models;
using System.IO;
using ProyectoEstudianteApp.Helpers;

namespace ProyectoEstudianteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarApuntes : ContentPage
    {
        PathProvider pathProvider;
        public InsertarApuntes()
        {
            InitializeComponent();
            this.pathProvider = new PathProvider();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string localpath = Path.Combine(documentPath, file.FileName);
            String path = this.pathProvider.MapPath(documentPath, file.FileName);

            if (file != null)
            {
                lbl.Text = path;
                //lblpath.Text = path;
            }
            
            
        }
    }
}