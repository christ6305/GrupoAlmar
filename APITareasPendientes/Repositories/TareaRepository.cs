using APITareasPendientes.Data;
using APITareasPendientes.Models;
using Microsoft.EntityFrameworkCore;

namespace APITareasPendientes.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly ApplicationDbContext _context;

        public TareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TareaModel>> GetAllAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<TareaModel?> GetByIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task AddAsync(TareaModel tarea)
        {
            await _context.Tareas.AddAsync(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TareaModel tarea)
        {
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Tareas.AnyAsync(e => e.Id == id);
        }
    }
}
