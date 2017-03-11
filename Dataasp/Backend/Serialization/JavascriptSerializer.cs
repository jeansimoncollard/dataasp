using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.Serialization
{
    public class JavascriptSerializer
    {
        public string Serialize(ArrayList arrayToSerialize)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(arrayToSerialize);
        }
    }
}