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
            currentTournament.Name = name;
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

        private void mainSplit_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.ForeColor = Color.LightGoldenrodYellow;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.ForeColor = Color.Black;
        }

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
                    tourneyName = string.Empty;
                    InsertNewContentControl(new CreateTournamentControl());
                }
            }
        }

        private void tourneySettingsLabel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tourneyName))
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

        private void currentTournament_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tourneyName))
            {
                TournamentViewControl tvc = null;
                TournamentSettingsControl tsc = null;
                foreach (Control c in contentSplit.Panel2.Controls)
                {
                    if (c is TournamentViewControl)
                        tvc = c as TournamentViewControl;
                    else if (c is TournamentSettingsControl)
                        tsc = c as TournamentSettingsControl;
                }

                if (tsc != null)
                { 
                    foreach (KeyValuePair<string, string> kvp in tsc.UpdatedNames)
                    {
                        tvc.UpdatePlayerName(kvp.Key, kvp.Value);
                    }

                    tsc.UpdatedNames.Clear();
                    tsc.Visible = false;
                }

                tvc.Visible = true;
            }
        }

        public void InsertNewContentControl (Control c)
        {
            contentSplit.Panel2.Controls.Clear();
            c.Dock = DockStyle.Fill;
            contentSplit.Panel2.Controls.Add(c);
        }

    }
}
