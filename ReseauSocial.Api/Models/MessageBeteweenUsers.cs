using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Models
{
    public class MessageBeteweenUsers
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
    }
}