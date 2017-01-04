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
        public MatchDisplayControl()
        {
            InitializeComponent();

            /* Do not let user mess with player names; scheduler
             * handles it internally */
            player1Textbox.Enabled = false;
            player2Textbox.Enabled = false;
        }

        #region Events

        /* Make sure match is not negative points */
        private void player1UpDown_ValueChanged(object sender, EventArgs e)
        {
            player1UpDown.Value = Math.Max(0, player1UpDown.Value);
        }

        /* Make sure match is not negative points */
        private void player2UpDown_ValueChanged(object sender, EventArgs e)
        {
            player2UpDown.Value = Math.Max(0, player2UpDown.Value);
        }

        #endregion

        #region Accessors and Setters

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

        #endregion
    }
}
