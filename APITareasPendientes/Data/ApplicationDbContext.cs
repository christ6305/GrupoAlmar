using APITareasPendientes.Models;
using Microsoft.EntityFrameworkCore;

namespace APITareasPendientes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }

        public DbSet<TareaModel> Tareas { get; set; }
    }
}
