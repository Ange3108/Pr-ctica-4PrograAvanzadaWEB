using Practica4.MVC.Models;
using System.Net.Http.Json;

namespace Practica4.MVC.Services.Estudiantes
{
    public class EstudianteService : IEstudianteService
    {
        private readonly HttpClient _httpClient;

        public EstudianteService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("PracticaAPI");
        }

        public async Task<List<EstudianteViewModel>> ObtenerTodosAsync()
        {
            try
            {
                var estudiantes =
                    await _httpClient.GetFromJsonAsync<List<EstudianteViewModel>>(
                        "api/Estudiante");

                return estudiantes ?? new List<EstudianteViewModel>();
            }
            catch
            {
                return new List<EstudianteViewModel>();
            }
        }

        public async Task<EstudianteViewModel?> ObtenerPorIdAsync(int id)
        {
            try
            {
                var respuesta =
                    await _httpClient.GetAsync($"api/Estudiante/{id}");

                if (!respuesta.IsSuccessStatusCode)
                {
                    return null;
                }

                return await respuesta.Content
                    .ReadFromJsonAsync<EstudianteViewModel>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CrearAsync(
            EstudianteViewModel estudiante)
        {
            try
            {
                var respuesta =
                    await _httpClient.PostAsJsonAsync(
                        "api/Estudiante",
                        estudiante);

                return respuesta.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditarAsync(
            int id,
            EstudianteViewModel estudiante)
        {
            try
            {
                estudiante.Id = id;

                var respuesta =
                    await _httpClient.PutAsJsonAsync(
                        $"api/Estudiante/{id}",
                        estudiante);

                return respuesta.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var respuesta =
                    await _httpClient.DeleteAsync(
                        $"api/Estudiante/{id}");

                return respuesta.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}