using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.DistanceCalculter
{
    public class DistanceCalculater
    {

        //shortest distance in meters 
        public int GetDistance(string startAddress, string endAddress, string travelmode)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            //string from = origin.Text;
            //string to = destination.Text;
            string requesturl = $@"http://maps.googleapis.com/maps/api/directions/json?origin={startAddress}&destination={endAddress}&sensor=false&mode={travelmode.ToLower()}";
            string content = fileGetContents(requesturl);
            var o = JObject.Parse(content);
            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
                return distance;
            }
            catch
            {
                return distance;
            }
        }

        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("http:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);
                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }
    }
}