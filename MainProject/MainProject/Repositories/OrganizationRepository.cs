using MainProject.Entities;
using MainProject.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainProject.Repositories
{
    public interface IOrganizationRepository
    {
        int Count(OrganizationFilter filter);
        List<Organization> List(OrganizationFilter filter);
    }
    public class OrganizationRepository : IOrganizationRepository
    {
        private LearningContext context;
        public OrganizationRepository(LearningContext context)
        {
            this.context = context;
        }

        public int Count(OrganizationFilter filter)
        {
            IQueryable<OrganizationDAO> organizations = context.Organization;
            organizations = DynamicFilter(organizations, filter);
            return organizations.Count();
        }

        public List<Organization> List(OrganizationFilter filter)
        {
            IQueryable<OrganizationDAO> organizations = context.Organization;
            organizations = DynamicFilter(organizations, filter);
            return organizations
                .Select(o => new Organization
                {
                    Id = o.Id,
                    Code = o.Code,
                    Name = o.Name
                }).ToList();
        }

        public IQueryable<OrganizationDAO> DynamicFilter(IQueryable<OrganizationDAO> query, OrganizationFilter filter)
        {
            if (filter.Id.HasValue)
                query = query.Where(q => q.Id == filter.Id.Value);
            if (!string.IsNullOrEmpty(filter.Code))
                query = query.Where(q => q.Code.StartsWith(filter.Code));
            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(q => q.Name.StartsWith(filter.Name));
            return query;
        }
    }
}
