using services_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace services_net_framework.ResponseModel
{
    public class ServiceResponseModel
    {
        public ServiceResponseModel(Service service)
        {
            if (service == null)
            {
                return;
            }
            id = service.ID;
            Description = service.Description;
            Cost = service.Cost;
            Image = service.MainImagePath;
            Title = service.Title;
            Discount = service.Discount;
            Duration = service.DurationInSeconds;
        }
        public ServiceResponseModel()
        {

        }

        public int id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public double? Discount { get; set; }

        public Service GetServiceDB()
        {
            return new Service() { ID = id, Description = Description, Cost = Cost, Discount = Discount, Title = Title, DurationInSeconds = (int)Duration, MainImagePath = Image };
        }



    }
}