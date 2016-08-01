using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UserMicroservice.Data.Models;
using UserMicroservice.Data.Transfer;

namespace UserMicroservice.API.Database.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        AppDbContextFactory _fact;

        public UserRepository(AppDbContextFactory fact)
        {
            _fact = fact;
        }

        public IQueryable<User> AsQuerable()
        {
            return _fact.Create().Users.AsQueryable();
        }

        public AddDTO Create(User newItem)
        {
            throw new NotImplementedException();
        }

        public SuccessDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public SuccessDTO Update(int id, Func<User, User> getNew)
        {
            throw new NotImplementedException();
        }
    }
}
