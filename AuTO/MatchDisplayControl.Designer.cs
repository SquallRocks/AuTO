namespace AuTO
{
    partial class MatchDisplayControl
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.player2UpDown = new System.Windows.Forms.NumericUpDown();
            this.player2Textbox = new System.Windows.Forms.TextBox();
            this.player1UpDown = new System.Windows.Forms.NumericUpDown();
            this.player1Textbox = new System.Windows.Forms.TextBox();
            this.player2Label = new System.Windows.Forms.Label();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reportAsOngoingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1UpDown)).BeginInit();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mainPanel.Controls.Add(this.errorLabel);
            this.mainPanel.Controls.Add(this.submitButton);
            this.mainPanel.Controls.Add(this.player2UpDown);
            this.mainPanel.Controls.Add(this.player2Textbox);
            this.mainPanel.Controls.Add(this.player1UpDown);
            this.mainPanel.Controls.Add(this.player1Textbox);
            this.mainPanel.Controls.Add(this.player2Label);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(180, 148);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Maroon;
            this.errorLabel.Location = new System.Drawing.Point(3, 126);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(168, 14);
            this.errorLabel.TabIndex = 14;
            this.errorLabel.Text = "Could not submit; try again.";
            this.errorLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.BackColor = System.Drawing.Color.SlateGray;
            this.submitButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(3, 92);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(174, 31);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Submit Scores";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // player2UpDown
            // 
            this.player2UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2UpDown.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.player2UpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2UpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2UpDown.Location = new System.Drawing.Point(141, 57);
            this.player2UpDown.Name = "player2UpDown";
            this.player2UpDown.Size = new System.Drawing.Size(36, 29);
            this.player2UpDown.TabIndex = 11;
            this.player2UpDown.ValueChanged += new System.EventHandler(this.player2UpDown_ValueChanged);
            this.player2UpDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // player2Textbox
            // 
            this.player2Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2Textbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.player2Textbox.Enabled = false;
            this.player2Textbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Textbox.Location = new System.Drawing.Point(3, 56);
            this.player2Textbox.Name = "player2Textbox";
            this.player2Textbox.Size = new System.Drawing.Size(134, 30);
            this.player2Textbox.TabIndex = 10;
            this.player2Textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // player1UpDown
            // 
            this.player1UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1UpDown.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.player1UpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1UpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1UpDown.Location = new System.Drawing.Point(141, 13);
            this.player1UpDown.Name = "player1UpDown";
            this.player1UpDown.Size = new System.Drawing.Size(36, 29);
            this.player1UpDown.TabIndex = 9;
            this.player1UpDown.ValueChanged += new System.EventHandler(this.player1UpDown_ValueChanged);
            this.player1UpDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // player1Textbox
            // 
            this.player1Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1Textbox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.player1Textbox.Enabled = false;
            this.player1Textbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Textbox.Location = new System.Drawing.Point(3, 12);
            this.player1Textbox.Name = "player1Textbox";
            this.player1Textbox.Size = new System.Drawing.Size(134, 30);
            this.player1Textbox.TabIndex = 8;
            this.player1Textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Label.Location = new System.Drawing.Point(16, 96);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(0, 16);
            this.player2Label.TabIndex = 1;
            this.player2Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportAsOngoingToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(174, 26);
            this.rightClickMenu.Text = "Match Menu";
            this.rightClickMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // reportAsOngoingToolStripMenuItem
            // 
            this.reportAsOngoingToolStripMenuItem.Name = "reportAsOngoingToolStripMenuItem";
            this.reportAsOngoingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.reportAsOngoingToolStripMenuItem.Text = "Report as Ongoing";
            this.reportAsOngoingToolStripMenuItem.Click += new System.EventHandler(this.reportAsOngoingToolStripMenuItem_Click);
            this.reportAsOngoingToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allControls_MouseDown);
            // 
            // MatchDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "MatchDisplayControl";
            this.Size = new System.Drawing.Size(180, 148);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1UpDown)).EndInit();
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.NumericUpDown player1UpDown;
        private System.Windows.Forms.TextBox player1Textbox;
        private System.Windows.Forms.NumericUpDown player2UpDown;
        private System.Windows.Forms.TextBox player2Textbox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem reportAsOngoingToolStripMenuItem;
    }
}
