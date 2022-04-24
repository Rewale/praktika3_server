using services_net_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace services_net_framework.ResponseModel
{
    public class EmployeeResponseModel
    {
        public EmployeeResponseModel(Employe employe)
        {
            Name = employe.name;
            Role = employe.Role.name;
        }

        public string Name { get; set; }
        public string Role { get; set; }        
    }
}