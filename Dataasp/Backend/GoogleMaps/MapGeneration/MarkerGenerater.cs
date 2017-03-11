using Dataasp.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.GoogleMaps.MapGeneration
{
    public class MarkerGenerater
    {
        public string GenerateMarkers(List<MarkerEntity> markers)
        {
            //have to use list<char> for efficiency purposes
            var futureString = new List<char>();
            foreach (var marker in markers)
            {
                futureString.AddRange(generateMaker(marker.Latitude, marker.Longitude, marker.MarkerTitle, marker.Image));
            }
            return new string(futureString.ToArray());
        }
        private string generateMaker(double latitude, double longitude, string markerTitle, string image)
        {
            return $@"

                var marker = new google.maps.Marker({{
                position: {{lat: {latitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, lng: {longitude.ToString(CultureInfo.CreateSpecificCulture("en-US"))}}},
                map: map,
                title: '{markerTitle}',
                icon: '{image}',
                label: '{markerTitle}'
              }});

        ";
        }
    }
}