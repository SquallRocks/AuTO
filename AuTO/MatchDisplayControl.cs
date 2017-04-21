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
    public partial class MatchDisplayControl : UserControl
    {
        private int matchID;
        private int winnerID;
        private int setup;
        private bool openOrPending;
        private TournamentViewControl masterParent;

        public MatchDisplayControl ()
        {
            InitializeComponent();
        }

        public MatchDisplayControl (TournamentViewControl master)
        {
            InitializeComponent();

            /* Do not let user mess with player names; scheduler
             * handles it internally */
            player1Textbox.ReadOnly = true;
            player2Textbox.ReadOnly = true;
            player1Textbox.ForeColor = Color.Black;
            player2Textbox.ForeColor = Color.Black;
            errorLabel.Visible = false;

            EnableOngoingMenuItem(false);
            EnableSkipMatchMenuItem(false);

            submitButton.Parent = this;
            submitButton.BringToFront();

            matchID = 0;
            winnerID = 0;
            setup = 0;
            openOrPending = true;
            masterParent = master;
        }

        #region Events

        /* Make sure match is not negative points */
        private void player1UpDown_ValueChanged(object sender, EventArgs e)
        {
            player1UpDown.Value = (int)Math.Max(0, player1UpDown.Value);
        }

        /* Make sure match is not negative points */
        private void player2UpDown_ValueChanged(object sender, EventArgs e)
        {
            player2UpDown.Value = (int)Math.Max(0, player2UpDown.Value);
        }

        private void allControls_MouseDown(object sender, MouseEventArgs e)
        {
            /* Don't show match menu if match is ongoing or completed */
            if (e.Button == MouseButtons.Right)
            {
                rightClickMenu.Show(Cursor.Position);
            }
        }

        /* Reports match as ongoing */
        private void reportAsOngoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            masterParent.SetMatchAsOngoing(matchID);
        }

        /* Skips match */
        private void skipMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            masterParent.SkipMatch(matchID);
        }

        /* Changes setup */
        private void changeSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int setupToSwapWith = SwapSetupDialog();
            masterParent.SwapSetups(matchID, setup, setupToSwapWith);
        }

        private int SwapSetupDialog ()
        {
            Form prompt = new Form();
            prompt.Width = 200;
            prompt.Height = 150;
            prompt.Text = "Setup Number to Swap To";

            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Setup:" };
            NumericUpDown inputBox = new NumericUpDown() { Left = 25, Top = 50, Width = 100 };
            Button confirmation = new Button() { Text = "Swap with: " + setup, Left = 25, Width = 100, Top = 80 };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            inputBox.Minimum = 1;
            inputBox.Maximum = masterParent.GetMaxSetups();

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();

            return (int)inputBox.Value;
        }

        #endregion

        #region Global Functions

        /* Disables or Enables "Report as Ongoing" Menu Item */
        public void EnableOngoingMenuItem (bool action)
        {
            reportAsOngoingToolStripMenuItem.Enabled = action;
        }

        /* Disables or Enables "Skip Match" Feature */
        public void EnableSkipMatchMenuItem (bool action)
        {
            skipMatchToolStripMenuItem.Enabled = action;
        }

        /* Disables or Enables "Change Setup" Feature */
        public void EnableChangeSetuphMenuItem(bool action)
        {
            changeSetupToolStripMenuItem.Enabled = action;
        }

        /* Emulate tool item click */
        public void EmulateReportAsOngoing ()
        {
            reportAsOngoingToolStripMenuItem_Click(this, new EventArgs());
        }

        /* Emulate tool item click */
        public void EmulateSkipMatch()
        {
            skipMatchToolStripMenuItem_Click(this, new EventArgs());
        }

        /* Emulate tool item click */
        public void EmulateChangeSetup()
        {
            changeSetupToolStripMenuItem_Click(this, new EventArgs());
        }

        #endregion

        #region Accessors and Setters

        public void SetMatchID (int id)
        {
            matchID = id;
        }

        public int GetMatchID ()
        {
            return matchID;
        }

        public void SetPlayer1Name (string name)
        {
            player1Textbox.Text = name;
        }

        public void SetPlayer2Name (string name)
        {
            player2Textbox.Text = name;
        }

        public void SetSetupLabel (string setup)
        {
            setupLabel.Text = setup;
        }

        public void SetSetupNumber (int s)
        {
            setup = s;
        }

        public void SetWinnerID (int id)
        {
            winnerID = id;
        }

        public int GetWinnerID ()
        {
            return winnerID;
        }

        public string GetPlayer1Name ()
        {
            return player1Textbox.Text;
        }

        public string GetPlayer2Name ()
        {
            return player2Textbox.Text;
        }

        public int GetPlayer1Score ()
        {
            return (int)player1UpDown.Value;
        }

        public int GetPlayer2Score ()
        {
            return (int)player2UpDown.Value;
        }

        public int GetSetupNumber ()
        {
            return setup;
        }

        public void DisplayErrorLabel (string msg)
        {
            errorLabel.Text = msg;
            errorLabel.Visible = true;
        }

        public void HideErrorLabel ()
        {
            errorLabel.Visible = false;
        }

        public Button GetSubmitButton ()
        {
            return submitButton;
        }

        #endregion

        #region BackColors

        public void IndicateOpenMatch ()
        {
            player1Textbox.BackColor = Color.Ivory;
            player2Textbox.BackColor = Color.Ivory;

            EnableOngoingMenuItem(true);
            EnableSkipMatchMenuItem(true);
            EnableChangeSetuphMenuItem(true);
        }

        public void IndicateOngoingMatch ()
        {
            player1Textbox.BackColor = Color.Khaki;
            player2Textbox.BackColor = Color.Khaki;

            openOrPending = false;
            EnableOngoingMenuItem(false);
            EnableSkipMatchMenuItem(true);
            EnableChangeSetuphMenuItem(true);
        }

        public void IndicateSubmittedMatch ()
        {
            player1Textbox.BackColor = Color.PaleGreen;
            player2Textbox.BackColor = Color.PaleGreen;

            openOrPending = false;
            EnableOngoingMenuItem(false);
            EnableSkipMatchMenuItem(false);
            EnableChangeSetuphMenuItem(false);
        }

        public void IndicateLongMatch ()
        {
            player1Textbox.BackColor = Color.PaleVioletRed;
            player2Textbox.BackColor = Color.PaleVioletRed;
        }

        public void IndicatePendingMatch ()
        {
            player1Textbox.BackColor = SystemColors.ControlDark;
            player2Textbox.BackColor = SystemColors.ControlDark;

            EnableOngoingMenuItem(false);
            EnableSkipMatchMenuItem(false);
            EnableChangeSetuphMenuItem(false);
        }

        public void SetBackColor (Color c)
        {
            player1Textbox.BackColor = c;
            player2Textbox.BackColor = c;
        }

        #endregion

    }
}
