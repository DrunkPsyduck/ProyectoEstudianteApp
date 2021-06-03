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
    public partial class GestionAmigos : TabbedPage
    {
        public GestionAmigos()
        {
            InitializeComponent();
            this.BackgroundColor = Color.PaleGoldenrod;
            this.BarTextColor = Color.Black;
            this.btnAñadirAmigo.Clicked += BtnAñadirAmigo_Clicked;
            this.BarBackgroundColor = Color.PaleGoldenrod;
        }

        private void BtnAñadirAmigo_Clicked(object sender, EventArgs e)
        {
            InsertarMensajeView view = new InsertarMensajeView();
            Application.Current.MainPage.Navigation.PushModalAsync(view);
        }

        private void btnApuntesAmigo_Clicked(object sender, EventArgs e)
        {
            MostrarApuntesAmigoView view = new MostrarApuntesAmigoView();
            Application.Current.MainPage.Navigation.PushModalAsync(view);
        }
    }
}