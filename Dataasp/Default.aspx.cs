
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
using Dataasp.Backend.jstemporaryclickbutton;

namespace Dataasp
{
    public partial class _Default : Page
    {
        Quickstats _quickstats = new Quickstats();

        private AddressLatLongConverter _addressLatLongConverter;
        private DistanceCalculater _distanceCalculater;
        private MapGeneraterAdapter _mapGeneraterAdapter;
        private StringToTravelEnumConverter _stringToTravelEnumConvert;
        private jstemporarybuttonclicker _jstemporarybuttonclicker;

        protected void Page_Load(object sender, EventArgs e)
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _distanceCalculater = new DistanceCalculater();
            _mapGeneraterAdapter = new MapGeneraterAdapter();
            _stringToTravelEnumConvert = new StringToTravelEnumConverter();
            _jstemporarybuttonclicker = new jstemporarybuttonclicker();
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
            _jstemporarybuttonclicker.clicked();
            mapResults.InnerHtml = _mapGeneraterAdapter.GenerateMap(startAddress, endAddress, _stringToTravelEnumConvert.Convert(travelModeComboBox.SelectedValue));

            var distance = _distanceCalculater.GetDistance(startAddress, endAddress, travelModeComboBox.SelectedValue);

            div.Attributes.Remove("class"); //removes the danger class highlight

            _quickstats.SetDistance(distance);
            _quickstats.SetName("Alex");
            _quickstats.SetMeansOfTransportation(travelModeComboBox.SelectedValue);
            _quickstats.SetFootPrint();


            _quickstats.ShowStats(div);
        }
    }
}