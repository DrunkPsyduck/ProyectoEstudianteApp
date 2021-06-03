using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using ProyectoEstudianteApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class MensajesViewModel : ViewModelBase
    {
        ServiceEstudiante service;

        public MensajesViewModel(ServiceEstudiante service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                await this.LoadMensajesAsync();
            });
            MessagingCenter.Subscribe<MensajesViewModel>(this, "RELOAD", async (sender) =>
            {
                await this.LoadMensajesAsync();
            });
        }

        private async Task LoadMensajesAsync()
        {
            List<Mensaje> mensajes = await this.service.GetMensajesUserAsync(1);
            this.Mensajes = new ObservableCollection<Mensaje>(mensajes);
            
        }

        public Command DetallesMensaje
        {
            get
            {
                return new Command((mensaje) =>
                {
                    VerMensajeViewModel vm = App.ServiceLocator.VerMensajeViewModel;
                    MostrarMensaje view = new MostrarMensaje();
                    view.BindingContext = vm;
                    vm.Mensaje = mensaje as Mensaje;
                    Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }

        private ObservableCollection<Mensaje> _Mensajes; 

        public ObservableCollection<Mensaje> Mensajes
        {
            get { return this._Mensajes; }
            set
            {
                this._Mensajes = value;
                OnPropertyChanged("Mensajes");
            }
        }
    }
}
