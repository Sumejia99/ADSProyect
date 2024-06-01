using ADSProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace ADSProyect.DB
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Grupos> Grupo { get; set; }
    }
}
