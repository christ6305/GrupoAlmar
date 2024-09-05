using APPTareasPendientes.Models;

namespace APPTareasPendientes.Services
{
    public class TareaService
    {
        private readonly HttpClient _httpClient;

        public TareaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TareaModel>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TareaModel>>("tarea");
        }

        public async Task<TareaModel> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TareaModel>($"tarea/{id}");
        }

        public async Task CreateAsync(TareaModel tarea)
        {
            var response = await _httpClient.PostAsJsonAsync("tarea", tarea);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(TareaModel tarea)
        {
            var response = await _httpClient.PutAsJsonAsync($"tarea/{tarea.Id}", tarea);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"tarea/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
