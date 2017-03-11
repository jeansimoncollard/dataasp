using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.Enums
{
    public class StringToTravelEnumConverter
    {
        public TravelModeEnum Convert(string travelMode)
        {
            switch (travelMode.ToUpper())
            {
                case "DRIVING":
                    return TravelModeEnum.DRIVING;
                case "TRANSIT":
                    return TravelModeEnum.TRANSIT;
                case "BICYCLING":
                    return TravelModeEnum.BICYCLING;
                case "WALKING":
                    return TravelModeEnum.WALKING;
                default:
                    return TravelModeEnum.DRIVING;

            }
        }
    }
}