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
    public partial class EditTextControl : UserControl
    {
        public EditTextControl()
        {
            InitializeComponent();
        }

        public string GetText ()
        {
            return editTextbox.Text;
        }
    }
}
