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
    public partial class MostrarTareas : ContentPage
    {
        public MostrarTareas()
        {
            InitializeComponent();
            this.btnCrearTarea.Clicked += BtnCrearTarea_Clicked;
        }

        private void BtnCrearTarea_Clicked(object sender, EventArgs e)
        {
            InsertarTarea viewInserta = new InsertarTarea();
            Application.Current.MainPage.Navigation.PushModalAsync(viewInserta);
        }
    }
}