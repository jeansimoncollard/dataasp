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

        private double _cost;                  //estimated cost in dollars
        private string _costSTR;

        public double getCost()
        {
            return _cost;
        }

        public void SetFootPrint()             //sets the user's ecological footprint based on means of transportation and distance
        {

            switch (_meansOfTransportation)
            {
                case "a Car":
                    _footPrint = Math.Round((GetDistanceInKm()) * (13.86/100), 10);     //100 km means 13.8kg of co2
                    _cost = Math.Round((((GetDistanceInKm()/100)*6.63)*1.11), 2);
                    _costSTR = "based on current average fuel prices for Quebec";
                    break;
                case "the Public Transport system":
                    _footPrint = Math.Round((GetDistanceInKm()) * 0.089, 5); //1km means 0.089kg of co2 per person
                    if (GetDistanceInKm() < 50)
                    {
                        _cost = 3.25;
                        _costSTR = "price of a single bus ticket for local transport";
                        break;

                    }
                    else
                    {
                        _cost = 35.87;
                        _costSTR = "approximate price of an inter-city bus";
                    }
                    break;
                case "a Bicycle":
                    _footPrint = 0;     //per km footprint of bycicle
                    if (GetDistanceInKm() < 50)
                    {
                        _cost = 2.95;
                        _costSTR = "30 minute Bixi Rental";
                        break;
                    }
                    else _cost = 5;
                    _costSTR = "full day Bixi Rental";
                    break;
                case "your feet!":
                    _footPrint = 0;     //for just walking
                    _cost = 0;
                    _costSTR = "free";
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
                "<li>Approximate cost: $" +_cost+ " " +_costSTR+
                "<li>Your Ecological Footprint: " + Math.Round(_footPrint,2) + " Kilograms of CO2</li>"+
                "</ul>";
        }
    }
}