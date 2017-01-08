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
    public partial class TournamentViewControl : UserControl
    {
        private Point tableScrollPoint;
        private Dictionary<int, Match> matches;
        private int setups;

        /* For testing */
        public TournamentViewControl()
        {
            InitializeComponent();
            tableScrollPoint = new Point();
        }

        public TournamentViewControl(Dictionary<int, Match> matches, int setups)
        {
            InitializeComponent();

            tableScrollPoint = new Point();
            this.matches = matches;
            this.setups = setups;
        }

        public void SetupTournamentView (int rounds)
        {
            /* Set number of columns needed at their size */
            tourneyTablePanel.Dock = DockStyle.None;
            tourneyTablePanel.ColumnCount = rounds;
            tourneyTablePanel.Size = new Size(rounds * 200, 110 * rounds);  

            /* Set column and row height/width */
            TableLayoutStyleCollection styles = tourneyTablePanel.ColumnStyles;
            foreach (ColumnStyle c in styles)
                c.Width = 200;

            /* Add matches */
            for (int k = 0; k < rounds; k++)
            {
                Panel p = new Panel();
                tourneyTablePanel.Controls.Add(p, k, 1);
                p.Dock = DockStyle.Fill;

                FlowLayoutPanel f = new FlowLayoutPanel();
                f.Name = "FlowLayout Round " + (rounds - k);
                f.Margin = new Padding(0, 0, 0, 0);
                f.AutoSize = false;
                f.AutoScroll = true;
                f.Size = new Size(f.Size.Width, rounds * 110);
                f.FlowDirection = FlowDirection.TopDown;
                f.WrapContents = false;
                f.MouseDown += tourneyTablePanel_MouseDown;
                f.MouseMove += matchView_MouseMove;

                for (int j = 0; j < rounds; j++)        // would be number of matches in that round
                { 
                    MatchDisplayControl m = new MatchDisplayControl();
                    m.Name = "Round " + k + " match " + j;
                    m.SetPlayer1Name("Player 1");
                    m.SetPlayer2Name("Player 2");

                    f.Controls.Add(m);
                }

                p.Controls.Add(f);

                //tourneyTablePanel.Controls.Add(f, k, 1);
            }

            /* Add Round headers to each column */
            for (int k = 0; k < rounds; k++)
            {
                Label l = new Label();
                l.Name = "Round " + (rounds - k);
                l.Text = l.Name;
                l.Font = new Font("Lucida Sans Unicode", 9.75f, FontStyle.Bold);
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Margin = new Padding(0, 0, 0, 0);
                l.Dock = DockStyle.Fill;
                l.MouseDown += tourneyTablePanel_MouseDown;
                l.MouseMove += tourneyTablePanel_MouseMove;

                tourneyTablePanel.Controls.Add(l, k, 0);
            }
        }

        /* Save mouse position in case if user wants to drag control */
        private void tourneyTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tableScrollPoint = e.Location;
        }

        /* When user drags mouse and left clicks, emulate dragging of horizontal scrollbar */
        private void tourneyTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int pos = e.X + tourneyTablePanel.Left - tableScrollPoint.X;
                pos = (int)Math.Max(pos, -tourneyTablePanel.Size.Width + 500);
                if (pos < 20)
                    tourneyTablePanel.Left = pos;
            }
        }

        /* When user drags mouse and left clicks, emulate dragging of horizontal scrollbar */
        private void matchView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FlowLayoutPanel control = sender as FlowLayoutPanel;
                int pos = e.Y + control.Top - tableScrollPoint.Y;
                pos = (int)Math.Min(pos, 20);
                if (pos > -control.Size.Height + 500)
                control.Top = pos;
            }
        }    

        /* FOR DEBUGGING PURPOSES
         * Find what control was clicked.
         * Usage: control.MouseDown += HandleClicks
         */
        private void HandleClicks(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            MessageBox.Show(string.Format("{0} was clicked!", control.Name));
        }
    }
}
