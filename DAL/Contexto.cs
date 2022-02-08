using Microsoft.EntityFrameworkCore;
using Clase2.Entidades;

public class Contexto:DbContext
{
    
    //esto esta en el branch
        public DbSet<Libros> Libros { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data\Libros.db");
    }
}