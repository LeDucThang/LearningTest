using System;
using System.Collections.Generic;

namespace MainProject.Repositories.Models
{
    public partial class OrganizationDAO
    {
        public OrganizationDAO()
        {
            Positions = new HashSet<PositionDAO>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<PositionDAO> Positions { get; set; }
    }
}
