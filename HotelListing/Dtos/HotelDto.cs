﻿namespace HotelListing.Dtos
{
    public class HotelDto:CreateHotelDto
    {
        public int Id { get; set; }
        public CountryDto Country { get; set; }
    }
}
