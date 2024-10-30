using Microsoft.EntityFrameworkCore;
using PWTdotNetCore2.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
/* 
serves as a bridge between your application and a database

Key Purposes of AppDbContext:

1.Entity Definition:
        Defines the entity classes (models) that represent your database tables.
        Specifies the relationships between these entities.

    Database Operations:
        Provides methods for performing CRUD (Create, Read, Update, Delete) operations on the database.   

2.Manages database connections and transactions.  

    Executes LINQ queries to retrieve and manipulate data.

3.Change Tracking:

    Tracks changes made to entities during a request.   

Automatically detects changes and updates the database accordingly.
*/
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
