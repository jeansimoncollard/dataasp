using Dataasp.Backend.Entities;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using Dataasp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.MarkerGeneration
{
    public class ConstructionMarkerGenerater
    {
        private AddressLatLongConverter _addressLatLongConverter;


        public ConstructionMarkerGenerater()
        {
            _addressLatLongConverter = new AddressLatLongConverter();
        }

        public List<MarkerEntity> Generate(string startAddress, string endAddress, string tableName, string markerTitle, string imageUrl)
        {
            var markerList = new List<MarkerEntity>();

            var start = _addressLatLongConverter.GetLatLong(startAddress);
            var end = _addressLatLongConverter.GetLatLong(endAddress);


            var minlat = Math.Min(Math.Abs(start.Latitude), Math.Abs(end.Latitude));
            var maxlat = Math.Max(Math.Abs(start.Latitude), Math.Abs(end.Latitude));
            var minlong = Math.Min(Math.Abs(start.Longitude), Math.Abs(end.Longitude));
            var maxlong = Math.Max(Math.Abs(start.Longitude), Math.Abs(end.Longitude));

            //en-us to have decimal dot insead of comma
            var minlatstring = minlat.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            var maxlatstring = maxlat.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            var minlongstring = minlong.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            var maxlongstring = maxlong.ToString(CultureInfo.CreateSpecificCulture("en-US"));

            //Count construction sites that are near that waypoint and use that count as a score
            using (var conn = new SqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand($"Select * from {tableName} where latitude < {maxlatstring} and latitude > {minlatstring} and longitude < {maxlongstring} and longitude > {minlongstring}", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var marker = new MarkerEntity();
                            if (!reader.IsDBNull(0))
                            {
                                marker.Latitude = (double)reader.GetDecimal(0);
                            }
                            if (!reader.IsDBNull(1))
                            {
                                marker.Longitude = -(double)reader.GetDecimal(1);
                            }

                            marker.Image = imageUrl;
                            marker.MarkerTitle = markerTitle;

                            markerList.Add(marker);
                        }
                    }
                }

                conn.Close();
            }

            return markerList;
        }

    }
}