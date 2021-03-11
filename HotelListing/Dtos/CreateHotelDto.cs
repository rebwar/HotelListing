using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dtos
{
    public class CreateHotelDto
    {
        [Required]
        [MaxLength(150, ErrorMessage = "Hotel Name is to long")]
        public string Name { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Address  is to long")]
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public short Rating { get; set; }
       [Required]
        public int CountryId { get; set; }
       
    }
}
