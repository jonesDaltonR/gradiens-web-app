using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gradien.Models
{
    // Inherit from Microsoft's DbContext class
    // The inherited methods allow this class to access and modify the database
    // via Entity Framework
    public class GDbContext : DbContext
    {
        // Establish connection between the UserModels class and table in the database
        public DbSet<UserModels> User { get; set; }

        // Establish connection between the Hotels class and table in the database
        public DbSet<Hotels> Hotel { get; set; }
    }
}