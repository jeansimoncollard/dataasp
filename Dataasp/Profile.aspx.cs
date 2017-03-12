using Dataasp.Backend.DataAccess;
using Dataasp.Backend.Entities;
using Dataasp.Backend.Enums;
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
        public string ChartOnCO2Data { get; set; }
        public string Chart2Dates { get; set; }
        public string totalCO2Str { get; set; }
        public string DistanceChartData { get; set; }
        public string totalCostData { get; set; }
        public string costData { get; set; }

        public string AverageChart1Data { get; set; }
        public string AverageChartOnCO2Data { get; set; }
        public string AverageChart2Dates { get; set; }
        public string AveragetotalCO2Str { get; set; }
        public string AverageDistanceChartData { get; set; }
        public string AveragetotalCostData { get; set; }
        public string AveragecostData { get; set; }

        private JavascriptSerializer _jsArraySerializer;
        private UserHistoryLoader _userHistoryLoader;


        protected void Page_Load(object sender, EventArgs e)
        {
            _userHistoryLoader = new UserHistoryLoader();

            travelbyTypeDisplay();
            volumeCO2Display();
            distanceChartDisplay();
            costOfTravelDisplay();
        }
        public void costOfTravelDisplay()
        {
            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                Response.Redirect("~/Account/Register");
            }

            var currentUser = _userHistoryLoader.LoadHistory(HttpContext.Current.User.Identity.Name);
            ArrayList totalCost = new ArrayList() { 0 };
            double y = 0;
            double x = 0;
            ArrayList individualCost = new ArrayList() { 0.0, 0.0, 0.0, 0.0 };
            for (int i = 0; i < currentUser.UserHistory.Count; i++)
            {
                UserTravelRecord Temp = new UserTravelRecord(currentUser.UserHistory[i]);
                y = y + Temp.Cost;
                switch (Temp.TravelMode)
                {
                    case TravelModeEnum.WALKING:
                        x = (double)individualCost[0];
                        x = x + Math.Round(Temp.Cost, 2);
                        individualCost[0] = x;
                        break;
                    case TravelModeEnum.BICYCLING:
                        x = (double)individualCost[1];
                        x = x + Math.Round(Temp.Cost, 2);
                        individualCost[1] = x;
                        break;
                    case TravelModeEnum.TRANSIT:
                        x = (double)individualCost[2];
                        x = x + Math.Round(Temp.Cost, 2);
                        individualCost[2] = x;
                        break;
                    case TravelModeEnum.DRIVING:
                        x = (double)individualCost[3];
                        x = x + Math.Round(Temp.Cost, 2);
                        individualCost[3] = x;
                        break;


                }

            }

            _jsArraySerializer = new JavascriptSerializer();
            totalCost[0] = Math.Round(y, 2);
            totalCostData = _jsArraySerializer.Serialize(totalCost);
            costData = _jsArraySerializer.Serialize(individualCost);

        }

        public void distanceChartDisplay()
        {
            var currentUser = _userHistoryLoader.LoadHistory(HttpContext.Current.User.Identity.Name);
            ArrayList distanceByType = new ArrayList() { 0.0, 0.0, 0.0, 0.0 };
            double x = 0;
            for (int i = 0; i < currentUser.UserHistory.Count; i++)
            {
                UserTravelRecord Temp = new UserTravelRecord((UserTravelRecord)currentUser.UserHistory[i]);
                double kilometersTravelled = (Temp.MetersTravelled / 1000.0);
                switch (Temp.TravelMode)
                {
                    case TravelModeEnum.WALKING:
                        kilometersTravelled += (double)distanceByType[0];
                        distanceByType[0] = kilometersTravelled;
                        break;
                    case TravelModeEnum.BICYCLING:
                        x = (double)distanceByType[1];
                        x += kilometersTravelled;
                        distanceByType[1] = x;
                        break;
                    case TravelModeEnum.TRANSIT:
                        x = (double)distanceByType[2];
                        x += kilometersTravelled;
                        distanceByType[2] = x;
                        break;
                    case TravelModeEnum.DRIVING:
                        x = (double)distanceByType[3];
                        x += kilometersTravelled;
                        distanceByType[3] = x;
                        break;


                }

            }
            for (int i = 0; i < distanceByType.Count; i++)
            {
                x = (double)distanceByType[i];
                distanceByType[i] = Math.Round(x, 2);
            }
            _jsArraySerializer = new JavascriptSerializer();

            DistanceChartData = _jsArraySerializer.Serialize(distanceByType);

        }

        public void travelbyTypeDisplay()
        {
            var currentUser = _userHistoryLoader.LoadHistory(HttpContext.Current.User.Identity.Name);
            ArrayList travelByType = new ArrayList() { 0, 0, 0, 0 };
            int x = 0;
            for (int i = 0; i < currentUser.UserHistory.Count; i++)
            {
                UserTravelRecord Temp = new UserTravelRecord((UserTravelRecord)currentUser.UserHistory[i]);
                switch (Temp.TravelMode)
                {
                    case TravelModeEnum.WALKING:
                        x = (int)travelByType[0];
                        x++;
                        travelByType[0] = x;
                        break;
                    case TravelModeEnum.BICYCLING:
                        x = (int)travelByType[1];
                        x++;
                        travelByType[1] = x;
                        break;
                    case TravelModeEnum.TRANSIT:
                        x = (int)travelByType[2];
                        x++;
                        travelByType[2] = x;
                        break;
                    case TravelModeEnum.DRIVING:
                        x = (int)travelByType[3];
                        x++;
                        travelByType[3] = x;
                        break;


                }

            }
            float y = 0;
            for (int i = 0; i < travelByType.Count; i++)
            {
                y = (int)travelByType[i];
                y = ((y / currentUser.UserHistory.Count) * 100);
                travelByType[i] = y;
            }
            _jsArraySerializer = new JavascriptSerializer();

            Chart1Data = _jsArraySerializer.Serialize(travelByType);

            //Chart1Data = _jsArraySerializer.Serialize(new ArrayList() { 1, 2, 3, 4 });

        }
        public void volumeCO2Display()
        {
            var currentUser = _userHistoryLoader.LoadHistory(HttpContext.Current.User.Identity.Name);
            ArrayList totalCO2 = new ArrayList() { 0 };
            double y = 0;
            double w = 0;
            ArrayList dates = new ArrayList();
            ArrayList individualCO2 = new ArrayList();

            for (var i = 0; i < 12; i++)
            {
                individualCO2.Add(0.0);
            }

            ArrayList AverageCO2 = new ArrayList();
            for (int i = 0; i < currentUser.UserHistory.Count; i++)
            {
                UserTravelRecord Temp = new UserTravelRecord(currentUser.UserHistory[i]);

                var x = (double)individualCO2[Temp.DateOfTrip.Month - 1];
                x += Temp.VolumeCO2;
                y = y + Temp.VolumeCO2;
                individualCO2[Temp.DateOfTrip.Month - 1] = x;
            }

            _jsArraySerializer = new JavascriptSerializer();
            totalCO2[0] = Math.Round(y, 2);
            totalCO2Str = _jsArraySerializer.Serialize(totalCO2);
            ChartOnCO2Data = _jsArraySerializer.Serialize(individualCO2);
            AverageChartOnCO2Data = _jsArraySerializer.Serialize(AverageCO2);
            Chart2Dates = _jsArraySerializer.Serialize(dates);
            AverageChart2Dates = _jsArraySerializer.Serialize(dates);
        }
    }
}