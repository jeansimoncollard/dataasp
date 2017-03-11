using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dataasp.Backend.Enums;

namespace Dataasp.Backend.Entities
{
    public class UserTravelRecord
    {
        private DateTime now;
        private int v1;
        private int v2;

        public DateTime DateOfTrip { get; set; }
        public int MetersTravelled { get; set; }
        public TravelModeEnum TravelMode { get; set; }
    
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
        }
    }


}