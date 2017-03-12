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

            var isFirst = true;
            foreach (Match line in fileLines)
            {
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }
                
                var record = line.Value.Split(',');

                if (record.Count() <= 2)
                {
                    continue;
                }

                    var latitude = record.Last();
                var longitude = record.ElementAt(record.Count() - 2); //second last

                //remove minus
                longitude = longitude.Substring(1, longitude.Length - 1);
                latitude = latitude.Substring(0, latitude.Length-1);//remove endline 

                insertInDb(latitude, longitude);


            }
        }

        private void insertInDb(string lat, string longitude)
        {
            //insert new values
            var query = $"insert into speedtraps values ('{lat.ToString().Replace(",", ".")}','{longitude.ToString().Replace(",", ".")}')";

            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Connection = connection;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
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