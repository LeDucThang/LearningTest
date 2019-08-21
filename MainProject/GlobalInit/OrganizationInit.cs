using MainProject.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalInit
{
    public class OrganizationInit
    {
        private LearningContext context;
        public OrganizationInit(LearningContext context)
        {
            this.context = context;
        }

        public void Init()
        {
            
        }
    }
}
