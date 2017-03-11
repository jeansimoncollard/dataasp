using Dataasp.Backend.DatasetParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dataasp
{
    public partial class UpdateDatabase : System.Web.UI.Page
    {
        private DatasetParser _datasetParser;
        protected void Page_Load(object sender, EventArgs e)
        {
            _datasetParser = new DatasetParser();
            _datasetParser.ParseDatasets();
        }
    }
}