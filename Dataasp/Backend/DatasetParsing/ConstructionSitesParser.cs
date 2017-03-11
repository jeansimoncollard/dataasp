using Dataasp.Backend.DatasetParsing.ParsingTools;
using Dataasp.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Dataasp.Backend.DatasetParsing
{
    public class ConstructionSitesParser
    {
        private ProgramLineDivider _programLineDivider;

        public ConstructionSitesParser()
        {
            _programLineDivider = new ProgramLineDivider();
        }

        public void ParseConstructionSites(string datasetUrl)
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

            var fileLines = _programLineDivider.DivideProgramLines(fileContent);
            foreach (Match line in fileLines)
            {
                var regex = new Regex(@"[0-9]{2}\,[0-9]{13}");
                var match = regex.Matches(line.Value);
                if (match.Count == 2)
                {
                    insertInDb(match);
                }
                var record = line.Value.Split(',');
            }
        }

        private void insertInDb(MatchCollection match)
        {
            //clear table
            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM construction_sites", connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //insert new values
            var query = $"insert into construction_sites values ('{match[0].Value.ToString(CultureInfo.CreateSpecificCulture("en-US"))}','{match[1].Value.ToString(CultureInfo.CreateSpecificCulture("en-US"))}')";

            using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Connection = connection;            // <== lacking
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