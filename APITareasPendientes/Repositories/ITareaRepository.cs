using APITareasPendientes.Models;

namespace APITareasPendientes.Repositories
{
    public interface ITareaRepository
    {
        Task<IEnumerable<TareaModel>> GetAllAsync();
        Task<TareaModel?> GetByIdAsync(int id);
        Task AddAsync(TareaModel tarea);
        Task UpdateAsync(TareaModel tarea);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
