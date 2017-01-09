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
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.upcomingLabel = new System.Windows.Forms.Label();
            this.upcomingListbox = new System.Windows.Forms.ListBox();
            this.secondSplit = new System.Windows.Forms.SplitContainer();
            this.currentLabel = new System.Windows.Forms.Label();
            this.currentListbox = new System.Windows.Forms.ListBox();
            this.longLabel = new System.Windows.Forms.Label();
            this.longListbox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondSplit)).BeginInit();
            this.secondSplit.Panel1.SuspendLayout();
            this.secondSplit.Panel2.SuspendLayout();
            this.secondSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.upcomingLabel);
            this.mainSplit.Panel1.Controls.Add(this.upcomingListbox);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.secondSplit);
            this.mainSplit.Size = new System.Drawing.Size(232, 478);
            this.mainSplit.SplitterDistance = 231;
            this.mainSplit.TabIndex = 0;
            // 
            // upcomingLabel
            // 
            this.upcomingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingLabel.AutoSize = true;
            this.upcomingLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingLabel.Location = new System.Drawing.Point(35, 0);
            this.upcomingLabel.Name = "upcomingLabel";
            this.upcomingLabel.Size = new System.Drawing.Size(164, 18);
            this.upcomingLabel.TabIndex = 3;
            this.upcomingLabel.Text = "Upcoming Matches";
            this.upcomingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upcomingListbox
            // 
            this.upcomingListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingListbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.upcomingListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.upcomingListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingListbox.FormattingEnabled = true;
            this.upcomingListbox.ItemHeight = 16;
            this.upcomingListbox.Location = new System.Drawing.Point(-2, 24);
            this.upcomingListbox.Margin = new System.Windows.Forms.Padding(0);
            this.upcomingListbox.Name = "upcomingListbox";
            this.upcomingListbox.Size = new System.Drawing.Size(232, 208);
            this.upcomingListbox.TabIndex = 0;
            this.upcomingListbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseDown);
            this.upcomingListbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseMove);
            // 
            // secondSplit
            // 
            this.secondSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondSplit.Location = new System.Drawing.Point(0, 0);
            this.secondSplit.Name = "secondSplit";
            this.secondSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // secondSplit.Panel1
            // 
            this.secondSplit.Panel1.Controls.Add(this.currentLabel);
            this.secondSplit.Panel1.Controls.Add(this.currentListbox);
            // 
            // secondSplit.Panel2
            // 
            this.secondSplit.Panel2.Controls.Add(this.longLabel);
            this.secondSplit.Panel2.Controls.Add(this.longListbox);
            this.secondSplit.Size = new System.Drawing.Size(232, 243);
            this.secondSplit.SplitterDistance = 128;
            this.secondSplit.TabIndex = 0;
            // 
            // currentLabel
            // 
            this.currentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLabel.AutoSize = true;
            this.currentLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLabel.Location = new System.Drawing.Point(44, -1);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(144, 18);
            this.currentLabel.TabIndex = 4;
            this.currentLabel.Text = "Current Matches";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentListbox
            // 
            this.currentListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.currentListbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.currentListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentListbox.FormattingEnabled = true;
            this.currentListbox.ItemHeight = 16;
            this.currentListbox.Location = new System.Drawing.Point(-2, 32);
            this.currentListbox.Margin = new System.Windows.Forms.Padding(0);
            this.currentListbox.Name = "currentListbox";
            this.currentListbox.Size = new System.Drawing.Size(232, 96);
            this.currentListbox.TabIndex = 1;
            this.currentListbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseDown);
            this.currentListbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseMove);
            // 
            // longLabel
            // 
            this.longLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longLabel.AutoSize = true;
            this.longLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longLabel.Location = new System.Drawing.Point(5, 0);
            this.longLabel.Name = "longLabel";
            this.longLabel.Size = new System.Drawing.Size(223, 18);
            this.longLabel.TabIndex = 5;
            this.longLabel.Text = "Matches Taking Too Long";
            this.longLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // longListbox
            // 
            this.longListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.longListbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.longListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.longListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longListbox.FormattingEnabled = true;
            this.longListbox.ItemHeight = 16;
            this.longListbox.Location = new System.Drawing.Point(-1, 33);
            this.longListbox.Margin = new System.Windows.Forms.Padding(0);
            this.longListbox.Name = "longListbox";
            this.longListbox.Size = new System.Drawing.Size(232, 80);
            this.longListbox.TabIndex = 2;
            this.longListbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseDown);
            this.longListbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseMove);
            // 
            // MatchCallingDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.mainSplit);
            this.Name = "MatchCallingDisplayControl";
            this.Size = new System.Drawing.Size(232, 478);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel1.PerformLayout();
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.secondSplit.Panel1.ResumeLayout(false);
            this.secondSplit.Panel1.PerformLayout();
            this.secondSplit.Panel2.ResumeLayout(false);
            this.secondSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondSplit)).EndInit();
            this.secondSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.SplitContainer secondSplit;
        private System.Windows.Forms.ListBox upcomingListbox;
        private System.Windows.Forms.ListBox currentListbox;
        private System.Windows.Forms.ListBox longListbox;
        private System.Windows.Forms.Label upcomingLabel;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label longLabel;
    }
}
