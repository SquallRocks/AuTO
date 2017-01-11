using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AuTO
{ 
    public static class Challonge
    {
        public static string BASE_URL;
        private static HttpClient client;
    
        // Make sure login information is correct
        // Note: This function is the first function to communicate with the challonge server;
        // thus it will set up the shared HttpClient and if user info is valid, set up the 
        // base URL.
        public static async Task<Boolean> AuthenticateLogin (string user, string key)
        {
            // Set up HttpClient to communicate with Challonge
            if (client == null) client = new HttpClient();

            byte[] byteArray = new UTF8Encoding().GetBytes(String.Format("{0}:{1}", user, key));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                                                             "Basic", Convert.ToBase64String(byteArray));

            string url = "https://api.challonge.com/v1";

            string test = url + "/tournaments.json";
            HttpResponseMessage response = await client.GetAsync(test);
            if (!response.IsSuccessStatusCode)
                return false;
          
            BASE_URL = url;
            return true;
        }

        #region Tournament

        /* Sends JSON to Challonge to create a tournament. Returns a status code. 
         * 200 = OK
         * -100 = URL already taken
         * -200 = Programming error
         * -300 = No Tournament ID
         */
        public static async Task<int> CreateTournament (Tournament t)
        {
            Uri tURL = new Uri(BASE_URL + "/tournaments.json");

            /* FOR DEBUGGING PURPOSES */
            //string j = await Task.Run(() => JsonConvert.SerializeObject(t));
            //StringContent content = new StringContent(j, Encoding.UTF8, "application/json");
            //string jsonContent = await content.ReadAsStringAsync();
            //Console.WriteLine("Content: \n{0}", jsonContent);
            //HttpResponseMessage response = await client.PostAsync(tURL, content);

            HttpResponseMessage response = await client.PostAsJsonAsync(tURL, t);
            string result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("RESULT FROM CREATING TOURNAMENT: \n{0}", result);

            if (result.Contains("taken"))
                return -100;

            if (!response.IsSuccessStatusCode)
                return -200;

            /* Retrieve tournament ID
             * NOTE: In order to traverse JSON, need to retrieve correct level first
             */ 
            JObject json = JObject.Parse(result);
            JToken tourneyToken = json.SelectToken("tournament");
            JToken token = tourneyToken.SelectToken("id");

            int id = RetrieveIntFromString(token.ToString());
            if (id == -200)
                return -300;
            else
                return id;
        }

        /* Makes sure created tournament is accessibile. Does not support subdomains
         * 200 = OK
         * -404 = Not Found
         */
        public static async Task<int> GetTournament(int t_id)
        {
            Uri tURL = new Uri(String.Format("{0}/tournaments/{1}.json",
                               BASE_URL, t_id));

            HttpResponseMessage response = await client.GetAsync(tURL);
            string result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("RESULT FROM GET TOURNAMENT: \n{0}", result);

            if (!response.IsSuccessStatusCode)
                return -404;

            return 200;
        }

        /* Sends JSON to Challonge to add a participant to the tournament 
         * poas # = OK, playerID
         * -200 = Unhandled programming error
         * -300 = No Player ID
         */
        public static async Task<int> AddPlayer(int t_id, Participant p)
        {
            Uri tURL = new Uri(String.Format("{0}/tournaments/{1}/participants.json",
                               BASE_URL, t_id));

            /* Format JSON to send to server */
            HttpResponseMessage response = await client.PostAsJsonAsync(tURL, p);
            string result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("RESULT: \n{0}", result);

            if (!response.IsSuccessStatusCode)
                return -200;
            

            /* Retrieve participant ID */
            JObject json = JObject.Parse(result);
            JToken tourneyToken = json.SelectToken("participant");
            JToken token = tourneyToken.SelectToken("id");

            int id = RetrieveIntFromString(token.ToString());
            if (id == -200)
                return -300;
            else
                return id;
        }

        /* Officially starts torunament; cannot add players after this.
         * 200 = OK
         * -200 = Unhandled programming error
         * -300 = No Tounrmanet ID
         */
        public static async Task<int> StartTournament(int t_id)
        {
            Uri tURL = new Uri(String.Format("{0}/tournaments/{1}/start.json",
                               BASE_URL, t_id));

            HttpResponseMessage response = await client.PostAsJsonAsync(tURL, new Tournament());
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("RESULT: \n{0}", result);

            if (!response.IsSuccessStatusCode)
                return -200;

            return 200;
        }

        public static async Task<int> DeleteTournament(int t_id)
        {
            Uri tURL = new Uri(String.Format("{0}/tournaments/{1}.json",
                               BASE_URL, t_id));

            HttpResponseMessage response = await client.DeleteAsync(tURL);
            if (!response.IsSuccessStatusCode)
                return -200;

            return 200;
        }

        #endregion

        #region Match

        /* Retrieves match list from a tounament.
         * NOTE: returns null if something went wrong, else returns the list of matches.
         */ 
        public static async Task<Dictionary<int, Match>> RetrieveMatches(int t_id)
        {
            Uri tURL = new Uri(String.Format("{0}/tournaments/{1}/matches.json",
                               BASE_URL, t_id));

            HttpResponseMessage response = await client.GetAsync(tURL);
            string result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("RESULT FROM GET TOURNAMENT: \n{0}", result);

            if (!response.IsSuccessStatusCode)
                return null;

            /* Retrieve Matches, parse valuable info into matches, and add them into dictionary */
            Dictionary<int, Match> matches = new Dictionary<int, Match>();
            JArray json = JArray.Parse(result);
            foreach (JObject o in json.Children<JObject>())
            {
                foreach (JToken t in o.SelectTokens("match"))
                {
                    Match m = new Match();
                    int id = RetrieveIntFromString(t.SelectToken("id").ToString());
                    if (id == -200)
                        return null;

                    int p1ID = RetrieveIntFromString(t.SelectToken("player1_id").ToString());
                    if (p1ID == -200)
                        return null;

                    int p2ID = RetrieveIntFromString(t.SelectToken("player2_id").ToString());
                    if (p2ID == -200)
                        return null;

                    int round = RetrieveIntFromString(t.SelectToken("round").ToString());
                    if (round == -200)
                        return null;

                    int order = RetrieveIntFromString(t.SelectToken("suggested_play_order").ToString());
                    if (order == -200)
                        return null;

                    m.ID = id;
                    m.Player1ID = p1ID;
                    m.Player2ID = p2ID;
                    m.Round = round;
                    m.State = t.SelectToken("state").ToString();
                    m.PlayOrder = order;
                    matches.Add(m.ID, m);
                }
            }

            return matches;
        }

        /* Submits the score of a specified match.
         * 200 = OK
         * -200 = Unhandled programming exception
         */ 
        public static async Task<int> SubmitMatchScore (int t_id, int matchID, ScoreReport report)
        {
            Uri tURL = new Uri(String.Format("{0}/tournaments/{1}/matches/{2}.json",
                                BASE_URL, t_id, matchID));

            /* XML DEBUGGING; DOESN'T WORK */
            //String xml = String.Format("<scores-csv>{0}</scores-csv><winner-id type=\"integer\">{1}</winner-id>", report.scores_csv, report.winner_id);

            //XElement xml = new XElement("match",
            //    new XElement("scores_csv", report.scores_csv),
            //    new XElement("winner_id", new XAttribute("type", "integer"), report.winner_id)
            //);

            //StringContent content = new StringContent(xml.ToString(), Encoding.UTF8, "application/xml");
            //string xmlContent = await content.ReadAsStringAsync();
            //Console.WriteLine("Content: \n{0}", xmlContent);

            string j = await Task.Run(() => JsonConvert.SerializeObject(report));
            StringContent content = new StringContent(j, Encoding.UTF8, "application/json");
            string jsonContent = await content.ReadAsStringAsync();
            Console.WriteLine("Content: \n{0}", jsonContent);

            HttpResponseMessage response = await client.PutAsync(tURL, content);
            //HttpResponseMessage response = await client.PutAsJsonAsync(tURL, report);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("RESULT FROM REPORTING SCORES: \n{0}", result);

            if (!response.IsSuccessStatusCode)
                return -200;

            return 200;
        }

        #endregion

        #region Helper Functions

        /* Retrieve numerical value of string */
        private static int RetrieveIntFromString (string s_int)
        {
            if (string.IsNullOrEmpty(s_int))
                return 0;

            int value;
            if (!Int32.TryParse(s_int, out value))
                return -200;

            return value;
        }

        #endregion
    }
}
