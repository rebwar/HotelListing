using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 2,
                    Name = "Kurdistan",
                    ShortName = "KR"
                },
                new Country
                {
                    Id = 1,
                    Name = "Iran",
                    ShortName = "IR"
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Parsian",
                   
                    Address = "Tehran Jomhouri",
                    Rating = 4,
                    CountryId = 1

                },
                new Hotel
                {
                    Id = 2,
                    Name = "NewCity",
                    
                    Address = "Hewler, Azadi",
                    Rating = 5,
                    CountryId = 2

                }
                );
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
