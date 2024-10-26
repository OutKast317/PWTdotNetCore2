using Microsoft.EntityFrameworkCore;
using PWTdotNetCore2.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTdotNetCore2.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=.;Initial Catalog=PWTDB;User ID = sa;Password=georgeedwards1735;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<BlogDataModel> Blogs { get; set; }

    }
}
