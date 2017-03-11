using Dataasp.Backend.DistanceCalculter;
using Dataasp.Backend.Enums;
using Dataasp.Backend.GoogleMaps.DistanceCalculter;
using Dataasp.Backend.GoogleMaps.MapGeneration;
using Dataasp.Backend.Quickstats;
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
        private DistanceCalculater _distanceCalculater;
        private MapGeneraterAdapter _mapGeneraterAdapter;
        private StringToTravelEnumConverter _stringToTravelEnumConvert;
        private Quickstats _quickstats;

        protected void Page_Load(object sender, EventArgs e)
        {
            _distanceCalculater = new DistanceCalculater();
            _mapGeneraterAdapter = new MapGeneraterAdapter();
            _stringToTravelEnumConvert = new StringToTravelEnumConverter();
            _quickstats = new Quickstats();
        }

        protected void addTripButton_Click(object sender, EventArgs e)
        {
            var startAddress = fromTextBox.Text;
            var endAddress = toTextBox.Text;

            mapResults.InnerHtml = _mapGeneraterAdapter.GenerateMap(startAddress, endAddress, _stringToTravelEnumConvert.Convert(travelModeComboBox.SelectedValue));

            var distance = _distanceCalculater.GetDistance(startAddress, endAddress, travelModeComboBox.SelectedValue);

            _quickstats.SetDistance(distance);
            _quickstats.SetName("Alex");
            _quickstats.SetMeansOfTransportation(travelModeComboBox.SelectedValue);



            _quickstats.ShowStats(quickStatsDiv);
        }
    }
}