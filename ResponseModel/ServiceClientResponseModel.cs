using services_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace services_net_framework.ResponseModel
{
    public class ServiceClientResponseModel
    {
        public ServiceClientResponseModel(ClientService clientService)
        {
            if (clientService == null)
            {
                return;
            }
            ClientID = clientService.ClientID;
            ServiceID = clientService.ServiceID;
            ClientName = clientService.Client.FirstName;
            ServiceName = clientService.Service.Title;
            Comment = clientService.Comment;
            Date = clientService.StartTime;
            Phone = clientService.Client.Phone;
        }
        public ServiceClientResponseModel()
        { }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }

        public ClientService ClientServiceDB()
        {
            return new ClientService() { ClientID = ClientID, ServiceID=ServiceID, StartTime=Date};
        }
    }
}