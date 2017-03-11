using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.WayPointGeneration
{
    public class WayPointGenerator
    {
        public MapPoint GenerateWayPoint(MapPoint begin, MapPoint end, int distance, int sliderValue)
        {
            double offsetDistance = (distance * sliderValue) / 100;

            double newlat = (begin.Latitude - end.Latitude) / 2;      //find out the height of the triangle created with the begin and end
            double newlong = (begin.Longitude - end.Longitude) / 2;    //find out the length of the triangle created with the begin and end

            MapPoint _middleWayPoint = new MapPoint();
            _middleWayPoint.Latitude = newlat;
            _middleWayPoint.Longitude = newlong;

            MapPoint _waypoint = new MapPoint();
            
            return _middleWayPoint;
        }
    }
}