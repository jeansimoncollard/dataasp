
using Dataasp.Backend.Entities;
using Dataasp.Backend.Enums;
using Dataasp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dataasp.Backend.DataAccess
{
    public class UserHistoryLoader
    {
        //Call this function to get history data of user. Use HttpContext.Current.User.Identity.Name to get username
        public UserHistoryEntityList LoadHistory(string username)
        {
            var userHistory = new UserHistoryEntityList();
            using (var conn = new SqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand($"Select * from user_history where username=@username", conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userTravelRecord = new UserTravelRecord();

                            if (!reader.IsDBNull(0))
                            {
                                userTravelRecord.DateOfTrip = reader.GetDateTime(0);
                            }
                            if (!reader.IsDBNull(1))
                            {
                                userTravelRecord.MetersTravelled = reader.GetInt32(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                userTravelRecord.TravelMode = (TravelModeEnum)reader.GetInt32(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                userTravelRecord.Username = reader.GetString(3).Trim();
                            }

                            if (!reader.IsDBNull(4))
                            {
                                userTravelRecord.VolumeCO2 = (double)reader[4];
                            }
                            if (!reader.IsDBNull(5))
                            {
                                userTravelRecord.Cost = (double)reader[5];
                            }

                            userHistory.UserHistory.Add(userTravelRecord);
                        }
                    }
                }

                conn.Close();
            }
            return userHistory;
        }

    }
}