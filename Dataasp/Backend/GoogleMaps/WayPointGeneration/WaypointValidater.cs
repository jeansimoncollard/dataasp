using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.WayPointGeneration
{
    public class WaypointValidater
    {
        public bool IsWaypointViable(string startAddress, string endAddress, MapPoint wayPoint)
        {
            var startCoordinates = _addressLatLongConverter.GetLatLong(startAddress);
            var endCoordinates = _addressLatLongConverter.GetLatLong(endAddress);

            return false;
        }
    }
}