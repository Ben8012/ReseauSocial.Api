﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Api.Models
{
    public class UserWithToken
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public string Token { get; set; }
        public string Passwd { get; set; }
    }
}
