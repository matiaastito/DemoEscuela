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
    public class ProfesorController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }
        public ProfesorController(DBEscuelaAPIContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public List<Profesor> Get()
        {
            //EF
            List<Profesor> listaProfesores = Context.Profesores.ToList();
            return listaProfesores;
        }

        [HttpGet("{id}")]
        public Profesor Get(int id)
        {
            //EF
            return Context.Profesores.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Profesor profesor)
        {
            //EF -- memoria
            Context.Profesores.Add(profesor);
            //EF -- Guardamos en la DB
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profesor profesor)
        {
            if(id != profesor.Id)
            {
                return BadRequest();
            }
            //EF
            Context.Entry(profesor).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult <Profesor> Delete (int id)
        {
            //EF
            var profesor = Context.Profesores.Find(id);
            if(profesor == null)         
            {
                return NotFound();
            }
            Context.Profesores.Remove(profesor);
            Context.SaveChanges();
            return profesor;
        }
    }
}
