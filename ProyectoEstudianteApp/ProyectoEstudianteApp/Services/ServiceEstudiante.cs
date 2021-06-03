using MonkeyCache.FileStore;
using Newtonsoft.Json;
using ProyectoEstudianteApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudianteApp.Services
{
    public class ServiceEstudiante
    {
        private String url;
        public ServiceEstudiante()
        {
            this.url = "https://estudianteappservicioxamaml.azurewebsites.net/";
        }

        private async Task<T> CallApiAsync<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json =
                        await response.Content.ReadAsStringAsync();
                    T data =
                        JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        #region TAREAS
        public async Task<List<Tarea>> GetTareasAsync(int idUser)
        {
            String request = "api/Tareas/GetTareasUser/" + idUser;
            Uri uri = new Uri(this.url + request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                String data = await response.Content.ReadAsStringAsync();
                List<Tarea> tareas = JsonConvert.DeserializeObject<List<Tarea>>(data);
                return tareas;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tarea> FindTareaAsync(int id)
        {
            String request = "api/Tareas/" + id;
            Tarea tareas = await this.CallApiAsync<Tarea>(request);
            return tareas;
        }

        public async Task InsertarTareaAsync(String nombreTarea, DateTime dueDate, int userId)
        {
            Tarea tarea = new Tarea();
            tarea.NombreTarea = nombreTarea;
            tarea.DueDate = dueDate;
            tarea.UserId = userId;
            String json = JsonConvert.SerializeObject(tarea);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                String request = "api/Tareas";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response = await client.PostAsync(uri, content);
            }
        }

        public async Task UpdateTareaAsync(int idTarea, String nombreTarea, DateTime dueDate)
        {
            Tarea tareas = await this.FindTareaAsync(idTarea);
            tareas.NombreTarea = nombreTarea;
            tareas.DueDate = dueDate;
            String json = JsonConvert.SerializeObject(tareas);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                String request = "api/Tareas";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response = await client.PutAsync(uri, content);
            }
        }

        public async Task DeleteTareaAsync(int id)
        {
            String request = "api/Tareas/" + id;
            Uri uri = new Uri(this.url + request);
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(uri);
            }
        }
        #endregion


        #region HORARIO
        public async Task<List<Horario>> GetHorario(String dia)
        {
            //Cambiar con el login
            //Usuario user = Barrel.Current.Get<Usuario>("USUARIO");
            //String usuario = user.IdUser.ToString();
            String request = "/api/Horario/GetClasesUser/" + 1 + "/" + dia;
            List<Horario> clases = await this.CallApiAsync<List<Horario>>(request);
            return clases;

        }

        #endregion

        #region APUNTES
        public async Task<List<Archivo>> GetArchivosUserAsync(int idUser)
        {
            String request = "api/Apuntes/GetApuntesUser/" + idUser;
            return await this.CallApiAsync<List<Archivo>>(request);
        }


        public async Task<Archivo> FindArchivoAsync(int id)
        {
            String request = "api/Apuntes/" + id;
            return await this.CallApiAsync<Archivo>(request);
        }

        public async Task<List<Archivo>> GetApuntesAmigoAsync(int friendid)
        {
            String request = "api/Apuntes/GetApuntesFriend/" + friendid;
            return await this.CallApiAsync<List<Archivo>>(request);
        }

        public async Task InsertarArchivosAsync(String nombreArchivo, String path, int userId)
        {
            Archivo archivo = new Archivo();
            archivo.NombreArchivo = nombreArchivo;
            archivo.Path = path;
            archivo.UserId = userId;
            String json = JsonConvert.SerializeObject(archivo);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                String request = "api/Apuntes";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage responseMessage = await client.PostAsync(uri, content);
            }
        }

        public async Task DeleteArchivosAsync(int id)
        {
            String request = "api/Apuntes/" + id;
            Uri uri = new Uri(this.url + request);
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(uri);
            }
        }

        #endregion

        #region USUARIOS
        public async Task<Usuario> GetUsuarioAsync(String username, String password)
        {
            String request = "api/Usuario/GetUsuario/" + username + "/" + password;
            return await this.CallApiAsync<Usuario>(request);
        }
        public async Task<int> BuscarUserId(String username)
        {
            String request = "api/Usuario/BuscarUserId/" + username;
            return await this.CallApiAsync<int>(request);
        }

        public async Task<List<Usuario>> BuscadorUsuarios(String username)
        {
            String request = "api/Usuario/BuscadorUsuarios/" + username;
            return await this.CallApiAsync<List<Usuario>>(request);
        }

        public async Task InsertarUsuarioAsync(String userName, String password,
            String rol)
        {
            Usuario user = new Usuario();
            user.UserName = userName;
            user.Password = password;
            user.Rol = rol;
            String json = JsonConvert.SerializeObject(user);
            StringContent content =
               new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/Usuario";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response =
                    await client.PostAsync(uri, content);
            }
        }
        #endregion

        #region MENSAJES 
        public async Task<List<Mensaje>> GetMensajesUserAsync(int idUser)
        {
            String request = "api/Mensajes/GetMensajesUser/" + idUser;
            return await this.CallApiAsync<List<Mensaje>>(request);
        }

        public async Task<Mensaje> GetMensajeAsync(int id)
        {
            String request = "api/Mensajes/" + id;
            return await this.CallApiAsync<Mensaje>(request);
        }

        public async Task InsertarMensajeAsync(String mensaje, String usernameFrom, String userNameTo)
        {
            Mensaje msg = new Mensaje();
            msg.Message = mensaje;
            msg.UsernameFrom = usernameFrom;
            msg.UsernameTo = userNameTo;
            String json = JsonConvert.SerializeObject(msg);
            StringContent content =
            new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/Mensajes";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response =
                    await client.PostAsync(uri, content);
            }
        }

        public async Task DeleteMensajeAsync(int id)
        {
            String request = "api/Mensajes/" + id;
            Uri uri = new Uri(this.url + request);
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(uri);
            }
        }
        #endregion

        #region AMIGOS
        public async Task<List<Relacion>> MostrarAmigosAsync(string username)
        {
            String request = "api/GestionAmigos/MostrarAmigos/" + username;
            return await this.CallApiAsync<List<Relacion>>(request);
        }

        public async Task<Relacion> GetAmigoAsync(String username, String usernameAmigo)
        {
            String request = "api/GestionAmigos/BuscarAmigo/" + username + "/" + usernameAmigo;
            return await this.CallApiAsync<Relacion>(request);
        }

        public async Task InsertarRelacionAAsync(String username, String userfriend) 
        {
            Relacion relacion = new Relacion();
            relacion.Username = username;
            relacion.UsernameAmigo = userfriend;
            String json = JsonConvert.SerializeObject(relacion);
            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/GestionAmigos/InsertarRelacionA/" + username + "/"
                    + userfriend;
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response =
                    await client.PostAsync(uri, content);
            }
        }

        public async Task InsertarRelacionBAsync(String username, String userfriend)
        {
            Relacion relacion = new Relacion();
            relacion.Username = userfriend;
            relacion.UsernameAmigo = username;
            String json = JsonConvert.SerializeObject(relacion);
            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/GestionAmigos/InsertarRelacionB/" + username + "/"
                    + userfriend;
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response =
                    await client.PostAsync(uri, content);
            }
        }
        #endregion


    }
}
