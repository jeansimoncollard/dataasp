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

        public void SetFootPrint()             //sets the user's ecological footprint based on means of transportation and distance
        {
            switch (_meansOfTransportation)
            {
                case "a Car": _footPrint = Math.Round(( _distance) * (0.023/100), 10);     //100 km means 0.023t of co2
                    break;
                case "the Public Transport system": _footPrint = Math.Round((_distance / 100.0) * 0.01, 5); //100km means 0.01t of co2
                    break;
                case "a Bicycle": _footPrint = Math.Round((_distance / 1.6) * (150.0 / 1000 / 1000) / 100, 15);     //per km footprint of bycicle
                    break;
                case "your feet!": _footPrint = Math.Round((_distance / 1.6) * (75.0 / 1000 / 1000) / 100, 15);     //for just walking
                    break;
            }
        }


        public void SetMeansOfTransportation(string transp)
        {
            switch (transp)
            {
                case "DRIVING":
                    _meansOfTransportation = "a Car";
                    break;
                case "TRANSIT": _meansOfTransportation = "the Public Transport system";
                    break;
                case "BICYCLING": _meansOfTransportation = "a Bicycle";
                    break;
                case "WALKING": _meansOfTransportation = "your feet!";
                    break;
            }
        }


        public double GetETA()                  //returns the user's ETA for his travel
        {
            return _ETA;
        }


        public double GetFootprint()           //returns the user's footprint
        {   
            return _footPrint;
        }


        public void SetName(string name)        //setter for user name
        {
            _name = name;
        }


        public void SetDistance(double dist)
        {
            _distance = dist;
        }


        public double GetDistanceInKm()
        {
            return Math.Round(_distance / 1000, 2);
        }


        public void ShowStats(System.Web.UI.HtmlControls.HtmlGenericControl div)                 //displays the quickstat summary as an innerhtml
        {
            div.InnerHtml = 
                "<ul> <li>Your name: "+ _name+"</li>"+
                "<li>Distance: "+ GetDistanceInKm() + " km</li>"+
                "<li>Using: "+ _meansOfTransportation + "</li>"+
                "<li>Your Ecological Footprint: " + Math.Round(_footPrint,2) + " metric tons of co2</li>"+
                "<li>Slider Value: </li>"+
                "</ul>";
        }
    }
}