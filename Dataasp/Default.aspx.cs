using Dataasp.Backend.Quickstats;
using Dataasp.Backend.DistanceCalculter;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dataasp
{
    public partial class _Default : Page
    {
        Quickstats _quickstats = new Quickstats();

        private AddressLatLongConverter _addressLatLongConverter;
        private DistanceCalculater _distanceCalculater;
        protected void Page_Load(object sender, EventArgs e)
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _distanceCalculater = new DistanceCalculater();
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

            var distance = _distanceCalculater.GetDistance(startAddress, endAddress, travelModeComboBox.SelectedValue);

            div.Attributes.Remove("class"); //removes the danger class highlight
            _quickstats.SetDistance(distance);
            _quickstats.SetName("Alex");
            _quickstats.SetMeansOfTransportation(travelModeComboBox.SelectedValue);

            

            _quickstats.ShowStats(div);
        }

    }
}