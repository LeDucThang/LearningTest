using System;
using System.Collections.Generic;

namespace MainProject.Repositories.Models
{
    public partial class UserDAO
    {
        public UserDAO()
        {
            Position_Users = new HashSet<Position_UserDAO>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Position_UserDAO> Position_Users { get; set; }
    }
}
