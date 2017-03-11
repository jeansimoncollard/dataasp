using Dataasp.Backend.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dataasp
{
    public partial class About : Page
    {
        public string Chart1Data { get; set; }
        private JavascriptSerializer _jsArraySerializer;
        protected void Page_Load(object sender, EventArgs e)
        {
            _jsArraySerializer = new JavascriptSerializer();
            Chart1Data = _jsArraySerializer.Serialize(new ArrayList() { 2, 4, 6, 7, 3, 2 });
        }


    }
}