using System.Collections.Generic;

namespace Dtos
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PointsOfInterest> PointsOfInterest { get; set; } = new List<PointsOfInterest>();
    }
}
