using System;
using System.Collections.Generic;
using System.Text;

namespace MainProject.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserFilter
    {
        public Guid? Id { get; set; }
        public string Username { get; set; }
    }
}
