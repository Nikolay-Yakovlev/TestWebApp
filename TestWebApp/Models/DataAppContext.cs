using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Models
{
    public class DataAppContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Professions> Professions { get; set; }
        public DataAppContext(DbContextOptions<DataAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
