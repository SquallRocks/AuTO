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
            //string json = await Task.Run(() => JsonConvert.SerializeObject(t));
            //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //string jsonContent = await content.ReadAsStringAsync();
            //Console.WriteLine("Content: \n{0}", jsonContent);
            //HttpResponseMessage response = await client.PostAsync(tURL, content);

            HttpResponseMessage response = await client.PostAsJsonAsync(tURL, t);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("RESULT FROM CREATING TOURNAMENT: \n{0}", result);

            if (result.Contains("URL has already been taken"))
                return -100;

            if (!response.IsSuccessStatusCode)
                return -200;

            /* Retrieve tournament ID */
            /* NOTE: Not a very elegant way to retrieve JSON value */
            int id;
            JObject json = JObject.Parse(result);
            JToken token = json.First.First.First.First;
            if (!Int32.TryParse(token.ToString(), out id))
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
            Console.WriteLine("RESULT FROM GET TOURNAMENT: \n{0}", result);

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
            Console.WriteLine("RESULT: \n{0}", result);

            if (!response.IsSuccessStatusCode)
                return -200;

            /* Retrieve participant ID */
            /* NOTE: Not a very elegant way to retrieve JSON value */
            int id;
            JObject json = JObject.Parse(result);
            JToken token = json.First.First.First.First;
            if (!Int32.TryParse(token.ToString(), out id))
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
    }
}
