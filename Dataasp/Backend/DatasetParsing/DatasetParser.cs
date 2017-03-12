using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.DatasetParsing
{
    public class DatasetParser
    {
        private ConstructionSitesParser _constructionSitesParser;
        private SpeedTrapParser _speedTrapParser;
        public DatasetParser()
        {
            _constructionSitesParser = new ConstructionSitesParser();
            _speedTrapParser = new SpeedTrapParser();
        }
        public void ParseDatasets()
        {
            _constructionSitesParser.ParseConstructionSites(@"http://www.quebec511.info/donneespubliques/entraves.ashx?format=csv");
            _speedTrapParser.Parse(@"https://www.donneesquebec.ca/recherche/dataset/8f8766ba-47da-4043-804d-629c445da97d/resource/63b7150e-062c-48ed-a77b-35fe552a11a4/download/radarsphoto.csv");
        }

    }
}