namespace AuTO
{
    partial class MainForm
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
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.menuTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.currentTournament = new System.Windows.Forms.Label();
            this.tourneySettingsLabel = new System.Windows.Forms.Label();
            this.newTourneyLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contentSplit = new System.Windows.Forms.SplitContainer();
            this.headerControl = new AuTO.identTemp();
            this.createTournamentControl = new AuTO.CreateTournamentControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.menuTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentSplit)).BeginInit();
            this.contentSplit.Panel1.SuspendLayout();
            this.contentSplit.Panel2.SuspendLayout();
            this.contentSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.IsSplitterFixed = true;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.menuTablePanel);
            this.mainSplit.Panel1.Controls.Add(this.logoLabel);
            this.mainSplit.Panel1.Controls.Add(this.label1);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.contentSplit);
            this.mainSplit.Size = new System.Drawing.Size(1166, 619);
            this.mainSplit.SplitterDistance = 190;
            this.mainSplit.TabIndex = 1;
            // 
            // menuTablePanel
            // 
            this.menuTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuTablePanel.ColumnCount = 1;
            this.menuTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTablePanel.Controls.Add(this.currentTournament, 0, 2);
            this.menuTablePanel.Controls.Add(this.tourneySettingsLabel, 0, 1);
            this.menuTablePanel.Controls.Add(this.newTourneyLabel, 0, 0);
            this.menuTablePanel.Location = new System.Drawing.Point(3, 87);
            this.menuTablePanel.Name = "menuTablePanel";
            this.menuTablePanel.RowCount = 3;
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuTablePanel.Size = new System.Drawing.Size(185, 173);
            this.menuTablePanel.TabIndex = 7;
            // 
            // currentTournament
            // 
            this.currentTournament.AutoSize = true;
            this.currentTournament.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTournament.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTournament.Location = new System.Drawing.Point(3, 114);
            this.currentTournament.Name = "currentTournament";
            this.currentTournament.Size = new System.Drawing.Size(179, 59);
            this.currentTournament.TabIndex = 2;
            this.currentTournament.Text = "Current Tournament";
            this.currentTournament.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentTournament.Click += new System.EventHandler(this.currentTournament_Click);
            this.currentTournament.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.currentTournament.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // tourneySettingsLabel
            // 
            this.tourneySettingsLabel.AutoSize = true;
            this.tourneySettingsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tourneySettingsLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tourneySettingsLabel.Location = new System.Drawing.Point(3, 57);
            this.tourneySettingsLabel.Name = "tourneySettingsLabel";
            this.tourneySettingsLabel.Size = new System.Drawing.Size(179, 57);
            this.tourneySettingsLabel.TabIndex = 1;
            this.tourneySettingsLabel.Text = "Tournament Settings";
            this.tourneySettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tourneySettingsLabel.Click += new System.EventHandler(this.tourneySettingsLabel_Click);
            this.tourneySettingsLabel.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.tourneySettingsLabel.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // newTourneyLabel
            // 
            this.newTourneyLabel.AutoSize = true;
            this.newTourneyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newTourneyLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTourneyLabel.Location = new System.Drawing.Point(3, 0);
            this.newTourneyLabel.Name = "newTourneyLabel";
            this.newTourneyLabel.Size = new System.Drawing.Size(179, 57);
            this.newTourneyLabel.TabIndex = 0;
            this.newTourneyLabel.Text = "New Tournament";
            this.newTourneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newTourneyLabel.Click += new System.EventHandler(this.newTourneyLabel_Click);
            this.newTourneyLabel.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.newTourneyLabel.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // logoLabel
            // 
            this.logoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoLabel.Location = new System.Drawing.Point(25, 4);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(146, 54);
            this.logoLabel.TabIndex = 5;
            this.logoLabel.Text = "AuTO";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Automatic T.O.";
            // 
            // contentSplit
            // 
            this.contentSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentSplit.Location = new System.Drawing.Point(0, 0);
            this.contentSplit.Name = "contentSplit";
            this.contentSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // contentSplit.Panel1
            // 
            this.contentSplit.Panel1.Controls.Add(this.headerControl);
            // 
            // contentSplit.Panel2
            // 
            this.contentSplit.Panel2.Controls.Add(this.createTournamentControl);
            this.contentSplit.Size = new System.Drawing.Size(972, 619);
            this.contentSplit.SplitterDistance = 83;
            this.contentSplit.TabIndex = 0;
            // 
            // headerControl
            // 
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerControl.Location = new System.Drawing.Point(0, 0);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(972, 83);
            this.headerControl.TabIndex = 7;
            // 
            // createTournamentControl
            // 
            this.createTournamentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createTournamentControl.Location = new System.Drawing.Point(0, 0);
            this.createTournamentControl.Name = "createTournamentControl";
            this.createTournamentControl.Size = new System.Drawing.Size(972, 532);
            this.createTournamentControl.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1166, 619);
            this.Controls.Add(this.mainSplit);
            this.Name = "MainForm";
            this.Text = "AuTO - Automatic T.O.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel1.PerformLayout();
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.menuTablePanel.ResumeLayout(false);
            this.menuTablePanel.PerformLayout();
            this.contentSplit.Panel1.ResumeLayout(false);
            this.contentSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contentSplit)).EndInit();
            this.contentSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.SplitContainer contentSplit;
        private identTemp headerControl;
        private CreateTournamentControl createTournamentControl;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel menuTablePanel;
        private System.Windows.Forms.Label tourneySettingsLabel;
        private System.Windows.Forms.Label newTourneyLabel;
        private System.Windows.Forms.Label currentTournament;
    }
}