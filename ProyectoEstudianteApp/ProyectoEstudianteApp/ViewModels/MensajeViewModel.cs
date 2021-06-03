using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class MensajeViewModel : ViewModelBase
    {
        ServiceEstudiante service;

        public MensajeViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.service = serviceEstudiante;
            this.Mensaje = new Mensaje();
            
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

        public Command InsertarMensaje
        {
            get
            {
                return new Command(async () =>
                {
                    await this.service.InsertarMensajeAsync(Mensaje.Message, "userAWS", Mensaje.UsernameTo);
                    MessagingCenter.Send(App.ServiceLocator.MensajesViewModel, "RELOAD");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
