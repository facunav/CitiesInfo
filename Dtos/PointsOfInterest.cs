using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class PointsOfInterest
    {
        public int PointOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
    }
}
