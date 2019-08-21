using System;
using System.Collections.Generic;

namespace MainProject.Repositories.Models
{
    public partial class PositionDAO
    {
        public PositionDAO()
        {
            Position_Users = new HashSet<Position_UserDAO>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }

        public virtual OrganizationDAO Organization { get; set; }
        public virtual ICollection<Position_UserDAO> Position_Users { get; set; }
    }
}
