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
        
        /* Sorts a match based on play order, greater numbers first
         * i.e. (3, 5, 2, 7) => (7, 5, 3, 2)  */
        private void SortDescendingNumbers (ref List<Match> matches)
        {
            matches.Sort((x, y) => y.PlayOrder.CompareTo(x.PlayOrder));  
        }

        /* Sorts a match based on play order, lesser numbers first
         * i.e. (3, 5, 2, 7) => (2, 3, 5, 7) */ 
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
            foreach (Match m in allMatches.Values.ToList())
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
        public async Task<bool> UpdateMatchStatesFromChallonge ()
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

            return true;
        }

        /* Swaps player 1's matches with player 2's in all open and pending 
         * matches between them.
         * Returns a list of open matches that have been updated. */
        public List<Match> SwapPlayers (int player1ID, int player2ID)
        {
            List<Match> origCurrentList = currentMatches.ToList<Match>();
            List<Match> origPendingList = pendingMatches.ToList<Match>();
            List<Match> updatedMatches = new List<Match>();
            
            /* Swap open matches */
            for (int k = 0; k < origCurrentList.Count; k++)
            {
                Match m = currentMatches[k];
                if (m == null)
                    continue;
    
                /* Swap player 1 into player 2's matches */
                if (m.Player1ID == player2ID)
                {
                    m.Player1ID = player1ID;
                    updatedMatches.Add(m);
                }
                else if (m.Player2ID == player2ID)
                {
                    m.Player2ID = player1ID;
                    updatedMatches.Add(m);
                }
                /* Swap player 2 into player 1's matches */
                else if (m.Player1ID == player1ID)
                {
                    m.Player1ID = player2ID;
                    updatedMatches.Add(m);
                }
                else if (m.Player2ID == player1ID)
                {
                    m.Player2ID = player2ID;
                    updatedMatches.Add(m);
                }
            }

            /* Swap future pending matches */
            for (int k = 0; k < origPendingList.Count; k++)
            {
                Match m = pendingMatches[k];

                /* Swap player 1 into player 2's matches */
                if (m.Player1ID == player2ID)
                    m.Player1ID = player1ID;
                else if (m.Player2ID == player2ID)
                    m.Player2ID = player1ID;
                /* Swap player 2 into player 1's matches */
                else if (m.Player1ID == player1ID)
                    m.Player1ID = player2ID;
                else if (m.Player2ID == player1ID)
                    m.Player2ID = player2ID;
            }

            return updatedMatches;
        }

        /* Schedules top match from open matches and adds it to current matches.
         * Returns list of newly scheduled matches. List is null if no matches
         * could be scheduled. */ 
        public List<Match> ScheduleOpenMatches (bool sort)
        {
            /* Sort all lists before any scheduling happens; they should already
             * be sorted mostly for most of the time */
            if (sort)
            { 
                SortAscendingNumbers(ref openMatches);
                SortAscendingNumbers(ref pendingMatches);
                SortAscendingNumbers(ref closedMatches);
                SortAscendingNumbers(ref overdueMatches);
            }

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

        /* Skips an open match (if it exists) and puts match in pending state */
        public bool SkipMatch (int matchID, int setup)
        {
            int index = setup - 1;
            Match m = currentMatches[index];

            /* If this is the only currently available match, don't skip it */
            int count = 0;
            foreach (Match match in currentMatches)
                if (match != null)
                    ++count;
            /* Skip if there are not enough matches to warrent a skip */
            if (count < 2)
                return false;

            /* If match exists, skip it */
            if (m != null && m.ID == matchID)
            {
                m.State = "pending";
                pendingMatches.Add(m);
                currentMatches[index] = null;

                return true;
            }

            return false;
        }

        /* Swaps setup numbers and returns newSetupIndex's match ID*/
        public int SwapMatch(int origSetupIndex, int newSetupIndex)
        {
            if (origSetupIndex >= maxSetups || newSetupIndex >= maxSetups)
                throw new ArgumentOutOfRangeException();

            Match temp = currentMatches[origSetupIndex];
            currentMatches[origSetupIndex] = currentMatches[newSetupIndex];
            currentMatches[newSetupIndex] = temp;

            return currentMatches[origSetupIndex].ID;
        }

        /* Formats match score and sends it to Challonge. 
         * If successful, will move match from current to closed matches. */
        public async Task<bool> ReportMatch (int matchID, int p1Score, int p2Score, int winnerID)
        {
            /* If match is current being played, find it so that it can be cleared if score
             * submission is successful. */
            int k = 0;
            bool found = false;
            for (; k < maxSetups; k++)
            {
                Match m = currentMatches[k];
                if (m != null)
                { 
                    if (m.ID == matchID)
                    {
                        found = true;
                        break;
                    }
                }
            }

            ScoreReport s = new ScoreReport();
            s.Score = string.Format("{0}-{1}", p1Score, p2Score);
            s.WinnerID = winnerID;

            int validated = await Challonge.SubmitMatchScore(tournamentID, matchID, s);
            if (validated > 0)
            {
                if (found)
                    currentMatches[k] = null;

                return true;
            }

            return false;
        }

        /* Checks if all matches have been played */
        public bool CheckIfTournamentEnded ()
        {
            if (openMatches.Count == 0 && pendingMatches.Count == 0)
            {
                foreach (Match m in currentMatches)
                    if (m != null)
                        return false;

                return true;
            }

            return false;
        }

        /* Returns maximum number of setups tourney has */
        public int GetMaxSetups ()
        {
            return maxSetups;
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
