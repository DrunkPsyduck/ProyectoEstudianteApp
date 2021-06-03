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
    public class TareasViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;
        public TareasViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.serviceEstudiante = serviceEstudiante;
            Task.Run(async () =>
            {
                await this.LoadTareasAsync(); 
            });
            MessagingCenter.Subscribe<TareasViewModel>(this, "REFRESH", async (sender) =>
            {
                await this.LoadTareasAsync();
            });
        }

        private async Task LoadTareasAsync()
        {
            List<Tarea> tareas = await this.serviceEstudiante.GetTareasAsync(1);
            this.Tareas = new ObservableCollection<Tarea>(tareas);
        }

        public Command DatosTarea
        {
            get
            {
                return new Command((tarea) =>
                {
                    TareaEditarViewModel vm = App.ServiceLocator.TareaEditarViewModel;
                    TareaEditarView view = new TareaEditarView();
                    view.BindingContext = vm;
                    vm.Tarea = tarea as Tarea;
                    Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }

        private ObservableCollection<Tarea> _Tareas;
        public ObservableCollection<Tarea> Tareas
        {
            get { return this._Tareas; }
            set
            {
                this._Tareas = value;
                OnPropertyChanged("Tareas");
            }
        }
    }
}
