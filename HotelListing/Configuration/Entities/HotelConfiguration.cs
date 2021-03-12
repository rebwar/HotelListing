using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configuration.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
    }
}
