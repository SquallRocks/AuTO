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
    public partial class MatchCallingDisplayControl : UserControl
    {
        private Point startScrollPoint;

        public MatchCallingDisplayControl()
        {
            InitializeComponent();
            startScrollPoint = new Point();
        }

        public void AddItemToUpcomingMatches (string match)
        {
            upcomingListbox.Items.Add(match);
        }

        public void AddItemToCurrentMatches(string match)
        {
            currentListbox.Items.Add(match);
        }

        public void AddItemToLongMatches(string match)
        {
            longListbox.Items.Add(match);
        }

        public void ClearUpcomingMatches ()
        {
            upcomingListbox.Items.Clear();
        }

        public void ClearCurrentMatches()
        {
            currentListbox.Items.Clear();
        }

        public void ClearLongMatches()
        {
            longListbox.Items.Clear();
        }

        #region GUI Events

        /* Save mouse position in case if user wants to drag control */
        private void listbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                startScrollPoint = e.Location;
        }

        /* When user drags mouse and left clicks, emulate dragging of vertical scrollbar */
        private void listbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListBox control = sender as ListBox;
                int pos = e.Y + control.Top - startScrollPoint.Y;
                pos = (int)Math.Min(pos, 20);
                if (pos > -control.Size.Height + 100)
                    control.Top = pos;
            }
        }

        #endregion
    }
}
