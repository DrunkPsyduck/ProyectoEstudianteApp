using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class ArchivoViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;

        public ArchivoViewModel(ServiceEstudiante service)
        {
            this.serviceEstudiante = service;
            this.Archivo = new Archivo();
        }

        private Archivo _Archivo; 

        public Archivo Archivo
        {
            get { return this._Archivo; }
            set
            {
                this._Archivo = value;
                OnPropertyChanged("Archivo");
            }
        }

        public Command InsertarArchivo
        {
            get
            {
                return new Command(async (lbl) =>
                {
                    Label label = lbl as Label;
                    String path = label.Text;
                    Archivo.Path = path;
                    await this.serviceEstudiante.InsertarArchivosAsync(Archivo.NombreArchivo,Archivo.Path,1);
                    MessagingCenter.Send(App.ServiceLocator.ArchivosViewModel, "REFRESH");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Archivo insertado", "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
