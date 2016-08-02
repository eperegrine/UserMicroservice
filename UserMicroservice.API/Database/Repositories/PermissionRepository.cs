using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UserMicroservice.Data.Models;
using UserMicroservice.Data.Transfer;

namespace UserMicroservice.API.Database.Repositories
{
    public class PermissionRepository : IRepository<Permission, int>
    {
        AppDbContextFactory _factory;

        public PermissionRepository(AppDbContextFactory factory)
        {
            _factory = factory;
        }

        public Permission GetInititialPermission()
        {
            return AsQuerable().First();
        }

        public IQueryable<Permission> AsQuerable()
        {
            return _factory.Create().Permissions.AsQueryable();
        }

        public AddDTO Create(Permission newItem)
        {
            throw new NotImplementedException();
        }

        public SuccessDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Permission RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public SuccessDTO Update(int id, Func<Permission, Permission> getNew)
        {
            throw new NotImplementedException();
        }
    }
}
