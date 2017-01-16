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

        public MainForm()
        {
            InitializeComponent();
            headerControl.SetHeader("Create a Tournament");

            tourneyName = string.Empty;
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        public void SetTournamentName (string name)
        {
            tourneyName = name;
        }

        public void SetHeaderText (string text)
        {
            headerControl.SetHeader(text);
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
    }
}
