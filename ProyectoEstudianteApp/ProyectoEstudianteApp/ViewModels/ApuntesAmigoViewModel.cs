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
    public class ApuntesAmigoViewModel : ViewModelBase
    {

        ServiceEstudiante service;

        public ApuntesAmigoViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.service = serviceEstudiante;
            Task.Run(async () =>
            {
                await this.LoadArchivosAmigosAsync();
            });
            MessagingCenter.Subscribe<ArchivosViewModel>(this, "REFRESH", async (sender) =>
            {
                await this.LoadArchivosAmigosAsync();
            });
        }


        private ObservableCollection<Archivo> _ArchivosAmigos;
        public ObservableCollection<Archivo> ArchivosAmigos
        {
            get { return this._ArchivosAmigos; }
            set
            {
                this._ArchivosAmigos = value;
                OnPropertyChanged("ArchivosAmigos");
            }
        }


        private async Task LoadArchivosAmigosAsync()
        {
            List<Archivo> archivos = await this.service.GetApuntesAmigoAsync(5);
            this.ArchivosAmigos = new ObservableCollection<Archivo>(archivos);
        }
    }
}
