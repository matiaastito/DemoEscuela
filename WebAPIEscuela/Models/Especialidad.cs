using System.Collections.Generic;

namespace WebAPIEscuela.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region prop nav
        public List <Profesor> Profesores { get; set; }
        #endregion
    }
}
