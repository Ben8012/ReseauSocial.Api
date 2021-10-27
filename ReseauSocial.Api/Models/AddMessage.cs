using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Models
{
    public class AddMessage
    {
        public string Content { get; set; }
        public int UserSend { get; set; }
        public int UserGet { get; set; }
    }
}
