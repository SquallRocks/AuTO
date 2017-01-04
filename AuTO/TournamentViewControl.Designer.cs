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
            this.matchesPanel = new System.Windows.Forms.Panel();
            this.tourneyTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.longListview = new System.Windows.Forms.ListView();
            this.ongoingListview = new System.Windows.Forms.ListView();
            this.longLabel = new System.Windows.Forms.Label();
            this.ongoingLabel = new System.Windows.Forms.Label();
            this.upcomingLabel = new System.Windows.Forms.Label();
            this.upcomingListview = new System.Windows.Forms.ListView();
            this.mainPanel.SuspendLayout();
            this.matchesPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.matchesPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(756, 435);
            this.mainPanel.TabIndex = 0;
            // 
            // matchesPanel
            // 
            this.matchesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchesPanel.Controls.Add(this.tourneyTablePanel);
            this.matchesPanel.Location = new System.Drawing.Point(0, -2);
            this.matchesPanel.Name = "matchesPanel";
            this.matchesPanel.Size = new System.Drawing.Size(756, 333);
            this.matchesPanel.TabIndex = 1;
            // 
            // tourneyTablePanel
            // 
            this.tourneyTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tourneyTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tourneyTablePanel.ColumnCount = 1;
            this.tourneyTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 758F));
            this.tourneyTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tourneyTablePanel.Location = new System.Drawing.Point(0, 0);
            this.tourneyTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.tourneyTablePanel.Name = "tourneyTablePanel";
            this.tourneyTablePanel.RowCount = 2;
            this.tourneyTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tourneyTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tourneyTablePanel.Size = new System.Drawing.Size(756, 333);
            this.tourneyTablePanel.TabIndex = 0;
            this.tourneyTablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tourneyTablePanel_MouseDown);
            this.tourneyTablePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tourneyTablePanel_MouseMove);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.Controls.Add(this.tablePanel);
            this.bottomPanel.Location = new System.Drawing.Point(-1, 314);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(756, 119);
            this.bottomPanel.TabIndex = 0;
            // 
            // tablePanel
            // 
            this.tablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tablePanel.ColumnCount = 3;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePanel.Controls.Add(this.longListview, 2, 1);
            this.tablePanel.Controls.Add(this.ongoingListview, 1, 1);
            this.tablePanel.Controls.Add(this.longLabel, 2, 0);
            this.tablePanel.Controls.Add(this.ongoingLabel, 1, 0);
            this.tablePanel.Controls.Add(this.upcomingLabel, 0, 0);
            this.tablePanel.Controls.Add(this.upcomingListview, 0, 1);
            this.tablePanel.Location = new System.Drawing.Point(0, 20);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 2;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tablePanel.Size = new System.Drawing.Size(756, 99);
            this.tablePanel.TabIndex = 0;
            // 
            // longListview
            // 
            this.longListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longListview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.longListview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.longListview.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longListview.GridLines = true;
            this.longListview.Location = new System.Drawing.Point(503, 22);
            this.longListview.Margin = new System.Windows.Forms.Padding(0);
            this.longListview.Name = "longListview";
            this.longListview.Size = new System.Drawing.Size(252, 76);
            this.longListview.TabIndex = 5;
            this.longListview.UseCompatibleStateImageBehavior = false;
            // 
            // ongoingListview
            // 
            this.ongoingListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ongoingListview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ongoingListview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ongoingListview.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ongoingListview.GridLines = true;
            this.ongoingListview.Location = new System.Drawing.Point(252, 22);
            this.ongoingListview.Margin = new System.Windows.Forms.Padding(0);
            this.ongoingListview.Name = "ongoingListview";
            this.ongoingListview.Size = new System.Drawing.Size(250, 76);
            this.ongoingListview.TabIndex = 4;
            this.ongoingListview.UseCompatibleStateImageBehavior = false;
            // 
            // longLabel
            // 
            this.longLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longLabel.AutoSize = true;
            this.longLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longLabel.Location = new System.Drawing.Point(506, 5);
            this.longLabel.Name = "longLabel";
            this.longLabel.Size = new System.Drawing.Size(246, 16);
            this.longLabel.TabIndex = 2;
            this.longLabel.Text = "Matches Taking Too Long";
            this.longLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ongoingLabel
            // 
            this.ongoingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ongoingLabel.AutoSize = true;
            this.ongoingLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ongoingLabel.Location = new System.Drawing.Point(255, 5);
            this.ongoingLabel.Name = "ongoingLabel";
            this.ongoingLabel.Size = new System.Drawing.Size(244, 16);
            this.ongoingLabel.TabIndex = 1;
            this.ongoingLabel.Text = "Ongoing Matches";
            this.ongoingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upcomingLabel
            // 
            this.upcomingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingLabel.AutoSize = true;
            this.upcomingLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingLabel.Location = new System.Drawing.Point(4, 5);
            this.upcomingLabel.Name = "upcomingLabel";
            this.upcomingLabel.Size = new System.Drawing.Size(244, 16);
            this.upcomingLabel.TabIndex = 0;
            this.upcomingLabel.Text = "Upcoming Matches";
            this.upcomingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upcomingListview
            // 
            this.upcomingListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingListview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.upcomingListview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.upcomingListview.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingListview.GridLines = true;
            this.upcomingListview.Location = new System.Drawing.Point(1, 22);
            this.upcomingListview.Margin = new System.Windows.Forms.Padding(0);
            this.upcomingListview.Name = "upcomingListview";
            this.upcomingListview.Size = new System.Drawing.Size(250, 76);
            this.upcomingListview.TabIndex = 3;
            this.upcomingListview.UseCompatibleStateImageBehavior = false;
            // 
            // TournamentViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "TournamentViewControl";
            this.Size = new System.Drawing.Size(756, 435);
            this.mainPanel.ResumeLayout(false);
            this.matchesPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Label upcomingLabel;
        private System.Windows.Forms.Label longLabel;
        private System.Windows.Forms.Label ongoingLabel;
        private System.Windows.Forms.ListView upcomingListview;
        private System.Windows.Forms.ListView longListview;
        private System.Windows.Forms.ListView ongoingListview;
        private System.Windows.Forms.Panel matchesPanel;
        private System.Windows.Forms.TableLayoutPanel tourneyTablePanel;
    }
}
