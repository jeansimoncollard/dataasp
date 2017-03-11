using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.Quickstats
{
    public class Quickstats
    {
        private string _name;                   //user's name

        private string _meansOfTransportation;  //the type of vehicul/transportation method

        private double _distance;               //the user's intended travelled distance

        private double _footPrint;              //the user's ecological footprint

        private double _ETA;                    //estimated time before arrival for the user

        private void setFootPrint()             //sets the user's ecological footprint based on means of transportation and distance
        {
            switch (_meansOfTransportation)
            {
                case "car": _footPrint = _distance * 12345.0;
                    break;
                case "bus": _footPrint = _distance * 12345.0;
                    break;
                case "walk": _footPrint = _distance * 12345.0;
                    break;
                case "metro": _footPrint = _distance * 12345.0;
                    break;
            }
        }


        public double getETA()                  //returns the user's ETA for his travel
        {
            return _ETA;
        }


        private double getFootprint()           //returns the user's footprint
        {   
            return _footPrint;
        }


        public void setName(string name)        //setter for user name
        {
            _name = name;
        }


        public void ShowStats()                 //displays the quickstat summary as an innerhtml
        {

        }
    }
}