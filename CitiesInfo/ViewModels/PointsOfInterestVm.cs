using System.ComponentModel.DataAnnotations;
using Dtos;

namespace CitiesInfo.ViewModels
{
    //Used to interact with UI
    public class PointsOfInterestVm
    {
        public int PointOfInterestId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
