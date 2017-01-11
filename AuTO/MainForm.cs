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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            headerControl.SetHeader("Create a Tournament");
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        /* DEBUGGING */
        /* When X button on form is clicked, deletes tournament if one was created. */
        private async void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Control parent = this.Controls[1];
            foreach (Control c in parent.Controls)
            { 
                if (c.Name.Equals("tourneyView"))
                {
                    TournamentViewControl t = c as TournamentViewControl;
                    if (t.GetTournamentID() > 0)
                    {
                        await Challonge.DeleteTournament(t.GetTournamentID());
                    }
                }
            }
        }
    }
}
