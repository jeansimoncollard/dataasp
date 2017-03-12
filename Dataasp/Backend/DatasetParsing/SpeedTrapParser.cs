using Dataasp.Backend.DatasetParsing.ParsingTools;
using Dataasp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Dataasp.Backend.DatasetParsing
{
    public class SpeedTrapParser
    {

        private ProgramLineDivider _programLineDivider;

        public SpeedTrapParser()
        {
            _programLineDivider = new ProgramLineDivider();
        }

        public void Parse(string datasetUrl)
        {
            loadFileInDb(readAllText(datasetUrl));
        }

        private string readAllText(string datasetUrl)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(datasetUrl);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();

            sr.Close();
            return results;
        }

        private void loadFileInDb(string fileContent)
        {
            //clear table
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM speedtraps", connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            var fileLines = _programLineDivider.DivideProgramLines(fileContent);
            foreach (Match line in fileLines)
            {
                var record = line.Value.Split(',');

                var latitude = record.Last();
                var longitude = record.ElementAt(record.Count() - 2); //second last

                insertInDb(latitude,longitude);


            }
        }

        private void insertInDb(string lat, string longitude)
        {
            //insert new values
            ////var query = $"insert into speedtraps values ('{match[0].Value.Replace(",", ".")}','{match[1].Value.Replace(",", ".")}')";

            //using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            //{
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Connection = connection;
            //        try
            //        {
            //            connection.Open();
            //            command.ExecuteNonQuery();
            //        }
            //        catch (SqlException)
            //        {
            //            // error here
            //        }
            //        finally
            //        {
            //            connection.Close();
            //        }
            //    }
            //}
        }
    }
}