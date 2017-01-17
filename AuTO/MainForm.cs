using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuTO
{
    public partial class MainForm : Form
    {
        private string tourneyName;
        private int tournamentID;
        private Dictionary<int, string> players;

        public MainForm()
        {
            InitializeComponent();
            headerControl.SetHeader("Create a Tournament");
            currentTournament.Visible = false;

            tourneyName = string.Empty;
            tournamentID = 0;
            players = null;
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        public void SetTournamentName (string name)
        {
            tourneyName = name;
            currentTournament.Text = name;
            currentTournament.Visible = true;
        }

        public void SetHeaderText (string text)
        {
            headerControl.SetHeader(text);
        }

        public void SetPlayers (Dictionary<int, string> p_ids)
        {
            players = p_ids;
        }

        public void SetTournamentID (int id)
        {
            tournamentID = id;
        }

        public Button GetWinnersButton ()
        {
           return headerControl.GetWinnersButton();
        }

        public Button GetLosersButton ()
        {
            return headerControl.GetLosersButton();
        }

        public void HideBracketButtons ()
        {
            headerControl.HideBracketButtons();
        }

        public void ShowBracketButtons ()
        {
            headerControl.ShowBracketButtons();
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            if (tournamentID != 0)
            { 
                Control c = sender as Control;
                c.ForeColor = Color.LightGoldenrodYellow;
            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            if (tournamentID != 0)
            {
                Control c = sender as Control;
                c.ForeColor = Color.Black;
            }
        }

        /* Discard current tournament and make a new one.
         * NOTE: Does not delete tourney from Challonge! */
        private void newTourneyLabel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tourneyName))
            { 
                DialogResult result = MessageBox.Show("Creating a new tournament scraps the " + 
                                                      "current tournment from AuTO. \n\nAre you " +
                                                      "sure you want to continue?", 
                                                      "Warning: Current will be discarded",
                                                      MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ClearTournamentAttributes();
                    InsertNewContentControl(new CreateTournamentControl());
                }
            }
        }

        /* Switch to the tournament settings panel if there is a running tournament. */ 
        private void tourneySettingsLabel_Click(object sender, EventArgs e)
        {
            if (tournamentID != 0)
            { 
                foreach (Control c in contentSplit.Panel2.Controls)
                {
                    if (c is TournamentViewControl)
                    {
                        c.Visible = false;
                    }
                }

                contentSplit.Panel2.Controls.Add(new TournamentSettingsControl(tournamentID, players));
            }
        }

        /* Switches between Tournament View Control and Tournament Settings Contrtol */
        private void currentTournament_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tourneyName))
            {
                TournamentViewControl tvc = null;
                TournamentSettingsControl tsc = null;

                /* First find respective controls */
                foreach (Control c in contentSplit.Panel2.Controls)
                {
                    if (c is TournamentViewControl)
                        tvc = c as TournamentViewControl;
                    else if (c is TournamentSettingsControl)
                        tsc = c as TournamentSettingsControl;
                }

                /* If the user updated any names while in settings panel, update them in the
                 * view control. */
                if (tsc != null && tvc != null)
                { 
                    foreach (KeyValuePair<string, string> kvp in tsc.UpdatedNames)
                    {
                        tvc.UpdatePlayerName(kvp.Key, kvp.Value);
                    }

                    tsc.UpdatedNames.Clear();
                    tsc.Visible = false;
                    tvc.Visible = true;
                }
            }
        }

        /* Remove all controls in main content panel and add one new control c. */
        public void InsertNewContentControl (Control c)
        {
            contentSplit.Panel2.Controls.Clear();
            contentSplit.Panel2.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }

        /* Clears current tournament fields to make room for new one. */
        public void ClearTournamentAttributes ()
        {
            tourneyName = string.Empty;
            tournamentID = 0;
            currentTournament.Visible = false;
        }
    }
}
