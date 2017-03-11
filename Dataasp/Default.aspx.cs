
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
//using Dataasp.Backend.jstemporaryclickbutton;
using Dataasp.Backend.DataAccess;
using Dataasp.Backend.Entities;
using GoogleMaps.LocationServices;

namespace Dataasp
{
    public partial class _Default : Page
    {
        Quickstats _quickstats = new Quickstats();

        private AddressLatLongConverter _addressLatLongConverter;
        private DistanceCalculater _distanceCalculater;
        private MapGeneraterAdapter _mapGeneraterAdapter;
        private StringToTravelEnumConverter _stringToTravelEnumConvert;
       // private jstemporarybuttonclicker _jstemporarybuttonclicker;
        private UserTravelStorer _userTravelStorer;
        public double VolumeOfCO2;
        protected void Page_Load(object sender, EventArgs e)
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _distanceCalculater = new DistanceCalculater();
            _mapGeneraterAdapter = new MapGeneraterAdapter();
            _stringToTravelEnumConvert = new StringToTravelEnumConverter();
         //   _jstemporarybuttonclicker = new jstemporarybuttonclicker();
            _userTravelStorer = new UserTravelStorer();
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
            //_jstemporarybuttonclicker.clicked();
            MapPoint waypoint = new MapPoint();
            mapResults.InnerHtml = _mapGeneraterAdapter.GenerateMap(startAddress, endAddress, _stringToTravelEnumConvert.Convert(travelModeComboBox.SelectedValue), waypoint, false);


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

            //MapPoint testMap = _wayPointGenerator.GenerateWayPoint(startCoordinates, endCoordinates, distance, _intSliderValue);

           // if (_intSliderValue != 0)
            //    mapResults.InnerHtml = _mapGeneraterAdapter.GenerateMap(startAddress, endAddress, _stringToTravelEnumConvert.Convert(travelModeComboBox.SelectedValue), testMap, true);
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
    }
}