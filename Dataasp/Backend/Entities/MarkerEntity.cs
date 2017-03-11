using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.Entities
{
    public class MarkerEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string MarkerTitle { get; set; }
        public string Image { get; set; } //path to image
    }
}