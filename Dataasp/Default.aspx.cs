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
        Quickstats _quickstats = new Quickstats();

        protected void Page_Load(object sender, EventArgs e)
        {
            _quickstats.SetName("Yo dude");
            _quickstats.SetMeansOfTransportation("bus");
        }

        protected void addTripButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}