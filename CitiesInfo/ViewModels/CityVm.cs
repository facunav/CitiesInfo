using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dtos;

namespace CitiesInfo.ViewModels
{
    //Used to interact with UI
    public class CityVm
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<PointsOfInterest> PointsOfInterest { get; set; } = new List<PointsOfInterest>();
    }
}
