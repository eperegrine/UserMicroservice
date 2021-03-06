﻿using System;
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
            using (var db = _fact.Create())
            {
                db.Users.Add(newItem);
                db.SaveChanges();
                return new AddDTO()
                {
                    Id = newItem.Id,
                    Success = true
                };
            }
        }

        public SuccessDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User RetrieveById(int id)
        {
            using (var db = _fact.Create())
            {
                return db.Users.First(x => x.Id == id);
            }
        }

        public SuccessDTO Update(int id, Func<User, User> getNew)
        {
            using (var db = _fact.Create())
            {
                var u = db.Users.First(x => x.Id == id);
                u = getNew(u);
                db.SaveChanges();
                return SuccessDTO.Successful();
            }
            
        }
    }
}
