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
        public ConstructionMarkerGenerater _constructionMarkerGenerater;

        public MapGeneraterAdapter()
        {
            _mapGenerater = new MapGenerater();
            _addressLatLongConverter = new AddressLatLongConverter();
            _constructionMarkerGenerater = new ConstructionMarkerGenerater();
        }

        public string GenerateMap(string startAddress, string endAddress, TravelModeEnum travelMode, MapPoint wayPoint, bool isWaypoint)
        {
            var startCoordinates = _addressLatLongConverter.GetLatLong(startAddress);
            var endCoordinates = _addressLatLongConverter.GetLatLong(endAddress);

            //.ToString("en-US") to have decimal point instead of comma as separator

            var markers = GetMarkers(startAddress, endAddress);

            return _mapGenerater.GenerateMap($"{{ lat: {startCoordinates.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {startCoordinates.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}}}", $"{{ lat: {endCoordinates.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {endCoordinates.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))} }}", $"{{ lat: {wayPoint.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {wayPoint.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))} }}", travelMode.ToString(), isWaypoint, markers); ;
        }

        private List<MarkerEntity> GetMarkers(string startAddress, string endAddress)
        {
            return _constructionMarkerGenerater.Generate(startAddress, endAddress);
        }
    }
}