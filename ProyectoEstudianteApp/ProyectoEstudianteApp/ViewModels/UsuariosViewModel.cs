using ProyectoEstudianteApp.Base;
using ProyectoEstudianteApp.Models;
using ProyectoEstudianteApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudianteApp.ViewModels
{
    public class UsuariosViewModel : ViewModelBase
    {
        ServiceEstudiante serviceEstudiante;
        public UsuariosViewModel(ServiceEstudiante serviceEstudiante)
        {
            this.serviceEstudiante = serviceEstudiante;
        }

        //private async Task LoadUsuariosAsync()
        //{
        //    List<Usuario> usuarios = new List<Usuario>();

        //}

        private ObservableCollection<Usuario> _Usuarios;
        private ObservableCollection<Usuario> Usuarios
        {
            get { return this._Usuarios; }
            set
            {
                this._Usuarios = value;
                OnPropertyChanged("Usuarios");
            }
        }
    }
}
