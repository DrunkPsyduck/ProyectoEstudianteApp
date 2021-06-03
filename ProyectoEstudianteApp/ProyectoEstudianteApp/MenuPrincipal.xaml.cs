using ProyectoEstudianteApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoEstudianteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : MasterDetailPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            List<MasterPageItem> paginas = new List<MasterPageItem>();
            var page1 =
                new MasterPageItem()
                {
                    Titulo = "Tareas"
                ,
                    PaginaHija = typeof(MostrarTareas)
                };
            var page2 =
                new MasterPageItem()
                {
                    Titulo = "Apuntes"
                ,
                    PaginaHija = typeof(MostrarApuntesView)
                };
            var page3 =
                new MasterPageItem()
                {
                    Titulo = "Amigos"
                ,
                    PaginaHija = typeof(GestionAmigos)
                };
            var page4 = new MasterPageItem()
            {
                Titulo = "Horario",
                PaginaHija = typeof(HorarioView)
            };
            paginas.Add(page1);
            paginas.Add(page2);
            paginas.Add(page3);
            paginas.Add(page4);

            this.lisviewMenu.ItemsSource = paginas;
            this.Detail =
                new NavigationPage
                ((Page)Activator.CreateInstance(typeof(MostrarTareas)))
                { BarBackgroundColor = Color.PaleGoldenrod};
            this.lisviewMenu.ItemSelected += LisviewMenu_ItemSelected;
        }

        private void LisviewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var page = (MasterPageItem)e.SelectedItem;
            Type type = page.PaginaHija;
            this.Detail = new NavigationPage((Page)
                Activator.CreateInstance(type))
            { BarBackgroundColor = Color.PaleGoldenrod }; ;
            this.IsPresented = false;
        }
    }
}