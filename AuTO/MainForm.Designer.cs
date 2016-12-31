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
            this.createTournamentControl1 = new AuTO.CreateTournamentControl();
            this.headerControl = new AuTO.identTemp();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(154, 495);
            this.menuPanel.TabIndex = 0;
            // 
            // createTournamentControl1
            // 
            this.createTournamentControl1.Location = new System.Drawing.Point(150, 62);
            this.createTournamentControl1.Name = "createTournamentControl1";
            this.createTournamentControl1.Size = new System.Drawing.Size(756, 433);
            this.createTournamentControl1.TabIndex = 4;
            // 
            // headerControl
            // 
            this.headerControl.Location = new System.Drawing.Point(150, 0);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(756, 65);
            this.headerControl.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(906, 495);
            this.Controls.Add(this.createTournamentControl1);
            this.Controls.Add(this.headerControl);
            this.Controls.Add(this.menuPanel);
            this.Name = "mainForm";
            this.Text = "AuTO - Automatic T.O.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private identTemp headerControl;
        private CreateTournamentControl createTournamentControl1;
    }
}