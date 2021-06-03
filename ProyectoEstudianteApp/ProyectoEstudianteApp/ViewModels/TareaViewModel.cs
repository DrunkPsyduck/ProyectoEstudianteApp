using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.ViewModels
{
    public class TareaViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;

        public TareaViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.serviceEstudiante = serviceEstudiante;
            this.Tarea = new Tarea();
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

        public Command InsertarTarea
        {
            get
            {
                return new Command(async () =>
                {
                    await this.serviceEstudiante.InsertarTareaAsync(Tarea.NombreTarea, Tarea.DueDate, 1);
                    MessagingCenter.Send(App.ServiceLocator.TareasViewModel, "REFRESH");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Tarea insertada", "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
