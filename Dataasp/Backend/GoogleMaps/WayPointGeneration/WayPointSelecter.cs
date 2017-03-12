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
using System.Web.UI.HtmlControls;

namespace Dataasp.Backend.GoogleMaps.WayPointGeneration
{
    public class WayPointSelecter
    {
        private WaypointGenerater _constructionSiteWaypointGenerater;

        public WayPointSelecter()
        {
            _constructionSiteWaypointGenerater = new WayPointGeneration.WaypointGenerater();
        }

        public MapPoint GenerateWayPoint(string startAddress, string endAddress, List<SliderValues> sliderValues, HtmlInputGenericControl distanceSlider, HtmlInputGenericControl constructionSlider, HtmlInputGenericControl photoRadarSlider, HtmlInputGenericControl savingFuelSlider)
        {
            sliderValues = sliderValues.OrderBy(x => x.SliderValue).Reverse().ToList();

            if (sliderValues.First().SliderId == distanceSlider.ID || sliderValues.First().SliderId == savingFuelSlider.ID) //If the slider with most importance given is distance, return no waypoint to have shortest path.
            {
                return null;
            }

            if (sliderValues.First().SliderId == constructionSlider.ID)
            {
                return _constructionSiteWaypointGenerater.Generate(startAddress, endAddress,"construction_sites");

            }

            if (sliderValues.First().SliderId == photoRadarSlider.ID)
            {
                return _constructionSiteWaypointGenerater.Generate(startAddress, endAddress, "speedtraps");

            }

            return null; //Could should never reach here anyway
        }
    }
}