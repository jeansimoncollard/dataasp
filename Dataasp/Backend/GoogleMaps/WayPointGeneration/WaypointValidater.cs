using Dataasp.Backend.DistanceCalculter;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.WayPointGeneration
{
    public class WaypointValidater
    {
        private AddressLatLongConverter _addressLatLongConverter;
        private DistanceCalculater _distanceCalculter;

        public WaypointValidater()
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _distanceCalculter = new DistanceCalculater();
        }

        //Validate waypoint isn't in ocean or something
        public bool IsWaypointViable(string startAddress, string endAddress, MapPoint wayPoint)
        {
            var wayPointString = $"{wayPoint.Latitude},{wayPoint.Longitude}";

            var distance = _distanceCalculter.GetDistance(startAddress, endAddress, wayPointString);
            if (distance == 0)
            {
                return false;
            }
            return true;
        }
    }
}