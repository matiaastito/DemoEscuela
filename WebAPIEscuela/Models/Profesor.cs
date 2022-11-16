using System.Collections.Generic;

namespace WebAPIEscuela.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }   
        public string Email { get; set; }

        #region prop nav
        public Especialidad Especialidad { get; set; }
        public List <Alumno> AlumnoList { get; set;}
        #endregion
    }
}
