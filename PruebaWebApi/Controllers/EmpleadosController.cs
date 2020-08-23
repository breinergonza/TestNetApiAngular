using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PruebaWebApi.Models;
using PruebaWebApi.Models.DTO;

namespace PruebaWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpleadosController : ApiController
    {
        private testPruebaEntities db = new testPruebaEntities();

        // GET: api/Empleados
        public IQueryable<EmpleadosDto> GetEmpleados()
        {
            return db.Empleados.Select(x => new EmpleadosDto 
            {
                id = x.id,
                nombre = x.nombre,
                tipoIdetificacionId = x.tipoIdetificacionId,
                numeroIdentificacion = x.numeroIdentificacion
            });
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public async Task<IHttpActionResult> GetEmpleados(int id)
        {
            Empleados empleados = await db.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpleados(int id, Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleados.id)
            {
                return BadRequest();
            }

            db.Entry(empleados).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleados))]
        public async Task<IHttpActionResult> PostEmpleados(Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleados.Add(empleados);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empleados.id }, empleados);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public async Task<IHttpActionResult> DeleteEmpleados(int id)
        {
            Empleados empleados = await db.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            db.Empleados.Remove(empleados);
            await db.SaveChangesAsync();

            return Ok(empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosExists(int id)
        {
            return db.Empleados.Count(e => e.id == id) > 0;
        }
    }
}