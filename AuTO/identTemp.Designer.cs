namespace AuTO
{
    partial class identTemp
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
            this.idenPanel = new System.Windows.Forms.Panel();
            this.losersButton = new System.Windows.Forms.Button();
            this.winnersButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.idenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // idenPanel
            // 
            this.idenPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.idenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idenPanel.Controls.Add(this.losersButton);
            this.idenPanel.Controls.Add(this.winnersButton);
            this.idenPanel.Controls.Add(this.headerLabel);
            this.idenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idenPanel.Location = new System.Drawing.Point(0, 0);
            this.idenPanel.Name = "idenPanel";
            this.idenPanel.Size = new System.Drawing.Size(754, 65);
            this.idenPanel.TabIndex = 2;
            // 
            // losersButton
            // 
            this.losersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.losersButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.losersButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.losersButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losersButton.Location = new System.Drawing.Point(644, 0);
            this.losersButton.Name = "losersButton";
            this.losersButton.Size = new System.Drawing.Size(109, 65);
            this.losersButton.TabIndex = 2;
            this.losersButton.Text = "LOSERS";
            this.losersButton.UseVisualStyleBackColor = false;
            // 
            // winnersButton
            // 
            this.winnersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winnersButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.winnersButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.winnersButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnersButton.Location = new System.Drawing.Point(536, 0);
            this.winnersButton.Name = "winnersButton";
            this.winnersButton.Size = new System.Drawing.Size(109, 65);
            this.winnersButton.TabIndex = 1;
            this.winnersButton.Text = "WINNERS";
            this.winnersButton.UseVisualStyleBackColor = false;
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(2, 8);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(355, 45);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Tournament Name";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // identTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.idenPanel);
            this.Name = "identTemp";
            this.Size = new System.Drawing.Size(754, 65);
            this.idenPanel.ResumeLayout(false);
            this.idenPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel idenPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button losersButton;
        private System.Windows.Forms.Button winnersButton;

    }
}
