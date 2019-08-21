using System;
using System.Collections.Generic;
using System.Text;

namespace MainProject.Entities
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class PositionFilter
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
