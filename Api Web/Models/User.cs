using Entidades.DataContracts;
using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
