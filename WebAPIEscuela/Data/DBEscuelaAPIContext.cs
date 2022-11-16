using Microsoft.EntityFrameworkCore;
using WebAPIEscuela.Models;

namespace WebAPIEscuela.Data
{
    public class DBEscuelaAPIContext  : DbContext
    {
        //CORE siempre vamos a declarar el constructor de esta forma
        public DBEscuelaAPIContext(DbContextOptions<DBEscuelaAPIContext> options) :base (options){ }

        //DBSET
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }

   
}
