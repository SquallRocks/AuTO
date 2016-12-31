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
        }

        public void SetHeader(string header)
        {
            headerLabel.Text = header;
        }
    }
}
