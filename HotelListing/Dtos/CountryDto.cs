using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Dtos
{
    public class CountryDto:CreateCoutryDto
    {
        public int Id { get; set; }
        public IList<HotelDto> Hotels { get; set; }
    }
}
