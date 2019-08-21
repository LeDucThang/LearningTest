using MainProject.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainProject.Repositories
{
    public interface IUOW
    {
        IOrganizationRepository OrganizationRepository { get; }
    }
    public class UOW : IUOW
    {
        private LearningContext context;
        public IOrganizationRepository OrganizationRepository { get; }
        public UOW(LearningContext context)
        {
            OrganizationRepository = new OrganizationRepository(context);
        }
    }
}
