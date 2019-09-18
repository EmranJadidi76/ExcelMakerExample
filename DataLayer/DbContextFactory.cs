using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EmptyDadtabase;Data Source=.");


            return new DatabaseContext(optionBuilder.Options);
        }
    }
}
