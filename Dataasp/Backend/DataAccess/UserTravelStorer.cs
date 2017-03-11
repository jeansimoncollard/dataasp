using Dataasp.Backend.Entities;
using Dataasp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.DataAccess
{
    public class UserTravelStorer
    {
        public void StoreTravel(UserTravelRecord userTravelRecord)
        {
            //co2 volume to add when function ready.
            var query = $"insert into user_history values ('{userTravelRecord.DateOfTrip.ToString("yyyy-MM-dd HH:mm:ss")}','{userTravelRecord.MetersTravelled}','{(int)userTravelRecord.TravelMode}','{userTravelRecord.Username}','{0}')";

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
                    catch (SqlException e)
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