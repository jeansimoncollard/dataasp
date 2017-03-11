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
        public string Chart2Data { get; set; }
        public string Chart2Dates { get; set; }
        public string totalCO2Str { get; set; }
        private JavascriptSerializer _jsArraySerializer;
        private UserHistoryLoader _userHistoryLoader;


        protected void Page_Load(object sender, EventArgs e)
        {
            _userHistoryLoader = new UserHistoryLoader();

            travelbyTypeDisplay();
            volumeCO2Display();



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
            ArrayList dates = new ArrayList();
            ArrayList individualCO2 = new ArrayList();
            for (int i = 0; i < currentUser.UserHistory.Count; i++)
            {
                UserTravelRecord Temp = new UserTravelRecord((UserTravelRecord)currentUser.UserHistory[i]);
                if (individualCO2.Count < 6)
                {
                    dates.Add(" " + Temp.DateOfTrip.Date.Month + "/" + Temp.DateOfTrip.Date.Day + " ");
                }
                if (individualCO2.Count < 6)
                {
                    individualCO2.Add(Temp.VolumeCO2);
                }
                y = y + Temp.VolumeCO2;

            }
            
            _jsArraySerializer = new JavascriptSerializer();

            totalCO2Str = _jsArraySerializer.Serialize(totalCO2);
            Chart2Data = _jsArraySerializer.Serialize(individualCO2);
            Chart2Dates = _jsArraySerializer.Serialize(dates);

        }
    }
}