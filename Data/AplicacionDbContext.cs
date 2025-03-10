using Microsoft.EntityFrameworkCore;
using Udemy.Models;

namespace Udemy.Data
{
    public class AplicacionDbContext:DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) :base(options)
        {

        }

        //Agregar los modelos osea cada tabla de BD

        public DbSet<Contacto> Contacto { get; set; }
    }
}
