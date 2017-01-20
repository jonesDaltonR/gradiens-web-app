using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gradien.Models
{
    public class GDbContext : DbContext
    {
        public DbSet<AdminModels> Admin { get; set; }
        public DbSet<AirplaneModels> Airplane { get; set; }
        public DbSet<AirportModels> Airport { get; set; }
        public DbSet<BusModels> Bus { get; set; }
        public DbSet<BusStopModels> BusStop { get; set; }
        public DbSet<CruiseModels> Cruise { get; set; }
        public DbSet<HarborModels> Harbor { get; set; }
        public DbSet<HotelModels> Hotel { get; set; }
        public DbSet<LocationModels> Location { get; set; }
        public DbSet<RegUserModels> RegUser { get; set; }
        public DbSet<ReservationModels> Reservation { get; set; }
        public DbSet<SeatingResModels> SeatingRes { get; set; }
        public DbSet<TrainModels> Train { get; set; }
        public DbSet<TrainStationModels> TrainStation { get; set; }
        public DbSet<UserModels> User { get; set; }
    }
}