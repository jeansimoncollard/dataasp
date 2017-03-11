using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dataasp.Backend.Enums;

namespace Dataasp.Backend.Entities
{
    public class UserTravelRecord
    {
        public DateTime DateOfTrip { get; set; }
        public int MetersTravelled { get; set; }
        public TravelModeEnum TravelMode { get; set; }
    }


}