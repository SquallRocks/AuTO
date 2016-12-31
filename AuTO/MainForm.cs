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
        /* Persistent data trhough forms */
        public Tournament tourney;

        public mainForm()
        {
            InitializeComponent();
            headerControl.SetHeader("Create a Tournament");
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Close();
        }
    }
}
