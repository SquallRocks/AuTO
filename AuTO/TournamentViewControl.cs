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
        private MainForm parentForm;
        private Button endTourneyButton;
        private Dictionary<int, MatchDisplayControl> matchControls;
       
        private int tournamentID;
        private string tournamentName;
        private bool isDoubleElim;
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

        public TournamentViewControl(int t_id, string name, Dictionary<int, string> players,
                                     Dictionary<int, Match> matches, int setups, bool doubleElim)
        {
            /* DEBUGGING */
            //foreach (Match m in matches.Values)
            //    Console.WriteLine("Match: {0} Round: {1} Order: {2}", m.ID, m.Round, m.PlayOrder);

            InitializeComponent();
            tableScrollPoint = new Point();
            endTourneyButton = null;
            matchControls = new Dictionary<int, MatchDisplayControl>();
            matchCallingControl.SetMasterParent(this);

            tournamentID = t_id;
            tournamentName = name;
            isDoubleElim = doubleElim;
            scheduler = new Scheduler(t_id, players, matches, setups);

            winnersBracket = new List<Match>();
            losersBracket = new List<Match>();
            scheduler.SplitMatchesByBrackets(ref winnersBracket, ref losersBracket);

            /* Setup tournament views for winners and losers brackets */
            SetupTournamentView(winnerTablePanel,scheduler.MaxWinnerRounds, winnersBracket);
            SetupTournamentView(loserTablePanel, scheduler.MaxLoserRounds, losersBracket);

            winnerTablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            loserTablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            ScheduleMatches();
        }

        public int GetTournamentID ()
        {
            return tournamentID;
        }

        public void SetBracketButtons (MainForm mainForm)
        {
            parentForm = mainForm;
            mainForm.SetTournamentName(tournamentName);
            mainForm.SetTournamentID(tournamentID);

            /* Setup bracket button functionality, if applicable. */
            if (isDoubleElim)
            {
                mainForm.GetWinnersButton().Click += winnersButton_Click;
                mainForm.GetLosersButton().Click += losersButton_Click;
                mainForm.ShowBracketButtons();

                mainForm.SetHeaderText(tournamentName + " - Winner's Bracket");
            }
            else
            {
                mainForm.HideBracketButtons();
                mainForm.SetHeaderText(tournamentName);
            }

            winnerTablePanel.Visible = true;
            loserTablePanel.Visible = false;
        }

        public void SetupTournamentView (TableLayoutPanel panel, int rounds, List<Match> bracket)
        {
            /* Loser rounds are negative */
            rounds = (int)Math.Abs(rounds);

            /* Set number of columns needed at their size */
            panel.Dock = DockStyle.None;
            panel.ColumnCount = (int)Math.Abs(rounds);

            /* Automatically updates size in case if MatchDisplayControl's size gets
             * updated at some point. */
            Point sizeDummy = new Point(new MatchDisplayControl().Width + 7,
                                        new MatchDisplayControl().Height + 10);
            panel.Size = new Size((rounds + 1) * sizeDummy.X, rounds * sizeDummy.Y * 2);  

            /* Set column and row height/width */
            TableLayoutStyleCollection styles = panel.ColumnStyles;
            foreach (ColumnStyle c in styles)
            { 
                c.SizeType = SizeType.AutoSize;
            }

            /* Add matches */
            for (int k = 0; k < rounds; k++)
            {
                int curRound = k + 1;

                Panel p = new Panel();
                panel.Controls.Add(p, k, 1);
                p.Dock = DockStyle.Fill;

                /* Size flow panel by how many games that round has */
                int gamesPerRound = 0;
                foreach (Match match in bracket)
                {
                    if ((int)Math.Abs(match.Round) == curRound)
                        gamesPerRound++;
                }

                FlowLayoutPanel f = new FlowLayoutPanel();
                f.Margin = new Padding(0, 0, 0, 0);
                f.AutoSize = false;
                f.AutoScroll = true;
                f.Size = new Size(f.Size.Width, (gamesPerRound + 1) * sizeDummy.Y);
                f.FlowDirection = FlowDirection.TopDown;
                f.WrapContents = false;
                f.MouseDown += tablePanel_MouseDown;
                f.MouseMove += matchView_MouseMove;

                /* Add matches related to current round iteration */
                foreach (Match match in bracket)   
                {
                    if ((int)Math.Abs(match.Round) == curRound)
                    {
                        string p1 = scheduler.GetPlayerNameFromID(match.Player1ID);
                        string p2 = scheduler.GetPlayerNameFromID(match.Player2ID);

                        MatchDisplayControl m = new MatchDisplayControl(this);
                        m.SetMatchID(match.ID);
                        m.SetPlayer1Name(p1);
                        m.SetPlayer2Name(p2);
                        m.SetSetupLabel("Pending");

                        m.GetSubmitButton().Click += submitButton_Click;

                        matchControls.Add(match.ID, m);
                        f.Controls.Add(m);
                    }
                }

                /* Add end tournament button last; shows up in winners bracket only. */
                if (bracket == winnersBracket && k == rounds - 1)
                {
                    Button b = new Button();
                    b.Name = "endTourneyButton";
                    b.Text = "End Tournament";
                    b.Font = new Font("Lucida Sans Unicode", 9.75f, FontStyle.Bold);
                    b.TextAlign = ContentAlignment.MiddleCenter;

                    b.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    b.AutoSize = true;
                    b.Margin = new Padding(0, 20, 0, 0);
                    b.FlatStyle = FlatStyle.Popup;
                    b.BackColor = Color.ForestGreen;
                    b.Click += endTourneyButton_Click;
                    b.Visible = false;
                    endTourneyButton = b;

                    f.Controls.Add(b);
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
                l.MouseDown += tablePanel_MouseDown;
                l.MouseMove += tabelLabel_MouseMove;

                panel.Controls.Add(l, k, 0);
            }
        }

        /* If oldName appears in any control, updates the name to newName */
        public void UpdatePlayerName (string oldName, string newName)
        { 
            foreach (MatchDisplayControl mdc in matchControls.Values)
            {
                if (mdc.GetPlayer1Name().Equals(oldName))
                    mdc.SetPlayer1Name(newName);
                else if (mdc.GetPlayer2Name().Equals(oldName))
                    mdc.SetPlayer2Name(newName);
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
                mdc.SetSetupNumber(m.Setup);
                mdc.SetSetupLabel(String.Format("Setup: {0}", m.Setup));
                mdc.IndicateOpenMatch();

                /* Set match name info in upcoming match list */
                string matchName = String.Format("{0} vs. {1} - Setup: {2}", p1, p2, m.Setup);
                matchCallingControl.AddItemToUpcomingMatches(matchName, m.ID);
            }

            if (scheduler.CheckIfTournamentEnded())
                endTourneyButton.Visible = true;
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
            string matchName = String.Format("{0} vs. {1} - Setup: {2}", mdc.GetPlayer1Name(),
                                              mdc.GetPlayer2Name(), mdc.GetSetupNumber());
            matchCallingControl.DeleteItemFromUpcomingMatches(matchName);
            matchCallingControl.AddItemToCurrentMatches(matchName);
        }

        #region GUI Events

        /* Save mouse position in case if user wants to drag control */
        private void tablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tableScrollPoint = e.Location;
        }

        /* When user drags mouse and left clicks, emulate dragging of horizontal scrollbar */
        private void tabelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control panel = sender as Control;

                int pos = e.X + panel.Left - tableScrollPoint.X;
                pos = (int)Math.Max(pos, -panel.Size.Width + 500);
                if (pos < 20)
                    panel.Left = pos;
            }
        }

        /* When user drags mouse and left clicks, emulate dragging of horizontal scrollbar */
        private void tabelLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control panel = ((Control)sender).Parent;
                tabelPanel_MouseMove(panel, e);
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

        /* Ends tournament */
        public async void endTourneyButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You cannot make any addtional edits " +
                                                  "once the tournament has been finalized. \n\n" +
                                                  "Are you sure you want to continue?",
                                                  "Finalize the tournament?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int statusCode = await Challonge.FinishTournament(tournamentID);
                if (statusCode < 0)
                {
                    MessageBox.Show("FATAL ERROR: COULD NOT END TOURNAMENT THROUGH AUTO",
                                    "ERROR", MessageBoxButtons.OK);
                }
                else
                {
                    endTourneyButton.Enabled = false;
                    parentForm.SetHeaderText(tournamentName + " - FINISHED");
                }
            }
        }

        /* Displays winners bracket */
        public void winnersButton_Click(object sender, EventArgs e)
        {
            if (isDoubleElim)
            {
                parentForm.SetHeaderText(tournamentName + " - Winner's Bracket");
                loserTablePanel.Visible = false;
                winnerTablePanel.Visible = true;
            }
        }

        /* Displays losers bracket */
        public void losersButton_Click(object sender, EventArgs e)
        {
            if (isDoubleElim)
            {
                parentForm.SetHeaderText(tournamentName + " - Loser's Bracket");
                winnerTablePanel.Visible = false;
                loserTablePanel.Visible = true;
            }
        }

        /* Submit score to Challonge */
        private async void submitButton_Click(object sender, EventArgs e)
        {
            bool changingWinner = false;
            MatchDisplayControl mdc = ((Button)sender).Parent as MatchDisplayControl;
            if (mdc == null)
            {
                Console.WriteLine("MatchDisplayControl that submit button is part of could not be found.");
                return;
            }

            int p1Score = mdc.GetPlayer1Score();
            int p2Score = mdc.GetPlayer2Score();
            
            if (string.IsNullOrEmpty(mdc.GetPlayer1Name()) ||
                string.IsNullOrEmpty(mdc.GetPlayer2Name()))
            {
                mdc.DisplayErrorLabel("No match to submit scores!");
                return;
            }

            int p1ID = scheduler.GetPlayerIDFromName(mdc.GetPlayer1Name());
            int p2ID = scheduler.GetPlayerIDFromName(mdc.GetPlayer2Name());

            /* Differentiate winner from loser */
            int winnerID = (p1Score > p2Score) ? p1ID : 
                           (p1Score < p2Score) ? p2ID : -1;
            int loserID = (winnerID == p1ID) ? p2ID : p1ID;

            if (winnerID == -1)
            {
                mdc.DisplayErrorLabel("Cannot have same scores!");
                return;
            }
            else if (mdc.GetWinnerID() != 0 && mdc.GetWinnerID() != winnerID)
            {
                DialogResult result = MessageBox.Show("You are changing the winner of an already " +
                                                      "reported match.\n\n Are you sure you want to " +
                                                      "continue?", "Warning: Changing Winner",
                                                      MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    mdc.DisplayErrorLabel("Report to Challonge aborted.");
                    return;
                }
                else
                    changingWinner = true;
            }

            /* Report match to Challonge */
            int matchID = mdc.GetMatchID();
            bool success = await scheduler.ReportMatch(matchID, p1Score, p2Score, winnerID);
            if (!success)
            {
                mdc.DisplayErrorLabel("Report to Challonge failed.");
                return;
            }

            /* Set MatchDisplayControl match finished attributes */
            mdc.SetWinnerID(winnerID);

            string matchName = String.Format("{0} vs. {1} - Setup: {2}", mdc.GetPlayer1Name(),
                                              mdc.GetPlayer2Name(), mdc.GetSetupNumber());
            matchCallingControl.DeleteItemFromUpcomingMatches(matchName);
            matchCallingControl.DeleteItemFromOngoingMatches(matchName);

            mdc.HideErrorLabel();
            mdc.IndicateSubmittedMatch();

            scheduler.CloseMatch(matchID);

            /* If the winner has been changed, update any open matches that may be affected
             * by this change. */
            if (changingWinner)
            {
                List<Match> updatedOpenMatches = scheduler.SwapPlayers(winnerID, loserID);
                foreach (Match m in updatedOpenMatches)
                { 
                    if (matchControls.ContainsKey(m.ID))
                    {
                        /* Delete match from calling display. */
                        MatchDisplayControl mc = matchControls[m.ID];
                        string oldMatchName = String.Format("{0} vs. {1} - Setup: {2}", mc.GetPlayer1Name(),
                                                            mc.GetPlayer2Name(), mc.GetSetupNumber());
                        matchCallingControl.DeleteItemFromUpcomingMatches(oldMatchName);

                        /* Change names on Match Display Control. */
                        mc.SetPlayer1Name(scheduler.GetPlayerNameFromID(m.Player1ID));
                        mc.SetPlayer2Name(scheduler.GetPlayerNameFromID(m.Player2ID));

                        /* Update match name in calling display. */
                        string newMatchName = String.Format("{0} vs. {1} - Setup: {2}", mc.GetPlayer1Name(),
                                                            mc.GetPlayer2Name(), mc.GetSetupNumber());
                        matchCallingControl.AddItemToUpcomingMatches(newMatchName, m.ID);
                    }
                }
            }

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
