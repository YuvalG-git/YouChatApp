namespace YouChatApp
{
    partial class InitialProfileSelection
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ProfilePictureGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(357, 415);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ProfilePictureGroupBox
            // 
            this.ProfilePictureGroupBox.AutoSize = true;
            this.ProfilePictureGroupBox.Location = new System.Drawing.Point(262, 113);
            this.ProfilePictureGroupBox.Name = "ProfilePictureGroupBox";
            this.ProfilePictureGroupBox.Size = new System.Drawing.Size(200, 100);
            this.ProfilePictureGroupBox.TabIndex = 1;
            this.ProfilePictureGroupBox.TabStop = false;
            this.ProfilePictureGroupBox.Text = "groupBox1";
            // 
            // InitialProfileSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProfilePictureGroupBox);
            this.Controls.Add(this.ConfirmButton);
            this.Name = "InitialProfileSelection";
            this.Text = "InitialProfileSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        private System.Windows.Forms.Button[] ProfilePictureKindSelectionButtons;
        private System.Windows.Forms.GroupBox ProfilePictureGroupBox;
    }
}