using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Models
{
    public class DeleteMessage
    {
        public int Id { get; set; }

        public int UserSend { get; set; }
    }
}
