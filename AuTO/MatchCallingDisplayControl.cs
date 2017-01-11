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
        private TournamentViewControl masterParent;
        private Point startScrollPoint;

        private Dictionary<string, int> matchIDs;

        public MatchCallingDisplayControl()
        {
            InitializeComponent();
            startScrollPoint = new Point();
            masterParent = null;
            matchIDs = new Dictionary<string, int>();
        }

        public void SetMasterParent (TournamentViewControl t)
        {
            masterParent = t;
        }

        public void AddItemToUpcomingMatches (string match, int id)
        {
            upcomingListbox.Items.Add(match);
            matchIDs.Add(match, id);
        }

        public void AddItemToCurrentMatches(string match)
        {
            currentListbox.Items.Add(match);
        }

        public void AddItemToLongMatches(string match)
        {
            longListbox.Items.Add(match);
        }

        public bool DeleteItemFromUpcomingMatches (string name)
        {
            if (upcomingListbox.Items.Contains(name))
            {
                upcomingListbox.Items.Remove(name);
                matchIDs.Remove(name);
                return true;
            }

            return false;
        }

        public bool DeleteItemFromOngoingMatches(string name)
        {
            if (currentListbox.Items.Contains(name))
            {
                currentListbox.Items.Remove(name);
                return true;
            }

            return false;
        }

        public bool DeleteItemFromLongMatches(string name)
        {
            if (longListbox.Items.Contains(name))
            {
                longListbox.Items.Remove(name);
                return true;
            }

            return false;
        }

        public void ClearUpcomingMatches ()
        {
            upcomingListbox.Items.Clear();
            matchIDs.Clear();
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

            else if (e.Button == MouseButtons.Right)
            {
                if (upcomingListbox.SelectedItem != null)
                {
                    rightClickMenu.Show(Cursor.Position);
                }
            }
        }

        private void reportMatchAsOngoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (masterParent != null)
            {
                if (matchIDs.ContainsKey(upcomingListbox.SelectedItem.ToString()))
                {
                    int matchID = matchIDs[upcomingListbox.SelectedItem.ToString()];
                    masterParent.SetMatchAsOngoing(matchID);
                }
            }
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
