using Autofac;
using ProyectoEstudianteApp.Helpers;
using ProyectoEstudianteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstudianteApp.Services
{
    public class ServiceIoC
    {
        IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }
        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<TareasViewModel>();
            builder.RegisterType<TareaEditarViewModel>();
            builder.RegisterType<ServiceEstudiante>();

            builder.RegisterType<TareaViewModel>();

            builder.RegisterType<UsuariosViewModel>();
            builder.RegisterType<AddUsuarioViewModel>();

            builder.RegisterType<AmigosViewModel>();
            builder.RegisterType<MensajesViewModel>();
            builder.RegisterType<VerMensajeViewModel>();
            builder.RegisterType<MensajeViewModel>();

            builder.RegisterType<ArchivosViewModel>();
            builder.RegisterType<ArchivoViewModel>();

            builder.RegisterType<HorarioViewModel>();

            builder.RegisterType<ApuntesAmigoViewModel>();
            //builder.RegisterType<PathProvider>();
            this.container = builder.Build();
        }

        //public HorarioViewModel HorarioViewModel
        //{
        //    get
        //    {
        //        return this.container.Resolve<HorarioViewModel>();
        //    }
        //}

        public ApuntesAmigoViewModel ApuntesAmigoViewModel
        {
            get
            {
                return this.container.Resolve<ApuntesAmigoViewModel>();
            }
        }

        public ArchivosViewModel ArchivosViewModel
        {
            get
            {
                return this.container.Resolve<ArchivosViewModel>();
            }
        }

        public ArchivoViewModel ArchivoViewModel
        {
            get
            {
                return this.container.Resolve<ArchivoViewModel>();
            }
        }

        public MensajeViewModel MensajeViewModel
        {
            get
            {
                return this.container.Resolve<MensajeViewModel>();
            }
        }

        public VerMensajeViewModel VerMensajeViewModel
        {
            get
            {
                return this.container.Resolve<VerMensajeViewModel>();
            }
        }

        public AmigosViewModel AmigosViewModel
        {
            get
            {
                return this.container.Resolve<AmigosViewModel>();
            }
        } 

        public MensajesViewModel MensajesViewModel
        {
            get
            {
                return this.container.Resolve<MensajesViewModel>();
            }
        }
        
        public TareaViewModel TareaViewModel
        {
            get
            {
                return this.container.Resolve<TareaViewModel>();
            }
        }

        public TareasViewModel TareasViewModel
        {
            get
            {
                return this.container.Resolve<TareasViewModel>();
            }
        }

        public TareaEditarViewModel TareaEditarViewModel
        {
            get
            {
                return this.container.Resolve<TareaEditarViewModel>();
            }
        }

        public AddUsuarioViewModel AddUsuarioViewModel
        {
            get
            {
                return this.container.Resolve<AddUsuarioViewModel>();
            }
        }

        public UsuariosViewModel UsuariosViewModel
        {
            get
            {
                return this.container.Resolve<UsuariosViewModel>();
            }
        }

        public HorarioViewModel HorarioViewModel
        {
            get
            {
                return this.container.Resolve<HorarioViewModel>();
            }
        }
    }
}
