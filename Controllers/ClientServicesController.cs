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
    public class ClientServicesController : ApiController
    {
        private services_clientsEntities db = new services_clientsEntities();

        // GET: api/ClientServices
        [ResponseType(typeof(ClientService))]
        public IHttpActionResult GetClientService(bool Last=true)
        {
            if (!Last)
                return Ok(db.ClientService.ToList().ConvertAll(p => new ServiceClientResponseModel(p)));
            else
            {
                var list = db.ClientService.ToList().Where(p => (p.StartTime - DateTime.Now).Days >= 0 && (p.StartTime - DateTime.Now).Days < 2).ToList();
                return Ok(list.ConvertAll(p => new ServiceClientResponseModel(p)));
            }
        }


        // GET: api/ClientServices/5
        [ResponseType(typeof(ClientService))]
        public IHttpActionResult GetClientService(int id)
        {
            ClientService clientService = db.ClientService.Find(id);
            if (clientService == null)
            {
                return NotFound();
            }

            return Ok(clientService);
        }


        // POST: api/ClientServices
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostClientService(ServiceClientResponseModel clientService)
        {


            db.ClientService.Add(clientService.ClientServiceDB());
            db.SaveChanges();

            return Ok(new Message(true, "Клиент записан!"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientServiceExists(int id)
        {
            return db.ClientService.Count(e => e.ID == id) > 0;
        }
    }
}