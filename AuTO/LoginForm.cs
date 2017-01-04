using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace AuTO
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        // Authenticate username and api key
        private async void loginButton_Click(object sender, EventArgs e)
        {
            string user = usernameTextbox.Text;
            string api_key = keyTextbox.Text;

            // If there is no username or api key given, complain
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(api_key))
            {
                invalidLabel.Visible = true;
                testLabel.Visible = false;
                return;
            }

            // Validate credentials
            bool validated = await Challonge.AuthenticateLogin(user, api_key);
            if (!validated) 
            {
                invalidLabel.Visible = true;
                testLabel.Visible = false;
                return;
            }

            invalidLabel.Visible = false;
            testLabel.Visible = true;

            Form mainForm = new mainForm();
            this.Visible = false;
            mainForm.Visible = true;

            this.Hide();
        }
    }
}
