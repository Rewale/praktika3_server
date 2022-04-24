using services_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace services_net_framework.ResponseModel
{
    public class ClientResponseModel
    {
        public ClientResponseModel(Client client)
        {
            FIO = $"{client.LastName} {client.FirstName} {client.Patronymic}";
            id = client.ID;
        }
        public string FIO { get; set; }
        public int id { get; set; }
    }
}