using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dtos
{
    public class CreateCoutryDto
    {
        [Required]
        [MaxLength(50,ErrorMessage ="Country Name is to long")]
        public string Name { get; set; }
        [Required]
        [MaxLength(2, ErrorMessage = "Short Country Name is to long")]
        public string ShortName { get; set; }
    }
}
