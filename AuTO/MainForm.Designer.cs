namespace AuTO
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.Panel();
            this.headerControl = new AuTO.identTemp();
            this.createTournamentControl2 = new AuTO.CreateTournamentControl();
            this.createTournamentControl1 = new AuTO.CreateTournamentControl();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.createTournamentControl2);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1166, 619);
            this.menuPanel.TabIndex = 0;
            // 
            // headerControl
            // 
            this.headerControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerControl.Location = new System.Drawing.Point(150, 0);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(1016, 65);
            this.headerControl.TabIndex = 3;
            // 
            // createTournamentControl2
            // 
            this.createTournamentControl2.Location = new System.Drawing.Point(149, 61);
            this.createTournamentControl2.Name = "createTournamentControl2";
            this.createTournamentControl2.Size = new System.Drawing.Size(1016, 557);
            this.createTournamentControl2.TabIndex = 6;
            // 
            // createTournamentControl1
            // 
            this.createTournamentControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createTournamentControl1.Location = new System.Drawing.Point(150, 124);
            this.createTournamentControl1.Name = "createTournamentControl1";
            this.createTournamentControl1.Size = new System.Drawing.Size(1016, 433);
            this.createTournamentControl1.TabIndex = 4;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1166, 619);
            this.Controls.Add(this.headerControl);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.createTournamentControl1);
            this.Name = "mainForm";
            this.Text = "AuTO - Automatic T.O.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private CreateTournamentControl createTournamentControl1;
        private identTemp headerControl;
        private CreateTournamentControl createTournamentControl2;
    }
}