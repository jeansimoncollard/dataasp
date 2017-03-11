using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dataasp.Backend.Enums;

namespace Dataasp.Backend.Entities
{
    public class UserTravelRecord
    {
        public string Username { get; set; }
        public DateTime DateOfTrip { get; set; }
        public int MetersTravelled { get; set; }
        public double VolumeCO2 { get; set; }
        public TravelModeEnum TravelMode { get; set; }
        public double cost { get; set; }

        public UserTravelRecord()
        {

        }

        public UserTravelRecord(DateTime x, int y, int z)
        {
            DateOfTrip = x;
            MetersTravelled = y;
            switch (z)
            {
                case 0:
                    TravelMode = TravelModeEnum.WALKING;
                    break;
                case 1:
                    TravelMode = TravelModeEnum.BICYCLING;
                    break;
                case 2:
                    TravelMode = TravelModeEnum.TRANSIT;
                    break;
                case 3:
                    TravelMode = TravelModeEnum.DRIVING;
                    break;
                default:
                    TravelMode = TravelModeEnum.DRIVING;
                    break;
            }
               
        }

        public UserTravelRecord(UserTravelRecord v)
        {
            this.TravelMode = v.TravelMode;
            this.DateOfTrip = v.DateOfTrip;
            this.MetersTravelled = v.MetersTravelled;
            this.Username = v.Username;
            this.VolumeCO2 = v.VolumeCO2;

        }
    }
}