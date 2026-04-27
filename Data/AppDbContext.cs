using Microsoft.EntityFrameworkCore;
using WebAPI8_Video.Models;

namespace WebAPI8_Video.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<autorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }


    }
}

       
