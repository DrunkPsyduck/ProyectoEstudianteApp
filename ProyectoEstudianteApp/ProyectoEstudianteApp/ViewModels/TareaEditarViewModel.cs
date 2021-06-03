using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class TareaEditarViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;

        public TareaEditarViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.serviceEstudiante = serviceEstudiante;
        }

        private Tarea _Tarea;
        public Tarea Tarea
        {
            get { return this._Tarea; }
            set
            {
                this._Tarea = value;
                OnPropertyChanged("Tarea");
            }
        }

        public Command EliminarTarea
        {
            get
            {
                return new Command(async () =>
                {
                    await this.serviceEstudiante.DeleteTareaAsync(Tarea.IdTarea);
                    MessagingCenter.Send(App.ServiceLocator.TareasViewModel, "REFRESH");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Tarea: " + Tarea.NombreTarea
                        + " eliminada. ", "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command EditarTarea
        {
            get
            {
                return new Command(async () =>
                {
                    await this.serviceEstudiante.UpdateTareaAsync(Tarea.IdTarea, Tarea.NombreTarea, Tarea.DueDate);
                    MessagingCenter.Send(App.ServiceLocator.TareasViewModel, "REFRESH");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Tarea: " + Tarea.NombreTarea
                        + " editada. ", "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
