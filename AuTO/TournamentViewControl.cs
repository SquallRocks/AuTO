using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuTO
{
    public partial class TournamentViewControl : UserControl
    {
        #region Fields

        private Point tableScrollPoint;
        private Dictionary<int, MatchDisplayControl> matchControls;
       
        private int tournamentID;
        private Scheduler scheduler;
        private List<Match> winnersBracket;
        private List<Match> losersBracket;

        #endregion

        /* For testing */
        public TournamentViewControl()
        {
            InitializeComponent();
            tableScrollPoint = new Point();
        }

        public TournamentViewControl(int t_id, Dictionary<int, string> players,
                                     Dictionary<int, Match> matches, int setups)
        {
            /* DEBUGGING */
            foreach (Match m in matches.Values)
                Console.WriteLine("Match: {0} Round: {1} Order: {2}", m.ID, m.Round, m.PlayOrder);

            InitializeComponent();
            tableScrollPoint = new Point();
            matchControls = new Dictionary<int, MatchDisplayControl>();
            matchCallingControl.SetMasterParent(this);

            tournamentID = t_id;
            scheduler = new Scheduler(t_id, players, matches, setups);

            winnersBracket = new List<Match>();
            losersBracket = new List<Match>();
            scheduler.SplitMatchesByBrackets(ref winnersBracket, ref losersBracket);

            SetupTournamentView(scheduler.MaxWinnerRounds, winnersBracket);
            ScheduleMatches();
        }

        public int GetTournamentID ()
        {
            return tournamentID;
        }

        public void SetupTournamentView (int rounds, List<Match> bracket)
        {
            /* Set number of columns needed at their size */
            tourneyTablePanel.Dock = DockStyle.None;
            tourneyTablePanel.ColumnCount = rounds;

            /* Automatically updates size in case if MatchDisplayControl's size gets
             * updated at some point. */
            Point sizeDummy = new Point(new MatchDisplayControl().Width + 10,
                                        new MatchDisplayControl().Height + 10);
            tourneyTablePanel.Size = new Size(rounds * sizeDummy.X, 
                                              rounds * sizeDummy.Y * 2);  

            /* Set column and row height/width */
            TableLayoutStyleCollection styles = tourneyTablePanel.ColumnStyles;
            foreach (ColumnStyle c in styles)
                c.Width = 200;

            /* Add matches */
            for (int k = 0; k < rounds; k++)
            {
                int curRound = k + 1;

                Panel p = new Panel();
                tourneyTablePanel.Controls.Add(p, k, 1);
                p.Dock = DockStyle.Fill;

                /* Size flow panel by how many games that round has */
                int gamesPerRound = 0;
                foreach (Match match in bracket)
                {
                    if (match.Round == curRound)
                        gamesPerRound++;
                }

                FlowLayoutPanel f = new FlowLayoutPanel();
                f.Name = "FlowLayout Round " + curRound;
                f.Margin = new Padding(0, 0, 0, 0);
                f.AutoSize = false;
                f.AutoScroll = true;
                f.Size = new Size(f.Size.Width, gamesPerRound * sizeDummy.Y);
                f.FlowDirection = FlowDirection.TopDown;
                f.WrapContents = false;
                f.MouseDown += tourneyTablePanel_MouseDown;
                f.MouseMove += matchView_MouseMove;

                /* Add matches related to current round iteration */
                foreach (Match match in bracket)   
                {
                    if (match.Round == curRound)
                    {
                        string p1 = scheduler.GetPlayerNameFromID(match.Player1ID);
                        string p2 = scheduler.GetPlayerNameFromID(match.Player2ID);

                        MatchDisplayControl m = new MatchDisplayControl(this);
                        m.Name = "Match Round " + curRound;
                        m.SetMatchID(match.ID);
                        m.SetPlayer1Name(p1);
                        m.SetPlayer2Name(p2);
                        m.SetSetupLabel("Pending");

                        m.GetSubmitButton().Click += submitButton_Click;

                        matchControls.Add(match.ID, m);
                        f.Controls.Add(m);
                    }
                }

                p.Controls.Add(f);
            }

            /* Add Round headers to each column */
            for (int k = 0; k < rounds; k++)
            {
                Label l = new Label();
                l.Name = "Round " + (k + 1);
                l.Text = l.Name;
                l.Font = new Font("Lucida Sans Unicode", 9.75f, FontStyle.Bold);
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Margin = new Padding(0, 0, 0, 0);
                l.Dock = DockStyle.Fill;
                l.MouseDown += tourneyTablePanel_MouseDown;
                l.MouseMove += tourneyTablePanel_MouseMove;

                tourneyTablePanel.Controls.Add(l, k, 0);
            }
        }

        /* Schedules upcoming matches and notifies user that new matches can be called
         * NOTE: So far, the notifying user portion operaetes by adding items to the upcoming
         * match list as well as changing control colors. */
        private async void ScheduleMatches ()
        {
            //matchCallingControl.ClearUpcomingMatches();
            //matchCallingControl.ClearLongMatches();
            
            /* Schedule newly opened matches and add them to matches-
             * to-call list. */
            await scheduler.UpdateMatchStatesFromChallonge();
            List<Match> newMatches = scheduler.ScheduleOpenMatches();
            foreach (Match m in newMatches)
            {
                /* Check if match exists */
                if (!matchControls.ContainsKey(m.ID))
                {
                    Console.WriteLine("Match doesn't exist! Something was updated in challonge website.");
                    return;
                }

                string p1 = scheduler.GetPlayerNameFromID(m.Player1ID);
                string p2 = scheduler.GetPlayerNameFromID(m.Player2ID);

                /* Set MatchDisplayControl information */
                MatchDisplayControl mdc = matchControls[m.ID];
                mdc.SetPlayer1Name(p1);
                mdc.SetPlayer2Name(p2);
                mdc.SetSetupLabel(String.Format("Setup: {0}", m.Setup));
                mdc.IndicateOpenMatch();

                /* Set match name info in upcoming match list */
                string matchName = String.Format("{0} vs. {1}", p1, p2);
                matchCallingControl.AddItemToUpcomingMatches(matchName, m.ID);
            }
        }

        /* Sets a match as ongoing, changing its control color, removing it from the
         * upcoming match list and putting it in the ongoing match list. */
        public void SetMatchAsOngoing (int id)
        { 
            if (!matchControls.ContainsKey(id))
            {
                Console.WriteLine("Match doesn't exist! Something was updated in challonge website.");
                return;
            }

            MatchDisplayControl mdc = matchControls[id];
            mdc.IndicateOngoingMatch();

            string matchName = String.Format("{0} vs. {1}", mdc.GetPlayer1Name(), mdc.GetPlayer2Name());
            matchCallingControl.DeleteItemFromUpcomingMatches(matchName);
            matchCallingControl.AddItemToCurrentMatches(matchName);
        }

        #region GUI Events

        /* Save mouse position in case if user wants to drag control */
        private void tourneyTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tableScrollPoint = e.Location;
        }

        /* When user drags mouse and left clicks, emulate dragging of horizontal scrollbar */
        private void tourneyTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int pos = e.X + tourneyTablePanel.Left - tableScrollPoint.X;
                pos = (int)Math.Max(pos, -tourneyTablePanel.Size.Width + 500);
                if (pos < 20)
                    tourneyTablePanel.Left = pos;
            }
        }

        /* When user drags mouse and left clicks, emulate dragging of horizontal scrollbar */
        private void matchView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FlowLayoutPanel control = sender as FlowLayoutPanel;
                int pos = e.Y + control.Top - tableScrollPoint.Y;
                pos = (int)Math.Min(pos, 20);
                if (pos > -control.Size.Height + 500)
                control.Top = pos;
            }
        }

        /* Submit score to Challonge */
        private async void submitButton_Click(object sender, EventArgs e)
        {
            MatchDisplayControl parent = ((Button)sender).Parent as MatchDisplayControl;
            if (parent == null)
            {
                Console.WriteLine("MatchDisplayControl that submit button is part of could not be found.");
                return;
            }

            int p1Score = parent.GetPlayer1Score();
            int p2Score = parent.GetPlayer2Score();

            int p1ID = scheduler.GetPlayerIDFromName(parent.GetPlayer1Name());
            int p2ID = scheduler.GetPlayerIDFromName(parent.GetPlayer2Name());

            int winnerID = (p1Score > p2Score) ? p1ID : 
                           (p1Score < p2Score) ? p2ID : -1;

            if (winnerID == -1)
            {
                parent.DisplayErrorLabel("Cannot have same scores!");
                return;
            }

            int matchID = parent.GetMatchID();
            bool success = await scheduler.ReportMatch(matchID, p1Score, p2Score, winnerID);
            if (!success)
            {
                parent.DisplayErrorLabel("Report to Challonge failed.");
                return;
            }

            string matchName = String.Format("{0} vs. {1}", parent.GetPlayer1Name(), parent.GetPlayer2Name());
            matchCallingControl.DeleteItemFromUpcomingMatches(matchName);
            matchCallingControl.DeleteItemFromOngoingMatches(matchName);

            parent.HideErrorLabel();
            parent.IndicateSubmittedMatch();

            scheduler.CloseMatch(matchID);
            ScheduleMatches();
        }

        #endregion

        #region Debugging Tools

        /* FOR DEBUGGING PURPOSES
         * Find what control was clicked.
         * Usage: control.MouseDown += HandleClicks
         */
        private void HandleClicks(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            MessageBox.Show(string.Format("{0} was clicked!", control.Name));
        }

        #endregion
    }
}
