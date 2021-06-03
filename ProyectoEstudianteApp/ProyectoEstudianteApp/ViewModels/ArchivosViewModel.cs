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
    public class ArchivosViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;
        public ArchivosViewModel(ServiceEstudiante service)
        {
            this.serviceEstudiante = service;
            Task.Run(async () =>
            {
                await this.LoadArchivosAsync();
            });
            MessagingCenter.Subscribe<ArchivosViewModel>(this, "REFRESH", async (sender) =>
            {
                await this.LoadArchivosAsync();
            });
        }

        private ObservableCollection<Archivo> _Archivos;
        public ObservableCollection<Archivo> Archivos
        {
            get { return this._Archivos; }
            set
            {
                this._Archivos = value;
                OnPropertyChanged("Archivos");
            }
        }

        private async Task LoadArchivosAsync()
        {
            List<Archivo> archivos = await this.serviceEstudiante.GetArchivosUserAsync(1);
            this.Archivos = new ObservableCollection<Archivo>(archivos);
        }

    }
}
