namespace AuTO
{
    partial class TournamentViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.loserTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.winnerTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.syncButton = new System.Windows.Forms.Button();
            this.matchCallingControl = new AuTO.MatchCallingDisplayControl();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.mainSplit);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1086, 634);
            this.mainPanel.TabIndex = 0;
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.matchCallingControl);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.loserTablePanel);
            this.mainSplit.Panel2.Controls.Add(this.winnerTablePanel);
            this.mainSplit.Size = new System.Drawing.Size(1084, 632);
            this.mainSplit.SplitterDistance = 237;
            this.mainSplit.TabIndex = 3;
            // 
            // loserTablePanel
            // 
            this.loserTablePanel.ColumnCount = 1;
            this.loserTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.loserTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.loserTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.loserTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loserTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.loserTablePanel.Location = new System.Drawing.Point(0, 0);
            this.loserTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.loserTablePanel.Name = "loserTablePanel";
            this.loserTablePanel.RowCount = 2;
            this.loserTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.loserTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.loserTablePanel.Size = new System.Drawing.Size(843, 632);
            this.loserTablePanel.TabIndex = 1;
            // 
            // winnerTablePanel
            // 
            this.winnerTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.winnerTablePanel.ColumnCount = 1;
            this.winnerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 866F));
            this.winnerTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winnerTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.winnerTablePanel.Location = new System.Drawing.Point(0, 0);
            this.winnerTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.winnerTablePanel.Name = "winnerTablePanel";
            this.winnerTablePanel.RowCount = 2;
            this.winnerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.winnerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.winnerTablePanel.Size = new System.Drawing.Size(843, 632);
            this.winnerTablePanel.TabIndex = 0;
            this.winnerTablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tablePanel_MouseDown);
            this.winnerTablePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabelPanel_MouseMove);
            // 
            // syncButton
            // 
            this.syncButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syncButton.BackColor = System.Drawing.Color.DarkOrange;
            this.syncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syncButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncButton.Location = new System.Drawing.Point(16, 576);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(209, 41);
            this.syncButton.TabIndex = 3;
            this.syncButton.Text = "Sync w/Challonge";
            this.syncButton.UseVisualStyleBackColor = false;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // matchCallingControl
            // 
            this.matchCallingControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.matchCallingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchCallingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchCallingControl.Location = new System.Drawing.Point(0, 0);
            this.matchCallingControl.Name = "matchCallingControl";
            this.matchCallingControl.Size = new System.Drawing.Size(237, 632);
            this.matchCallingControl.TabIndex = 2;
            // 
            // TournamentViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.mainPanel);
            this.Name = "TournamentViewControl";
            this.Size = new System.Drawing.Size(1086, 634);
            this.mainPanel.ResumeLayout(false);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel winnerTablePanel;
        private System.Windows.Forms.SplitContainer mainSplit;
        private MatchCallingDisplayControl matchCallingControl;
        private System.Windows.Forms.TableLayoutPanel loserTablePanel;
        private System.Windows.Forms.Button syncButton;
    }
}
