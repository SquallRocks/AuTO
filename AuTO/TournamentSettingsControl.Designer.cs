namespace AuTO
{
    partial class TournamentSettingsControl
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
            this.playerTable = new System.Windows.Forms.TableLayoutPanel();
            this.nameButton = new System.Windows.Forms.Button();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.editPlayerLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.playerListbox = new System.Windows.Forms.ListBox();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.successLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.instLabel = new System.Windows.Forms.Label();
            this.playerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerTable
            // 
            this.playerTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.playerTable.ColumnCount = 1;
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playerTable.Controls.Add(this.nameButton, 0, 4);
            this.playerTable.Controls.Add(this.nameTextbox, 0, 3);
            this.playerTable.Controls.Add(this.editPlayerLabel, 0, 2);
            this.playerTable.Controls.Add(this.playerLabel, 0, 0);
            this.playerTable.Controls.Add(this.playerListbox, 0, 1);
            this.playerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTable.Location = new System.Drawing.Point(0, 0);
            this.playerTable.Name = "playerTable";
            this.playerTable.RowCount = 5;
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.848585F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.26804F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.06295F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.711589F));
            this.playerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.10884F));
            this.playerTable.Size = new System.Drawing.Size(252, 435);
            this.playerTable.TabIndex = 0;
            // 
            // nameButton
            // 
            this.nameButton.BackColor = System.Drawing.Color.SlateGray;
            this.nameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameButton.Location = new System.Drawing.Point(2, 384);
            this.nameButton.Margin = new System.Windows.Forms.Padding(0);
            this.nameButton.Name = "nameButton";
            this.nameButton.Size = new System.Drawing.Size(248, 49);
            this.nameButton.TabIndex = 17;
            this.nameButton.Text = "Change Name";
            this.nameButton.UseVisualStyleBackColor = false;
            this.nameButton.Click += new System.EventHandler(this.nameButton_Click);
            // 
            // nameTextbox
            // 
            this.nameTextbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.nameTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextbox.Location = new System.Drawing.Point(2, 354);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(0);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(248, 30);
            this.nameTextbox.TabIndex = 11;
            // 
            // editPlayerLabel
            // 
            this.editPlayerLabel.AutoSize = true;
            this.editPlayerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPlayerLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPlayerLabel.Location = new System.Drawing.Point(5, 318);
            this.editPlayerLabel.Name = "editPlayerLabel";
            this.editPlayerLabel.Size = new System.Drawing.Size(242, 34);
            this.editPlayerLabel.TabIndex = 3;
            this.editPlayerLabel.Text = "Edit Name";
            this.editPlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.Location = new System.Drawing.Point(5, 2);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(242, 28);
            this.playerLabel.TabIndex = 0;
            this.playerLabel.Text = "Participants";
            this.playerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerListbox
            // 
            this.playerListbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.playerListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playerListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerListbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerListbox.FormattingEnabled = true;
            this.playerListbox.ItemHeight = 16;
            this.playerListbox.Location = new System.Drawing.Point(7, 37);
            this.playerListbox.Margin = new System.Windows.Forms.Padding(5);
            this.playerListbox.Name = "playerListbox";
            this.playerListbox.Size = new System.Drawing.Size(238, 274);
            this.playerListbox.TabIndex = 1;
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.playerTable);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.successLabel);
            this.mainSplit.Panel2.Controls.Add(this.errorLabel);
            this.mainSplit.Panel2.Controls.Add(this.deleteButton);
            this.mainSplit.Panel2.Controls.Add(this.instLabel);
            this.mainSplit.Size = new System.Drawing.Size(756, 435);
            this.mainSplit.SplitterDistance = 252;
            this.mainSplit.TabIndex = 1;
            // 
            // successLabel
            // 
            this.successLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.successLabel.AutoSize = true;
            this.successLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.successLabel.Location = new System.Drawing.Point(3, 412);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(194, 16);
            this.successLabel.TabIndex = 24;
            this.successLabel.Text = "Successfully changed name!";
            this.successLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Maroon;
            this.errorLabel.Location = new System.Drawing.Point(-1, 412);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 16);
            this.errorLabel.TabIndex = 23;
            this.errorLabel.Text = "Errors.";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Maroon;
            this.deleteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(274, 393);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(226, 35);
            this.deleteButton.TabIndex = 22;
            this.deleteButton.Text = "Delete Tournament";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // instLabel
            // 
            this.instLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instLabel.AutoSize = true;
            this.instLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instLabel.Location = new System.Drawing.Point(3, 25);
            this.instLabel.Name = "instLabel";
            this.instLabel.Size = new System.Drawing.Size(460, 168);
            this.instLabel.TabIndex = 2;
            this.instLabel.Text = "To change a name of a player:\r\n\r\n1. Select the player\r\n2. Type the name name in t" +
    "he textbox\r\n3. Press \"Change Name\"\r\n\r\n";
            // 
            // TournamentSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.mainSplit);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "TournamentSettingsControl";
            this.Size = new System.Drawing.Size(756, 435);
            this.playerTable.ResumeLayout(false);
            this.playerTable.PerformLayout();
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel playerTable;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.ListBox playerListbox;
        private System.Windows.Forms.Label editPlayerLabel;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Button nameButton;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label instLabel;
    }
}
