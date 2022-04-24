using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using services_net_framework.Models;
using services_net_framework.ResponseModel;

namespace services_net_framework.Controllers
{
    public class EmployesController : ApiController
    {
        private services_clientsEntities db = new services_clientsEntities();

        [HttpGet]
        [Route("me")]        
        [Authorize]
        [ResponseType(typeof(EmployeeResponseModel))]
        public IHttpActionResult Me()
        {
            var employeDb = db.Employe.FirstOrDefault(p => p.AspNetUsers.FirstOrDefault().UserName == User.Identity.Name);
            return Ok(new EmployeeResponseModel(employeDb));
        }

        // GET: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult GetEmploye(int id)
        {
            Employe employe = db.Employe.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }

        // PUT: api/Employes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmploye(int id, Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employe.id)
            {
                return BadRequest();
            }

            db.Entry(employe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
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

        // POST: api/Employes
        [ResponseType(typeof(Employe))]
        public IHttpActionResult PostEmploye(Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employe.Add(employe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employe.id }, employe);
        }

        // DELETE: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult DeleteEmploye(int id)
        {
            Employe employe = db.Employe.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            db.Employe.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeExists(int id)
        {
            return db.Employe.Count(e => e.id == id) > 0;
        }
    }
}