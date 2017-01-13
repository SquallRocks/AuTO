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
        private bool openOrPending;
        private TournamentViewControl masterParent;

        public MatchDisplayControl(TournamentViewControl master)
        {
            InitializeComponent();

            /* Do not let user mess with player names; scheduler
             * handles it internally */
            player1Textbox.ReadOnly = true;
            player2Textbox.ReadOnly = true;
            player1Textbox.ForeColor = Color.Black;
            player2Textbox.ForeColor = Color.Black;
            errorLabel.Visible = false;

            submitButton.Parent = this;
            submitButton.BringToFront();

            matchID = 0;
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
            if (e.Button == MouseButtons.Right && openOrPending)
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
            player1Textbox.BackColor = Color.Ivory;
            player2Textbox.BackColor = Color.Ivory;
        }

        public void IndicateOngoingMatch ()
        {
            player1Textbox.BackColor = Color.Khaki;
            player2Textbox.BackColor = Color.Khaki;

            openOrPending = false;
        }

        public void IndicateSubmittedMatch ()
        {
            player1Textbox.BackColor = Color.PaleGreen;
            player2Textbox.BackColor = Color.PaleGreen;

            openOrPending = false;
        }

        public void IndicateLongMatch ()
        {
            player1Textbox.BackColor = Color.PaleVioletRed;
            player2Textbox.BackColor = Color.PaleVioletRed;
        }

        public void ResetTextboxBackColor ()
        {
            player1Textbox.BackColor = SystemColors.AppWorkspace;
            player2Textbox.BackColor = SystemColors.AppWorkspace;
        }

        public void SetBackColor (Color c)
        {
            player1Textbox.BackColor = c;
            player2Textbox.BackColor = c;
        }

        #endregion
    }
}
