using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.DatasetParsing
{
    public class DatasetParser
    {
        private ConstructionSitesParser _constructionSitesParser;
        public DatasetParser()
        {
            _constructionSitesParser = new ConstructionSitesParser();
        }
        public void ParseDatasets()
        {
            _constructionSitesParser.ParseConstructionSites(@"http://www.quebec511.info/donneespubliques/entraves.ashx?format=csv");
        }

    }
}