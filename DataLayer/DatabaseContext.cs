using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Person> Person{ get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Car> Car{ get; set; }
    }
}
