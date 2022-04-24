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
    public class ServicesController : ApiController
    {
        private services_clientsEntities db = new services_clientsEntities();

        // GET: api/Services
        [ResponseType(typeof(Service))]
        public IHttpActionResult GetService()
        {
            return Ok(db.Service.ToList().ConvertAll(p=>new ServiceResponseModel(p)));
            // return Ok(User.Identity.Name);
        }

        // GET: api/Services/5
        [ResponseType(typeof(Service))]
        public IHttpActionResult GetService(int id)
        {
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(new ServiceResponseModel(service));
        }

        // PUT: api/Services/
        [ResponseType(typeof(void))]
        public IHttpActionResult PutService(ServiceResponseModel service)
        {
            var serviceDB = service.GetServiceDB();

            db.Entry(serviceDB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(service.id))
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

        // POST: api/Services
        [ResponseType(typeof(Service))]
        public IHttpActionResult PostService(ServiceResponseModel service)
        {
            var serviceDB = service.GetServiceDB();
            db.Service.Add(serviceDB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceDB.ID}, serviceDB);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Service))]
        public IHttpActionResult DeleteService(int id)
        {
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            if (service.ClientService.Count != 0)
            {
                return Ok(new Message(false, "Нельзя удалить сервис на которые записаны клиенты!"));
            }

            db.Service.Remove(service);
            db.SaveChanges();

            return Ok(new Message(true, $"Услуга {service.Title} успешно удалена!"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceExists(int id)
        {
            return db.Service.Count(e => e.ID == id) > 0;
        }
    }
}