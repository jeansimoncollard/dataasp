
using Dataasp.Backend.Entities;
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
        public UserHistoryEntity LoadHistory(string username)
        {
            var userHistory = new UserHistoryEntity();

            using (var conn = new SqlConnection(Settings.Default.ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand($"Select * from user_history where username=@username", conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userHistory.UserHistory.Add(new UserTravelRecord()
                            {
                                

                            });
                            Console.WriteLine(String.Format("{0}", reader["id"]));
                        }
                    }
                }

                conn.Close();
            }
            return userHistory;
        }
    }
}