using System;
using System.Collections.Generic;

namespace MainProject.Repositories.Models
{
    public partial class Position_UserDAO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PositionId { get; set; }

        public virtual PositionDAO Position { get; set; }
        public virtual UserDAO User { get; set; }
    }
}
