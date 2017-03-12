using Dataasp.Backend.Entities;
using Dataasp.Backend.Enums;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using Dataasp.Backend.MarkerGeneration;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.MapGeneration
{
    public class MapGeneraterAdapter
    {
        public AddressLatLongConverter _addressLatLongConverter;
        public MapGenerater _mapGenerater;
        public ConstructionMarkerGenerater _markerGenerater;

        public MapGeneraterAdapter()
        {
            _mapGenerater = new MapGenerater();
            _addressLatLongConverter = new AddressLatLongConverter();
            _markerGenerater = new ConstructionMarkerGenerater();
        }

        public string GenerateMap(string startAddress, string endAddress, TravelModeEnum travelMode, MapPoint wayPoint, bool isWaypoint)
        {
            var startCoordinates = _addressLatLongConverter.GetLatLong(startAddress);
            var endCoordinates = _addressLatLongConverter.GetLatLong(endAddress);

            //avoid null reference error
            if (wayPoint == null)
            {
                wayPoint = new MapPoint();
            }

            //.ToString("en-US") to have decimal point instead of comma as separator

            var markers = GetMarkers(startAddress, endAddress);

            return _mapGenerater.GenerateMap($"{{ lat: {startCoordinates.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {startCoordinates.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}}}", $"{{ lat: {endCoordinates.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {endCoordinates.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))} }}", $"{{ lat: {wayPoint.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {wayPoint.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))} }}", travelMode.ToString(), isWaypoint, markers); ;
        }

        private List<MarkerEntity> GetMarkers(string startAddress, string endAddress)
        {
            var markersList = new List<MarkerEntity>();
            markersList.AddRange(_markerGenerater.Generate(startAddress, endAddress, "construction_sites", "Construction", "http://img4.hostingpics.net/pics/990085construction.png"));
            markersList.AddRange(_markerGenerater.Generate(startAddress, endAddress, "speedtraps", "Speed Trap", "http://img4.hostingpics.net/pics/146471police.png"));
            return markersList;
        }
    }
}