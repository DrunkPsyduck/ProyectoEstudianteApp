using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class AmigosViewModel : ViewModelBase
    {
        //DISEÑO: LISTVIEW
        ServiceEstudiante service;

        public AmigosViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.service = serviceEstudiante;
            Task.Run(async () =>
            {
                await this.LoadAmigosAsync();
            });
            MessagingCenter.Subscribe<AmigosViewModel>(this, "REFRESH", async (sender) =>
            {
                await this.LoadAmigosAsync();
            });
        }

        private async Task LoadAmigosAsync()
        {
            List<Relacion> amigos = await this.service.MostrarAmigosAsync("usuario");
            this.Amigos = new ObservableCollection<Relacion>(amigos);
        }

        private ObservableCollection<Relacion> _Amigos;
        public ObservableCollection<Relacion> Amigos
        {
            get { return this._Amigos; }
            set
            {
                this._Amigos = value;
                OnPropertyChanged("Amigos");
            }
        }
    }
}
