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
            this.headerLabel = new System.Windows.Forms.Label();
            this.idenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // idenPanel
            // 
            this.idenPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.idenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idenPanel.Controls.Add(this.headerLabel);
            this.idenPanel.Location = new System.Drawing.Point(0, 0);
            this.idenPanel.Name = "idenPanel";
            this.idenPanel.Size = new System.Drawing.Size(756, 64);
            this.idenPanel.TabIndex = 2;
            // 
            // headerLabel
            // 
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

    }
}
