using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class AddUsuarioViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;
        public AddUsuarioViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.serviceEstudiante = serviceEstudiante;
            this.Usuario = new Usuario();
        }

        private Usuario _Usuario;
        public Usuario Usuario
        {
            get { return this._Usuario; }
            set
            {
                this._Usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        public Command AgregarUsuario
        {
            get
            {
                return new Command(async () =>
                {
                    await this.serviceEstudiante.InsertarUsuarioAsync(Usuario.UserName, Usuario.Password, Usuario.Rol);
                    await Application.Current.MainPage.DisplayAlert("Alert", "Usuario: " + Usuario.UserName
                        + " creado. ", "OK");
                    MessagingCenter.Send(App.ServiceLocator.AddUsuarioViewModel
                      , "REFRESH");
                    //await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
