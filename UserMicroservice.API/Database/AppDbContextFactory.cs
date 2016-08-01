using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.API.Database
{
    public class AppDbContextFactory
    {
        public const string DEV_CONNECTION_STRING = @"Server=(localdb)\mssqllocaldb;Database=UserDb;Trusted_Connection=True;MultipleActiveResultSets=True;";
        public const string PROD_CONNECTION_STRING = @"Server=(localdb)\mssqllocaldb;Database=UserDb;Trusted_Connection=True;MultipleActiveResultSets=True;";
        public static bool InProduction = false;

        public static string GetConnectionString()
        {
            return InProduction ? PROD_CONNECTION_STRING : DEV_CONNECTION_STRING;
        }

        public AppDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(GetConnectionString());

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
