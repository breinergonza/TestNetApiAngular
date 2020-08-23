using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PruebaWebApi.Models;

namespace PruebaWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntidadesController : ApiController
    {
        private testPruebaEntities db = new testPruebaEntities();


        /// <summary>
        /// Esto trae el listado de Entidades de la base de datos "GET: api/Entidades"
        /// </summary>
        /// <returns></returns>
        public List<Entidades> GetEntidades()
        {
            return db.Entidades.ToList(); ;
        }

        /// <summary>
        /// Obtiene una entidad a partir de su ID "GET: api/Entidades/5"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Entidades))]
        public IHttpActionResult GetEntidades(int id)
        {
            Entidades entidades = db.Entidades.Find(id);
            if (entidades == null)
            {
                return NotFound();
            }

            return Ok(entidades);
        }

        /// <summary>
        /// Actualiza una entidad a partir de su ID y de los campos a modificar "PUT: api/Entidades/5"
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entidades"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntidades(int id, Entidades entidades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entidades.id)
            {
                return BadRequest();
            }

            db.Entry(entidades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return StatusCode(HttpStatusCode.NoContent);

            return Ok(new
            {
                estatus = true,
                mensaje = "Se modifico con exito"
            });

        }


        /// <summary>
        /// Esta funcion permite agregar una nueva entidad " POST: api/Entidades"
        /// </summary>
        /// <param name="entidades"></param>
        /// <returns></returns>
        [ResponseType(typeof(Entidades))]
        public IHttpActionResult PostEntidades(Entidades entidades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entidades.Add(entidades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entidades.id }, entidades);
        }

        /// <summary>
        /// Permite eliminar una entidad a partir de su ID "DELETE: api/Entidades/5"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Entidades))]
        public IHttpActionResult DeleteEntidades(int id)
        {
            Entidades entidades = db.Entidades.Find(id);
            if (entidades == null)
            {
                return NotFound();
            }

            db.Entidades.Remove(entidades);
            db.SaveChanges();

            return Ok(entidades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntidadesExists(int id)
        {
            return db.Entidades.Count(e => e.id == id) > 0;
        }
    }
}