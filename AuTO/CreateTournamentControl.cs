using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AuTO
{
    public partial class CreateTournamentControl : UserControl
    {
        private int tournamentID;
        private Dictionary<int, string> playerIDs;
        private int setups;

        public CreateTournamentControl()
        {
            InitializeComponent();
            tournamentID = 0;
            playerIDs = new Dictionary<int, string>();
        }

        #region Helper Backend Functions

        /* Checks if tournament name, subdomain, url are valid and if 
         * there is at least two participants */
        public bool InitialErrorCheck()
        {
            if (string.IsNullOrWhiteSpace(nameTextbox.Text))
            {
                errorLabel.Text = "Tournament name cannot be empty.";
                errorLabel.Visible = true;
                return false;
            }
            else if (!singleRD.Checked && !doubleRD.Checked)
            {
                errorLabel.Text = "Must indicate type of tournament.";
                errorLabel.Visible = true;
                return false;
            }
            else if (string.IsNullOrWhiteSpace(urlTextbox.Text))
            {
                errorLabel.Text = "URL cannot be empty.";
                errorLabel.Visible = true;
                return false;
            }
            else if (playerListbox.Items.Count < 2)
            {
                errorLabel.Text = "Must have at least two participants.";
                errorLabel.Visible = true;
                return false;           
            }

            return true;
        }

        /* Swaps the seed numbers of two players */
        private void SwapSeeds(ref string a, ref string b)
        {
            string[] aSeed = a.Split('.');
            string[] bSeed = b.Split('.');
            string aNum = aSeed[0];
            string bNum = bSeed[0];

            aSeed[0] = bNum;
            bSeed[0] = aNum;

            a = string.Join(".", aSeed);
            b = string.Join(".", bSeed);
        }

        /* Displays error label with appropriate message */
        private void DisplayClientError(string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg))
                errorLabel.Text = msg;
            else
                errorLabel.Text = "Client side error; could not start tournament.";

            errorLabel.Visible = true;
            successLabel.Visible = false;
        }

        /* Displays success label for inidicated number of seconds */
        private void DisplayClientSuccess(string msg, int seconds)
        {
            successLabel.Text = msg;
            errorLabel.Visible = false;
            successLabel.Visible = true;

            Timer t = new Timer();
            t.Interval = seconds * 1000;
            t.Tick += new EventHandler(successLabel_OnTimerEvent);
            t.Enabled = true;
        }

        private void Clear()
        {
            nameTextbox.Clear();
            singleRD.Checked = false;
            doubleRD.Checked = false;
            subTextbox.Clear();
            urlTextbox.Clear();
            setupUpDown.Value = 1;
            playerTextbox.Clear();
            playerListbox.Items.Clear();
        }

        #endregion

        #region Events

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            //string player = playerTextbox.Text;

            string[] manyPlayers = playerTextbox.Lines;
            int seed = playerListbox.Items.Count + 1;
   
            if (string.IsNullOrWhiteSpace(manyPlayers.ToString()))
            {
                errorLabel.Text = "Please input a valid name.";
                errorLabel.Visible = true;
                return;
            }

            foreach (string line in manyPlayers)
            {
                string player = line;
                /* Make sure player has not already been added */
                foreach (string s in playerListbox.Items)
                {
                    /* Get player name without seed number */
                    string[] components = s.Split('.');
                    string p = string.Join(".", components, 1, components.Length - 1);

                    /* Remember, there is a space after the seed number; disregard it */
                    p = p.Substring(1).ToLower();

                    if (p.Equals(player.ToLower()))
                    {
                        errorLabel.Text = string.Format("{0} has already been added. Challonge is not case sensitive.",
                                                        playerTextbox.Text);
                        errorLabel.Visible = true;
                        return;
                    }
                }
                /* At this point, player entry is valid; add it */
                player = string.Format("{0}. {1}", seed, player);
                playerListbox.Items.Add(player);
                seed = playerListbox.Items.Count + 1;

            }
            
            playerTextbox.Clear();
            errorLabel.Visible = false;
        }

        /* When user presses enter button when adding players, adds a player */
        private void playerTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                addPlayerButton_Click(addPlayerButton, new EventArgs());

                /* Disables adding a new line once names submitted since 
                 * Enter key was pressed */
                if (e.KeyCode == Keys.Enter)
                    e.SuppressKeyPress = true;
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;

            /* Not enough info to start tournament; abort */
            if (!InitialErrorCheck())
            {
                startButton.Enabled = true;
                return;
            }

            /* Set up tournament attributes */
            Tournament t = new Tournament();
            t.Name = nameTextbox.Text;
            t.Subdomain = subTextbox.Text;
            t.URL = urlTextbox.Text;

            if (singleRD.Checked)
                t.Type = "single elimination";
            else
                t.Type = "double elimination";

            setups = (int)setupUpDown.Value;
            bool isDoubleElim = t.Type.Equals("double elimination");

            string[] players = new string[playerListbox.Items.Count];
            for (int k = 0; k < players.Length; k++)
            {
                /* Get rid of the"#. " at the beginning of the player's name */
                string player = playerListbox.Items[k].ToString();
                string[] components = player.Split('.');
                components[1] = components[1].Substring(1);

                players[k] = string.Join(".", components, 1, components.Length - 1 );
            }

            /* For tournament creation and adding players, validated also returns
             * the specified tournamnet or player ID */
            int validated = await Challonge.CreateTournament(t);
            if (validated < 0)
            {
                if (validated == -100)
                    DisplayClientError("Tournament with URL already exists!");
                else if (validated == -200)
                    DisplayClientError("Unhandled error on client side.");

                startButton.Enabled = true;
                return;
            }
            else
                tournamentID = validated;

            /* DEBUGGING */
            //Console.WriteLine("TOURNAMENT ID: {0}", tournamentID);

            /* Make sure tournament is retrievable */
            validated = await Challonge.GetTournament(tournamentID);
            if (validated < 0)
            {
                DisplayClientError("Tournament not found! Client side error.");
                startButton.Enabled = true;
                return;
            }

            /* Add players to the tourney */
            Participant p = new Participant();
            for (int k = 0; k < players.Length; k++)
            {
                p.Name = players[k];
                p.Seed = k + 1;

                validated = await Challonge.AddPlayer(tournamentID, p);

                if (validated < 0)
                {
                    await Challonge.DeleteTournament(tournamentID);
                    DisplayClientError(String.Format("Could not add player {0}; client side error.", p.Name));
                    startButton.Enabled = true;
                    return;
                }
                else
                {
                    playerIDs.Add(validated, p.Name);
                    DisplayClientSuccess(String.Format("Successfuilly added {0} to {1}",
                                         p.Name, t.Name), 3);
                }
            }

            /*DEBUGGING */
            //foreach (int x in playerIDs.Values)
            //    Console.WriteLine("PlayerIDs: {0}", x);

            /* Make sure user is ready to start tournament */
            DialogResult okToStart = MessageBox.Show("Please make final changes to the tournament " + 
                                                     "seeding on the official Challonge website.\n\n" +
                                                     "Once you are satisfied with the bracket, " + 
                                                     "press OK.\n\nIf you would like to delete the " +
                                                     "tournament and start over, press Cancel.", 
                                                     "Start Tournament", MessageBoxButtons.OKCancel);
            /* User not ready; abort tournament creation */
            if (okToStart == DialogResult.Cancel)
            {
                await Challonge.DeleteTournament(tournamentID);
                tournamentID = 0;
                playerIDs.Clear();
                setups = 0;

                DisplayClientError("Tournament creation aborted.");
                startButton.Enabled = true;
                return;
            }
            else if (okToStart == DialogResult.OK)
            { 
                /* Start Tournament */
                validated = await Challonge.StartTournament(tournamentID);
                if (validated < 0)
                {
                    await Challonge.DeleteTournament(tournamentID);
                    DisplayClientError("Could not start; client side error.");
                    startButton.Enabled = true;
                    return;
                }
                else
                {
                    Dictionary<int, Match> matches = await Challonge.RetrieveMatches(tournamentID);
                    if (matches == null)
                    {
                        DisplayClientError("Client side error retrieving matches");
                        startButton.Enabled = true;
                        return;
                    }

                    DisplayClientSuccess("Tournament successfully started!", 10);

                    MainForm main = this.ParentForm as MainForm;
                    TournamentViewControl tourneyView = new TournamentViewControl(tournamentID, t.Name, playerIDs,
                                                                                  matches, setups, isDoubleElim);
                    tourneyView.SetBracketButtons(main);
                    tourneyView.Name = "tourneyView";
                    tourneyView.Dock = DockStyle.Fill;
                    tourneyView.Visible = true;
                    tourneyView.BringToFront();

                    this.Parent.Controls.Add(tourneyView);
                    main.SetPlayers(playerIDs);

                    this.Hide();
                    this.Dispose();
                }
            }
        }

        /* If user presses shift + up/down, shift the selected index up or down,
         * effectively changing the seeding. */
        private void playerListbox_KeyDown(object sender, KeyEventArgs e)
        {
            /* Only shift seeds if there's at least two entrants */
            if (playerListbox.Items.Count > 1)
            { 
                int index = 0;
                string seedToMove = playerListbox.Items[playerListbox.SelectedIndex].ToString();
                string origSeed = string.Empty;

                /* Moves higher in seed list; lower in index */
                if (e.Shift && e.KeyCode == Keys.Up)
                {
                    /* If player is already seed one, do nothing */
                    if (playerListbox.SelectedIndex == 0)
                        return;

                    /* Determine indexes and players to move */
                    index = playerListbox.SelectedIndex - 1;
                    origSeed = playerListbox.Items[index].ToString();

                    /* Swap seed numbers */
                    SwapSeeds(ref origSeed, ref seedToMove);

                    /* Move players */
                    playerListbox.Items[index] = seedToMove;
                    playerListbox.Items[index + 1] = origSeed;
                }
                /* Moves lower is seed list; higher in index */
                else if (e.Shift && e.KeyCode == Keys.Down)
                { 
                    /* If player is last seed, do nothing */
                    if (playerListbox.SelectedIndex == playerListbox.Items.Count - 1)
                        return;

                    /* Determine indexes and players to move */
                    index = playerListbox.SelectedIndex + 1;
                    origSeed = playerListbox.Items[index].ToString();

                    /* Swap seed numbers */
                    SwapSeeds(ref origSeed, ref seedToMove);

                    /* Move players */
                    playerListbox.Items[index] = seedToMove;
                    playerListbox.Items[index - 1] = origSeed;
                }
            }
        }

        private void playerListbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (playerListbox.SelectedItem != null)
                    listboxMenu.Show(Cursor.Position);
            }
        }

        /* Deletes player from listbox and from Challonge */
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Retrieve player's name w/o seeding */
            int index = playerListbox.SelectedIndex;
            string playerToDelete = playerListbox.SelectedItem.ToString();

            /* Move all player below player to delete up a seed */
            for (; index < playerListbox.Items.Count - 1; index++)
            {
                string newPlayer = playerListbox.Items[index + 1].ToString();
                SwapSeeds(ref playerToDelete, ref newPlayer);

                playerListbox.Items[index] = newPlayer;
                playerListbox.Items[index + 1] = playerToDelete;
            }

            playerListbox.Items.RemoveAt(index);
        }

        private void successLabel_OnTimerEvent(object sender, EventArgs e)
        {
            successLabel.Visible = false;
        }

        /* Clear all information from wizard to start fresh*/
        private void clearButton_Click(object sender, EventArgs e)
        {
            if (tournamentID == 0)
                Clear();
            else
                DisplayClientError("Tournament already started; cannot clear.");
        }

        /* If tournament created in challonge, delete it, clear all fields, and
         * go to home screen */
        private async void cancelButton_Click(object sender, EventArgs e)
        {
            if (tournamentID != 0)
            {
                await Challonge.DeleteTournament(tournamentID);
            }

            Clear();
        }

        #endregion
    }
}
