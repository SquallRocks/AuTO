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

        private int tournamentID;
        private int maxSetups;
        private Dictionary<int, Match> allMatches;
        private List<Match> openMatches;
        private List<Match> pendingMatches;
        private List<Match> closedMatches;
        private List<Match> overdueMatches;
        private Match[] currentMatches;

        #endregion

        public Scheduler (int t_id, Dictionary<int, Match> matches, int setups)
        {
            tournamentID = t_id;
            maxSetups = setups;
            allMatches = matches;

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
        private void SortAscendingNumbers (List<Match> matches)
        {
            matches.Sort((x, y) => y.PlayOrder.CompareTo(x.PlayOrder));  
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

            SortAscendingNumbers(openMatches);
            SortAscendingNumbers(pendingMatches);
        }

        /* Updates state of matches of pending and all matches list directly from
         * Challonge */
        private async void UpdateMatchStatesFromChallonge ()
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

            allMatches = cm;
        }

        /* Schedules top match from open matches and adds it to current matches.
         * Returns list of Match IDs of newly scheduled matches.
         */ 
        public List<int> ScheduleOpenMatches ()
        {
            /* Sort all lists before any scheduling happens; they should already
             * be sorted mostly for most of the time */
            SortAscendingNumbers(openMatches);
            SortAscendingNumbers(pendingMatches);
            SortAscendingNumbers(closedMatches);
            SortAscendingNumbers(overdueMatches);

            List<int> IDs = new List<int>();
            for (int k = 0; k < maxSetups; k++)
            { 
                if (currentMatches[k] == null)
                {
                    Match m = openMatches[0];
                    m.Setup = k + 1;
                    currentMatches[k] = m;

                    IDs.Add(m.ID);
                    openMatches.RemoveAt(0);
                }
            }

            /* If no matches could be scheduled, return null list */
            if (IDs.Count == 0)
                return null;

            return IDs;
        }

        /* Moves match from currentMatches pool to closedMatches pool.
         * Returns true if match was in current matches and moved successfully,
         * false if it was not found */
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
    }
}
