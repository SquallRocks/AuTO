using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AuTO
{
    /* Objects for JSON serialization/deserialization */
    public class Tournament
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("tournament_type")]
        public string Type;

        [JsonProperty("subdomain")]
        public string Subdomain;

        [JsonProperty("url")]
        public string URL;
    }

    public class Participant
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("seed")]
        public int Seed;
    }

    public class Match
    {
        [JsonProperty("id")]
        public int ID;

        [JsonProperty("player1_id")]
        public int Player1ID;

        [JsonProperty("player2_id")]
        public int Player2ID;

        [JsonProperty("round")]
        public int Round;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("suggested_play_order")]
        public int PlayOrder;

        public int Setup;
    }

    /*
     * NOTE: Score must be formatted in this way:
     * 1-3, player 1 score first
     */ 
    public class ScoreReport
    {
        [JsonProperty("scores_csv")]
        public string Score;

        [JsonProperty("winner_id")]
        public int WinnerID;
    }
}
