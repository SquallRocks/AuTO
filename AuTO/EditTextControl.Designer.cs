namespace AuTO
{
    partial class EditTextControl
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
            this.editLabel = new System.Windows.Forms.Label();
            this.editTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLabel.Location = new System.Drawing.Point(3, 10);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(71, 16);
            this.editLabel.TabIndex = 0;
            this.editLabel.Text = "New Text:";
            // 
            // editTextbox
            // 
            this.editTextbox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editTextbox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTextbox.Location = new System.Drawing.Point(80, 8);
            this.editTextbox.Name = "editTextbox";
            this.editTextbox.Size = new System.Drawing.Size(128, 24);
            this.editTextbox.TabIndex = 1;
            // 
            // EditTextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.editTextbox);
            this.Controls.Add(this.editLabel);
            this.Name = "EditTextControl";
            this.Size = new System.Drawing.Size(220, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.TextBox editTextbox;
    }
}
