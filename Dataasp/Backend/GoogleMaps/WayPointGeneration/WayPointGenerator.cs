using Dataasp.Backend.Quickstats;
using Dataasp.Backend.DistanceCalculter;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dataasp.Backend.Entities;
using System.Web.UI.WebControls;

namespace Dataasp.Backend.GoogleMaps.WayPointGeneration
{
    public class WayPointGenerator
    {
        private ConstructionSiteWaypointGenerater _constructionSiteWaypointGenerater;

        public WayPointGenerator()
        {
            _constructionSiteWaypointGenerater = new WayPointGeneration.ConstructionSiteWaypointGenerater();
        }

        public MapPoint GenerateWayPoint(string startAddress, string endAddress, List<SliderValues> sliderValues, TextBox distanceSlider, TextBox constructionSlider, TextBox photoRadarSlider, TextBox savingFuelSlider)
        {
            sliderValues = sliderValues.OrderBy(x => x.SliderValue).Reverse().ToList();

            if (sliderValues.First().SliderId == distanceSlider.ID || sliderValues.First().SliderId == savingFuelSlider.ID) //If the slider with most importance given is distance, return no waypoint to have shortest path.
            {
                return null;
            }

            if (sliderValues.First().SliderId == constructionSlider.ID)
            {
                return _constructionSiteWaypointGenerater.Generate(startAddress, endAddress);

            }

            return null; //Could should never reach here anyway
        }
    }
}