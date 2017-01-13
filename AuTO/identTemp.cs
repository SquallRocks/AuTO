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
    public partial class identTemp : UserControl
    {
        public identTemp()
        {
            InitializeComponent();
            HideBracketButtons();
        }

        public void SetHeader(string header)
        {
            headerLabel.Text = header;
        }

        public void ShowBracketButtons ()
        {
            winnersButton.Visible = true;
            losersButton.Visible = true;
        }

        public void HideBracketButtons ()
        {
            winnersButton.Visible = false;
            losersButton.Visible = false;
        }

        public Button GetWinnersButton ()
        {
            return winnersButton;
        }

        public Button GetLosersButton()
        {
            return losersButton;
        }
    }
}
