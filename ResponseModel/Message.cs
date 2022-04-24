using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace services_net_framework.ResponseModel
{
    public class Message
    {
        public Message(bool succses, string message)
        {
            this.succses = succses;
            this.message = message;
        }

        public bool succses { get; set; }
        public string message { get; set; }
    }
}