using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AuTO
{
    public partial class TournamentSettingsControl : UserControl
    {
        private int tournamentID;
        private Dictionary<int, string> players;

        public Dictionary<string, string> UpdatedNames;

        public TournamentSettingsControl (int t_id, Dictionary<int, string> p_ids)
        {
            InitializeComponent();
            errorLabel.Visible = false;
            successLabel.Visible = false;

            tournamentID = t_id;
            players = p_ids;

            UpdatedNames = new Dictionary<string, string>();

            foreach (string p in players.Values)
                playerListbox.Items.Add(p);
        }

        private async void nameButton_Click(object sender, EventArgs e)
        {
            if (playerListbox.SelectedItem != null && !string.IsNullOrEmpty(nameTextbox.Text))
            {
                string player = playerListbox.SelectedItem.ToString();
                string newName = nameTextbox.Text;

                /* Make sure new name isn't already in use. */
                if (players.Values.Contains(newName))
                {
                    errorLabel.Text = String.Format("Player {0} already exists!", player);
                    errorLabel.Visible = true;
                    successLabel.Visible = false;
                    return;
                }

                int id = players.First(x => x.Value.Equals(player)).Key;

                int validated = await Challonge.EditPlayerName(tournamentID, id, player);
                if (validated < 0)
                {
                    errorLabel.Text = "Unable to change name!";
                    errorLabel.Visible = true;
                    successLabel.Visible = false;
                    return;
                }

                /* Replace name in listbox */
                int k = 0;
                for (; k < playerListbox.Items.Count; k++)
                {
                    if (playerListbox.Items[k].ToString().Equals(player))
                        break;
                }
                playerListbox.Items[k] = newName;

                /* Replace name in player list */
                int key = players.First(x => x.Value.Equals(player)).Key;
                players[key] = newName;

                UpdatedNames.Add(player, newName);

                successLabel.Visible = true;
            }
        }

        /* Deletes tournament, Tournament View Control, Tournamnet Settings Control,
         * and installs a Create Tournament Control. */
        private async void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show ("Are you sure you want to delete all " + 
                                                   "traces of this tournament?", 
                                                   "Delete Tournament", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await Challonge.DeleteTournament(tournamentID);

                MainForm main = this.FindForm() as MainForm;
                main.ClearTournamentAttributes();
                main.InsertNewContentControl(new CreateTournamentControl());

            }
        }
    }
}
