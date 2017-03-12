using Dataasp.Backend.Entities;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using Dataasp.Properties;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.WayPointGeneration
{
    public class ConstructionSiteWaypointGenerater
    {
        private AddressLatLongConverter _addressLatLongConverter;
        private WaypointValidater _waypointValidater;
        private Random _random;

        public ConstructionSiteWaypointGenerater()
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _waypointValidater = new WaypointValidater();
            _random = new Random(1321432);//random constant seed
        }

        public MapPoint Generate(string startAddress, string endAddress)
        {
            var start = _addressLatLongConverter.GetLatLong(startAddress);
            var end = _addressLatLongConverter.GetLatLong(endAddress);

            var wayPointList = new List<MapPoint>();

            var middlePoint = new MapPoint() { Latitude = (start.Latitude + end.Latitude) / 2, Longitude = (start.Longitude + end.Longitude) / 2 };

            //Maximum value you can add to the lat and long coordinates (so that we don't generate waypoints in china when we are in sherbrooke)
            var latMaxAddableValue = Math.Abs(start.Latitude - end.Latitude) / 2;
            var longMaxAddableValue = Math.Abs(start.Longitude - end.Longitude) / 2;

            for (var i = 0; i < 5 && wayPointList.Count < 3; i++) //very expensive operation to check viabilty of waypoints so I'm not generating much
            {
                var percentage = _random.NextDouble();
                var wayPoint = new MapPoint();
                wayPoint.Latitude = middlePoint.Latitude + latMaxAddableValue * percentage;
                wayPoint.Longitude = middlePoint.Longitude + longMaxAddableValue * percentage;

                if (_waypointValidater.IsWaypointViable(startAddress, endAddress, wayPoint))
                {
                    wayPointList.Add(wayPoint);
                }
            }
            var candidates = getScoredWayPointList(wayPointList, latMaxAddableValue, longMaxAddableValue).OrderBy(x => x.Score);

            return candidates.Last().WayPoint;//The one with least construciton points nearby
        }


        private List<WaypointScore> getScoredWayPointList(List<MapPoint> listWayPoints, double latMaxAddableValue, double longMaxAddableValue)
        {
            var listScoreWaypoints = new List<WaypointScore>();
            if (listWayPoints.Count != 0)
            {
                foreach (var waypoint in listWayPoints)
                {
                    var score = scoreWaypoint(waypoint, latMaxAddableValue, longMaxAddableValue);
                    listScoreWaypoints.Add(new WaypointScore() { WayPoint = waypoint, Score = score });
                }
            }
            return listScoreWaypoints;
        }

        private int scoreWaypoint(MapPoint waypoint, double latMaxAddableValue, double longMaxAddableValue)
        {
            var score = 0;

            var minlat = Math.Abs(waypoint.Latitude) - latMaxAddableValue / 3;
            var maxlat = Math.Abs(waypoint.Latitude) + latMaxAddableValue / 3;
            var minlong = Math.Abs(waypoint.Longitude) - longMaxAddableValue / 3;
            var maxlong = Math.Abs(waypoint.Longitude) + longMaxAddableValue / 3;

            //en-us to have decimal dot insead of comma
            var minlatstring = minlat.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            var maxlatstring = maxlat.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            var minlongstring = minlong.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            var maxlongstring = maxlong.ToString(CultureInfo.CreateSpecificCulture("en-US"));

            //Count construction sites that are near that waypoint and use that count as a score
            using (var conn = new SqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand($"Select * from construction_sites where latitude < {maxlatstring} and latitude > {minlatstring} and longitude < {maxlongstring} and longitude > {minlongstring}", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            score++;
                        }
                    }
                }

                conn.Close();
            }

            return score;
        }
    }
}