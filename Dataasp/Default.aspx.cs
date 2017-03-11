
using Dataasp.Backend.Quickstats;
using Dataasp.Backend.DistanceCalculter;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dataasp.Backend.GoogleMaps.MapGeneration;
using Dataasp.Backend.Enums;
using Dataasp.Backend.DataAccess;
using Dataasp.Backend.Entities;
using GoogleMaps.LocationServices;
using Dataasp.Backend.GoogleMaps.WayPointGeneration;

namespace Dataasp
{
    public partial class _Default : Page
    {
        Quickstats _quickstats = new Quickstats();

        private AddressLatLongConverter _addressLatLongConverter;
        private DistanceCalculater _distanceCalculater;
        private MapGeneraterAdapter _mapGeneraterAdapter;
        private StringToTravelEnumConverter _stringToTravelEnumConvert;
        private UserTravelStorer _userTravelStorer;
        private WayPointGenerator _wayPointGenerator;

        public double VolumeOfCO2;
        protected void Page_Load(object sender, EventArgs e)
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _distanceCalculater = new DistanceCalculater();
            _mapGeneraterAdapter = new MapGeneraterAdapter();
            _stringToTravelEnumConvert = new StringToTravelEnumConverter();
            _userTravelStorer = new UserTravelStorer();
            _wayPointGenerator = new WayPointGenerator();

        }

        protected void addTripButton_Click(object sender, EventArgs e)
        {
            var div = quickStatsDiv;
            var startAddress = fromTextBox.Text;
            var endAddress = toTextBox.Text;
            if (toTextBox.Text.Length == 0 || fromTextBox.Text.Length == 0)
            {
                div.Attributes.Add("class", "btn-danger");
                div.InnerHtml = "<h1 class='danger'>Please fill out the form properly</h1>";
                return;
            }
            var startCoordinates = _addressLatLongConverter.GetLatLong(startAddress);
            var endCoordinates = _addressLatLongConverter.GetLatLong(endAddress);

            var waypoint = generateWayPoint(startAddress, endAddress);
            var useWayPoint = !(waypoint == null); //Don't use waypoint if it's equal to null
            mapResults.InnerHtml = _mapGeneraterAdapter.GenerateMap(startAddress, endAddress, _stringToTravelEnumConvert.Convert(travelModeComboBox.SelectedValue), waypoint, useWayPoint);


            var distance = _distanceCalculater.GetDistance(startAddress, endAddress, travelModeComboBox.SelectedValue);

            //Save travel in database

            div.Attributes.Remove("class"); //removes the danger class highlight

            _quickstats.SetDistance(distance);
            _quickstats.SetName(HttpContext.Current.User.Identity.Name);
            _quickstats.SetMeansOfTransportation(travelModeComboBox.SelectedValue);
            _quickstats.SetFootPrint();
            VolumeOfCO2 = _quickstats.GetFootprint();
            _quickstats.ShowStats(div);

            var sliderDistanceValue = distanceSlider.Text;
            int _intSliderValue = Int32.Parse(distanceSlider.Text);

        }

        private void saveTravel(int distance, string travelModeValue)
        {
            var travelRecord = new UserTravelRecord()
            {
                Username = HttpContext.Current.User.Identity.Name,
                DateOfTrip = DateTime.Now,
                MetersTravelled = distance,
                VolumeCO2 = VolumeOfCO2,
                TravelMode = _stringToTravelEnumConvert.Convert(travelModeComboBox.SelectedValue),
                Cost = _quickstats.getCost()
            };
            _userTravelStorer.StoreTravel(travelRecord);

            var historyLoader = new UserHistoryLoader();
            if (HttpContext.Current.User.Identity.Name != "")               //prevent crash if not logged in
                historyLoader.LoadHistory(HttpContext.Current.User.Identity.Name);
        }

        private MapPoint generateWayPoint(string startAddress, string endAddress)
        {
            var sliderValues = new List<SliderValues>();

            sliderValues.Add(new SliderValues() { SliderId = distanceSlider.ID, SliderValue = Convert.ToInt32(distanceSlider.Text) });
            sliderValues.Add(new SliderValues() { SliderId = constructionSlider.ID, SliderValue = Convert.ToInt32(constructionSlider.Text) });
            sliderValues.Add(new SliderValues() { SliderId = photoRadarSlider.ID, SliderValue = Convert.ToInt32(photoRadarSlider.Text) });

            return _wayPointGenerator.GenerateWayPoint(startAddress, endAddress, sliderValues, distanceSlider, constructionSlider, photoRadarSlider);
        }
    }
}