using Microsoft.EntityFrameworkCore;
using Rocky.Models;

namespace Rocky.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<AplicationType> AplicationType { get; set; }  //Agregando a la base de datos, posterior a esto hay que ejecutar add-migraton AddAplicationTypeToDatabase 
                                                                   //Posteriormente ejecutar un update-database
    }
}
