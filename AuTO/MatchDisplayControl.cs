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
        private TournamentViewControl masterParent;

        public MatchDisplayControl(TournamentViewControl master)
        {
            InitializeComponent();

            /* Do not let user mess with player names; scheduler
             * handles it internally */
            player1Textbox.Enabled = false;
            player2Textbox.Enabled = false;
            errorLabel.Visible = false;

            submitButton.Parent = this;
            submitButton.BringToFront();

            matchID = 0;
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
            if (e.Button == MouseButtons.Right)
            {
                rightClickMenu.Show(Cursor.Position);
            }
        }

        private void reportAsOngoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            masterParent.SetMatchAsOngoing(matchID);
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
            mainPanel.BackColor = Color.Ivory;
        }

        public void IndicateOngoingMatch ()
        {
            mainPanel.BackColor = Color.DarkGoldenrod;
        }

        public void IndicateSubmittedMatch ()
        {
            mainPanel.BackColor = Color.Green;
        }

        public void IndicateLongMatch ()
        {
            mainPanel.BackColor = Color.Maroon;
        }

        public void ResetBackColor ()
        {
            mainPanel.BackColor = SystemColors.AppWorkspace;
        }

        public void SetBackColor (Color c)
        {
            mainPanel.BackColor = c;
        }

        #endregion
    }
}
