using System;
using System.Collections.Generic;
using System.Text;

namespace MainProject.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class OrganizationFilter
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
