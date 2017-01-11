using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTO
{
    public class Scheduler
    {
        #region Fields

        public int MaxWinnerRounds;
        public int MaxLoserRounds;
        public int MaxMatchesPerRound;

        private int tournamentID;
        private int maxSetups;
        
        private Dictionary<int, Match> allMatches;
        private Dictionary<int, string> players;

        private List<Match> openMatches;
        private List<Match> pendingMatches;
        private List<Match> closedMatches;
        private List<Match> overdueMatches;
        private Match[] currentMatches;

        #endregion

        public Scheduler (int t_id, Dictionary<int, string> playerIDs, 
                          Dictionary<int, Match> matches, int setups)
        {
            tournamentID = t_id;
            maxSetups = setups;
            MaxWinnerRounds = 0;
            MaxLoserRounds = 0;

            players = playerIDs;
            allMatches = matches;

            /* DEBUGGING */
            //foreach (Match m in matches.Values)
            //    Console.WriteLine("Match: {0} Round: {1} Order: {2}", m.ID, m.Round, m.PlayOrder);

            openMatches = new List<Match>();
            pendingMatches = new List<Match>();
            closedMatches = new List<Match>();
            overdueMatches = new List<Match>();
            currentMatches = new Match[maxSetups];

            InitialMatchSetup();
        }
        
        /* Sorts a match based on play order, lesser numbers first
         * i.e. (3, 5, 2, 7) => (2, 3, 5, 7)
         */ 
        private void SortDescendingNumbers (ref List<Match> matches)
        {
            matches.Sort((x, y) => y.PlayOrder.CompareTo(x.PlayOrder));  
        }

        /* Sorts a match based on play order, greater numbers first
         * i.e. (3, 5, 2, 7) => (7, 5, 3, 2)
         */
        private void SortAscendingNumbers(ref List<Match> matches)
        {
            matches.Sort((x, y) => x.PlayOrder.CompareTo(y.PlayOrder));
        }

        /* Checks if there is an open match; if so, returns match and removes it
         * from open match list; if not, returns null. */
        private Match PopTopOpenMatch ()
        { 
            Match m = null;
            if (openMatches.Count > 0 && openMatches[0] != null)
            {
                m = openMatches[0];
                openMatches.RemoveAt(0);
            }

            return m;
        }

        /* Separates matches into open and pending pools */
        private void InitialMatchSetup ()
        { 
            foreach (Match m in allMatches.Values)
            {
                if (m.State.Equals("open"))
                    openMatches.Add(m);
                else if (m.State.Equals("pending"))
                    pendingMatches.Add(m);
                else
                    Console.WriteLine("There's another state we did not know of");
            }

            SortAscendingNumbers(ref openMatches);
            SortAscendingNumbers(ref pendingMatches);
        }

        /* Splits matches into winner's (positive rounds) and loser's (negative rounds).
         * Also determines max number of rounds needed for each bracket. */
        public void SplitMatchesByBrackets (ref List<Match> winners, ref List<Match> losers)
        {
            int maxWinners = 0;
            int maxLosers = 0;
            foreach (Match m in allMatches.Values)
            {
                if (m.Round > 0)
                {
                    winners.Add(m);
                    if (maxWinners < m.Round)
                        maxWinners = m.Round;
                }
                else
                { 
                    losers.Add(m);
                    if (maxLosers > m.Round)        /* REMEMBER: Loser rounds are negative */
                        maxLosers = m.Round;
                }
            }

            MaxWinnerRounds = maxWinners;
            MaxLoserRounds = maxLosers;

            /* Sort matches by play order */
            SortAscendingNumbers(ref winners);
            SortAscendingNumbers(ref losers);
        }

        /* Updates state of matches of pending and all matches list directly from
         * Challonge */
        public async void UpdateMatchStatesFromChallonge ()
        {
            /* Retrieve most updated list of matches */
            Dictionary<int, Match> cm = await Challonge.RetrieveMatches(tournamentID);

            /* Using ToArray() so that we can remove items from the list while
             * iterating through it */
            foreach (Match m in pendingMatches.ToArray())
            { 
                if (cm.Keys.Contains<int>(m.ID))
                { 
                    if (cm[m.ID].State.Equals("open"))
                    {
                        openMatches.Add(cm[m.ID]);
                        pendingMatches.Remove(m);
                    }
                }
            }
        }

        /* Schedules top match from open matches and adds it to current matches.
         * Returns list of newly scheduled matches. List is null if no matches
         * could be scheduled. */ 
        public List<Match> ScheduleOpenMatches ()
        {
            /* Sort all lists before any scheduling happens; they should already
             * be sorted mostly for most of the time */
            SortAscendingNumbers(ref openMatches);
            SortAscendingNumbers(ref pendingMatches);
            SortAscendingNumbers(ref closedMatches);
            SortAscendingNumbers(ref overdueMatches);

            List<Match> matches = new List<Match>();
            for (int k = 0; k < maxSetups; k++)
            { 
                /* Look for an empty spot in currentMatches array */
                if (currentMatches[k] == null)
                {
                    Match m = PopTopOpenMatch();
                    if (m == null)
                        break;

                    m.Setup = k + 1;
                    currentMatches[k] = m;

                    matches.Add(m);
                }
            }

            return matches;
         }

        /* Moves match from currentMatches pool to closedMatches pool.
         * Returns true if match was in current matches and moved successfully,
         * false if it was not found. */
        public bool CloseMatch (int matchID)
        { 
            for (int k = 0; k < maxSetups; k++)
            {
                Match m = currentMatches[k];
                if (m != null)
                { 
                    if (m.ID == matchID)
                    {
                        m.State = "closed";
                        closedMatches.Add(m);
                        currentMatches[k] = null;
                        return true;
                    }
                }
            }

            return false;
        }

        /* Formats match score and sends it to Challonge. 
         * If successful, will move match from current to closed matches. */
        public async Task<bool> ReportMatch (int matchID, int p1Score, int p2Score, int winnerID)
        {
            for (int k = 0; k < maxSetups; k++)
            {
                Match m = currentMatches[k];
                if (m != null)
                { 
                    if (m.ID == matchID)
                    {
                        ScoreReport s = new ScoreReport();
                        s.Score = string.Format("{0}-{1}", p1Score, p2Score);
                        s.WinnerID = winnerID;

                        int validated = await Challonge.SubmitMatchScore(tournamentID, matchID, s);
                        if (validated > 0)
                            return true;
                    }
                }
            }

            return false;
        }

        /* Retrieves player's name from their ID */
        public string GetPlayerNameFromID (int id)
        {
            if (!players.Keys.Contains<int>(id))
                return null;

            return players[id];
        }

        /* Retrieves player's ID from their name. 
         * Returns -1 if name is not in system. */
        public int GetPlayerIDFromName (string name)
        {
            if (!players.Values.Contains<string>(name))
                return -1;

            /* This is safe since there are no duplicate names/IDs in
             * this dictionary */
            return players.First(x => x.Value.Equals(name)).Key;
        }
    }
}
