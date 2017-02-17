using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gradien.Models
{
    public class GDbContext : DbContext
    {
        public DbSet<BookingModels> Booking { get; set; }
        public DbSet<LocationModels> Location { get; set; }
        public DbSet<UserModels> User { get; set; }
    }
}