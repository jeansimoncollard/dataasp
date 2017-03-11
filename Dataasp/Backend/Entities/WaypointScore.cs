using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.Entities
{
    public class WaypointScore
    {
        public MapPoint WayPoint { get; set; }
        public int Score { get; set; }

    }
}