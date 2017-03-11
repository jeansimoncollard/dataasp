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
        private AddressLatLongConverter _addressLatLongConverter;
        private DistanceCalculater _distanceCalculater;
        protected void Page_Load(object sender, EventArgs e)
        {
            _addressLatLongConverter = new AddressLatLongConverter();
            _distanceCalculater = new DistanceCalculater();
        }

        protected void addTripButton_Click(object sender, EventArgs e)
        {
            var startAddress = fromTextBox.Text;
            var endAddress = toTextBox.Text;
            var startCoordinates = _addressLatLongConverter.GetLatLong(startAddress);
            var endCoordinates = _addressLatLongConverter.GetLatLong(endAddress);

            var distance = _distanceCalculater.GetDistance(startAddress, endAddress, travelModeComboBox.SelectedValue);


        }
    }
}