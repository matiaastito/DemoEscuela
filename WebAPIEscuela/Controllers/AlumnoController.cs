using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPIEscuela.Data;
using WebAPIEscuela.Models;

namespace WebAPIEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }

        public AlumnoController(DBEscuelaAPIContext context)
        {
            Context = context;
        }

        [HttpGet]
        public List <Alumno> Get()
        {
            return Context.Alumnos.ToList();
        }

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            return Context.Alumnos.Find(id);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }
            //EF
            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            //EF -- memoria
            Context.Alumnos.Add(alumno);
            //EF -- Guardamos en la DB
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            //EF
            var alumno = Context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();
            return alumno;
        }

    }
}
