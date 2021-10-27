using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Models
{
    public class RegisterUser
    {
        public string LastName { get; set; }
        
        public string FirstName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public string Passwd { get; set; }
    }
}
