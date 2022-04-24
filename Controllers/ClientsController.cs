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
    public class ClientsController : ApiController
    {
        private services_clientsEntities db = new services_clientsEntities();

        // GET: api/Clients
        [ResponseType(typeof(ClientResponseModel))]
        public IHttpActionResult GetClient()
        {
            return Ok(db.Client.ToList().ConvertAll(p=>new ClientResponseModel(p)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.ID == id) > 0;
        }
    }
}