using Dataasp.Backend.Quickstats;
using Dataasp.Backend.DistanceCalculter;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
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

            //var distance = DistanceCalculater.
            double offsetDistance = (distance / 2);

            double newlat = (begin.Latitude + end.Latitude) / 2;      //find out the height of the triangle created with the begin and end
            double newlong = (begin.Longitude + end.Longitude) / 2;    //find out the length of the triangle created with the begin and end

            double latTravelled = Math.Abs(Math.Abs(begin.Latitude) - Math.Abs(end.Latitude));
            double longTravelled = Math.Abs(Math.Abs(begin.Longitude) - Math.Abs(end.Longitude));

            MapPoint _middleWayPoint = new MapPoint();
            _middleWayPoint.Latitude = newlat - (latTravelled * (sliderValue / 100.0));
            _middleWayPoint.Longitude = newlong - (longTravelled * (sliderValue / 100.0));

            return _middleWayPoint;
        }
    }
}