using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.DistanceCalculter
{
    public class AddressLatLongConverter
    {
        private GoogleLocationService _googleLocationService;
        public AddressLatLongConverter()
        {
            _googleLocationService = new GoogleLocationService();
        }
        public MapPoint GetLatLong(string address)
        {
            return _googleLocationService.GetLatLongFromAddress(address);
        }
    }
}