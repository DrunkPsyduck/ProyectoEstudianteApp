using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoEstudianteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarApuntesView : ContentPage
    {
        public MostrarApuntesView()
        {
            InitializeComponent();
            this.btnInsertarArchivo.Clicked += BtnInsertarArchivo_Clicked;
        }



        private void BtnInsertarArchivo_Clicked(object sender, EventArgs e)
        {
            InsertarApuntes view = new InsertarApuntes();
            Application.Current.MainPage.Navigation.PushModalAsync(view);
        }


    }
}