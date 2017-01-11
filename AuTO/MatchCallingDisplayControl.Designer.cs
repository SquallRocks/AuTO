namespace AuTO
{
    partial class MatchCallingDisplayControl
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
            this.components = new System.ComponentModel.Container();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.upcomingTable = new System.Windows.Forms.TableLayoutPanel();
            this.upcomingLabel = new System.Windows.Forms.Label();
            this.upcomingListbox = new System.Windows.Forms.ListBox();
            this.secondSplit = new System.Windows.Forms.SplitContainer();
            this.ongoingTable = new System.Windows.Forms.TableLayoutPanel();
            this.currentLabel = new System.Windows.Forms.Label();
            this.currentListbox = new System.Windows.Forms.ListBox();
            this.longTable = new System.Windows.Forms.TableLayoutPanel();
            this.longLabel = new System.Windows.Forms.Label();
            this.longListbox = new System.Windows.Forms.ListBox();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reportMatchAsOngoingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.upcomingTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondSplit)).BeginInit();
            this.secondSplit.Panel1.SuspendLayout();
            this.secondSplit.Panel2.SuspendLayout();
            this.secondSplit.SuspendLayout();
            this.ongoingTable.SuspendLayout();
            this.longTable.SuspendLayout();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.upcomingTable);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.secondSplit);
            this.mainSplit.Size = new System.Drawing.Size(234, 480);
            this.mainSplit.SplitterDistance = 192;
            this.mainSplit.TabIndex = 0;
            // 
            // upcomingTable
            // 
            this.upcomingTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.upcomingTable.ColumnCount = 1;
            this.upcomingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.upcomingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.upcomingTable.Controls.Add(this.upcomingLabel, 0, 0);
            this.upcomingTable.Controls.Add(this.upcomingListbox, 0, 1);
            this.upcomingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upcomingTable.Location = new System.Drawing.Point(0, 0);
            this.upcomingTable.Name = "upcomingTable";
            this.upcomingTable.RowCount = 2;
            this.upcomingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2807F));
            this.upcomingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.7193F));
            this.upcomingTable.Size = new System.Drawing.Size(234, 192);
            this.upcomingTable.TabIndex = 0;
            // 
            // upcomingLabel
            // 
            this.upcomingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingLabel.AutoSize = true;
            this.upcomingLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingLabel.Location = new System.Drawing.Point(4, 1);
            this.upcomingLabel.Name = "upcomingLabel";
            this.upcomingLabel.Size = new System.Drawing.Size(226, 23);
            this.upcomingLabel.TabIndex = 5;
            this.upcomingLabel.Text = "Matches to Call";
            this.upcomingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upcomingListbox
            // 
            this.upcomingListbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.upcomingListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.upcomingListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upcomingListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingListbox.FormattingEnabled = true;
            this.upcomingListbox.ItemHeight = 16;
            this.upcomingListbox.Location = new System.Drawing.Point(1, 25);
            this.upcomingListbox.Margin = new System.Windows.Forms.Padding(0);
            this.upcomingListbox.Name = "upcomingListbox";
            this.upcomingListbox.Size = new System.Drawing.Size(232, 166);
            this.upcomingListbox.TabIndex = 4;
            this.upcomingListbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseDown);
            // 
            // secondSplit
            // 
            this.secondSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondSplit.Location = new System.Drawing.Point(0, 0);
            this.secondSplit.Name = "secondSplit";
            this.secondSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // secondSplit.Panel1
            // 
            this.secondSplit.Panel1.Controls.Add(this.ongoingTable);
            // 
            // secondSplit.Panel2
            // 
            this.secondSplit.Panel2.Controls.Add(this.longTable);
            this.secondSplit.Size = new System.Drawing.Size(234, 284);
            this.secondSplit.SplitterDistance = 147;
            this.secondSplit.TabIndex = 0;
            // 
            // ongoingTable
            // 
            this.ongoingTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ongoingTable.ColumnCount = 1;
            this.ongoingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ongoingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ongoingTable.Controls.Add(this.currentLabel, 0, 0);
            this.ongoingTable.Controls.Add(this.currentListbox, 0, 1);
            this.ongoingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ongoingTable.Location = new System.Drawing.Point(0, 0);
            this.ongoingTable.Name = "ongoingTable";
            this.ongoingTable.RowCount = 2;
            this.ongoingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.89189F));
            this.ongoingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.10811F));
            this.ongoingTable.Size = new System.Drawing.Size(234, 147);
            this.ongoingTable.TabIndex = 0;
            // 
            // currentLabel
            // 
            this.currentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLabel.AutoSize = true;
            this.currentLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLabel.Location = new System.Drawing.Point(4, 1);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(226, 24);
            this.currentLabel.TabIndex = 6;
            this.currentLabel.Text = "Current Matches";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentListbox
            // 
            this.currentListbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.currentListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentListbox.FormattingEnabled = true;
            this.currentListbox.ItemHeight = 16;
            this.currentListbox.Location = new System.Drawing.Point(1, 26);
            this.currentListbox.Margin = new System.Windows.Forms.Padding(0);
            this.currentListbox.Name = "currentListbox";
            this.currentListbox.Size = new System.Drawing.Size(232, 120);
            this.currentListbox.TabIndex = 5;
            // 
            // longTable
            // 
            this.longTable.ColumnCount = 1;
            this.longTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.longTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.longTable.Controls.Add(this.longLabel, 0, 0);
            this.longTable.Controls.Add(this.longListbox, 0, 1);
            this.longTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.longTable.Location = new System.Drawing.Point(0, 0);
            this.longTable.Name = "longTable";
            this.longTable.RowCount = 2;
            this.longTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.32061F));
            this.longTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.67939F));
            this.longTable.Size = new System.Drawing.Size(234, 133);
            this.longTable.TabIndex = 0;
            // 
            // longLabel
            // 
            this.longLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longLabel.AutoSize = true;
            this.longLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longLabel.Location = new System.Drawing.Point(3, 0);
            this.longLabel.Name = "longLabel";
            this.longLabel.Size = new System.Drawing.Size(228, 24);
            this.longLabel.TabIndex = 7;
            this.longLabel.Text = "Matches Taking Too Long";
            this.longLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // longListbox
            // 
            this.longListbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.longListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.longListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.longListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longListbox.FormattingEnabled = true;
            this.longListbox.ItemHeight = 16;
            this.longListbox.Location = new System.Drawing.Point(0, 24);
            this.longListbox.Margin = new System.Windows.Forms.Padding(0);
            this.longListbox.Name = "longListbox";
            this.longListbox.Size = new System.Drawing.Size(234, 109);
            this.longListbox.TabIndex = 6;
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportMatchAsOngoingToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(211, 26);
            this.rightClickMenu.Text = "Upcoming Match Menu";
            // 
            // reportMatchAsOngoingToolStripMenuItem
            // 
            this.reportMatchAsOngoingToolStripMenuItem.Name = "reportMatchAsOngoingToolStripMenuItem";
            this.reportMatchAsOngoingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.reportMatchAsOngoingToolStripMenuItem.Text = "Report Match as Ongoing";
            this.reportMatchAsOngoingToolStripMenuItem.Click += new System.EventHandler(this.reportMatchAsOngoingToolStripMenuItem_Click);
            // 
            // MatchCallingDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.mainSplit);
            this.Name = "MatchCallingDisplayControl";
            this.Size = new System.Drawing.Size(234, 480);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.upcomingTable.ResumeLayout(false);
            this.upcomingTable.PerformLayout();
            this.secondSplit.Panel1.ResumeLayout(false);
            this.secondSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondSplit)).EndInit();
            this.secondSplit.ResumeLayout(false);
            this.ongoingTable.ResumeLayout(false);
            this.ongoingTable.PerformLayout();
            this.longTable.ResumeLayout(false);
            this.longTable.PerformLayout();
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.SplitContainer secondSplit;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem reportMatchAsOngoingToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel upcomingTable;
        private System.Windows.Forms.Label upcomingLabel;
        private System.Windows.Forms.ListBox upcomingListbox;
        private System.Windows.Forms.TableLayoutPanel ongoingTable;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.ListBox currentListbox;
        private System.Windows.Forms.TableLayoutPanel longTable;
        private System.Windows.Forms.Label longLabel;
        private System.Windows.Forms.ListBox longListbox;
    }
}
