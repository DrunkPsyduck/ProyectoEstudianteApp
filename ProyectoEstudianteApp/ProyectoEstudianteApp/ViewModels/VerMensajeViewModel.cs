using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class VerMensajeViewModel: ViewModelBase
    {
        ServiceEstudiante service;

        public VerMensajeViewModel(ServiceEstudiante service)
        {
            this.service = service;
        }

        private Mensaje _Mensaje;

        public Mensaje Mensaje
        {
            get { return this._Mensaje; }
            set
            {
                this._Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        public Command EliminarMensaje
        {
            get
            {
                return new Command(async () =>
                {
                    await this.service.DeleteMensajeAsync(Mensaje.IdMensaje);
                    MessagingCenter.Send(App.ServiceLocator.MensajesViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command AddAmigo
        {
            get
            {
                return new Command(async () =>
                {
                    await this.service.InsertarRelacionAAsync(Mensaje.UsernameFrom, Mensaje.UsernameTo);
                    await this.service.InsertarRelacionBAsync(Mensaje.UsernameFrom,Mensaje.UsernameTo);
                    await this.service.DeleteMensajeAsync(Mensaje.IdMensaje);
                    MessagingCenter.Send(App.ServiceLocator.MensajesViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

    }
}
