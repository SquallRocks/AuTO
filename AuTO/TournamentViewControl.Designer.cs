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
            this.tourneyTablePanel = new System.Windows.Forms.TableLayoutPanel();
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
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.mainSplit);
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
            this.mainSplit.Panel2.Controls.Add(this.tourneyTablePanel);
            this.mainSplit.Size = new System.Drawing.Size(1084, 632);
            this.mainSplit.SplitterDistance = 237;
            this.mainSplit.TabIndex = 3;
            // 
            // tourneyTablePanel
            // 
            this.tourneyTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tourneyTablePanel.ColumnCount = 1;
            this.tourneyTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 844F));
            this.tourneyTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tourneyTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tourneyTablePanel.Location = new System.Drawing.Point(0, 0);
            this.tourneyTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.tourneyTablePanel.Name = "tourneyTablePanel";
            this.tourneyTablePanel.RowCount = 2;
            this.tourneyTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tourneyTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tourneyTablePanel.Size = new System.Drawing.Size(843, 632);
            this.tourneyTablePanel.TabIndex = 0;
            this.tourneyTablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tourneyTablePanel_MouseDown);
            this.tourneyTablePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tourneyTablePanel_MouseMove);
            // 
            // matchCallingControl
            // 
            this.matchCallingControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
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
        private System.Windows.Forms.TableLayoutPanel tourneyTablePanel;
        private System.Windows.Forms.SplitContainer mainSplit;
        private MatchCallingDisplayControl matchCallingControl;
    }
}
