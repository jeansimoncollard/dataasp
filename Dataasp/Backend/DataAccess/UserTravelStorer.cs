using Dataasp.Backend.Entities;
using Dataasp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.DataAccess
{
    public class UserTravelStorer
    {
        public void StoreTravel(UserTravelRecord userTravelRecord)
        {
            if (string.IsNullOrEmpty(userTravelRecord.Username))
            {
                return;
            }
            //co2 volume to add when function ready.
            var query = $"insert into user_history values ('{userTravelRecord.DateOfTrip.ToString("yyyy-MM-dd HH:mm:ss")}','{userTravelRecord.MetersTravelled}','{(int)userTravelRecord.TravelMode}','{userTravelRecord.Username}',{userTravelRecord.VolumeCO2.ToString(CultureInfo.CreateSpecificCulture("en-US"))},{userTravelRecord.Cost.ToString(CultureInfo.CreateSpecificCulture("en-US"))})";

            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Connection = connection;            // <== lacking
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}