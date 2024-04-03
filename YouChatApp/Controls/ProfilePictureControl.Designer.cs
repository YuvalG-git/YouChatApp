namespace YouChatApp.Controls
{
    partial class ProfilePictureControl
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
            this.ProfilePictureHeadlineLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProfilePictureHeadlineLabel
            // 
            this.ProfilePictureHeadlineLabel.AutoSize = true;
            this.ProfilePictureHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfilePictureHeadlineLabel.Location = new System.Drawing.Point(195, 10);
            this.ProfilePictureHeadlineLabel.Name = "ProfilePictureHeadlineLabel";
            this.ProfilePictureHeadlineLabel.Size = new System.Drawing.Size(179, 28);
            this.ProfilePictureHeadlineLabel.TabIndex = 49;
            this.ProfilePictureHeadlineLabel.Text = "Profile Picture";
            // 
            // ProfilePictureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.ProfilePictureHeadlineLabel);
            this.MaximumSize = new System.Drawing.Size(570, 620);
            this.MinimumSize = new System.Drawing.Size(570, 620);
            this.Name = "ProfilePictureControl";
            this.Size = new System.Drawing.Size(570, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        private System.Windows.Forms.Button[] ProfilePictureKindSelectionButtons;
        private CustomButton[,] ProfileAvatarMatrixOfCustomButtons;
        private CustomButton[] ProfilePictureKindSelectionCustomButtons;
        private System.Windows.Forms.Label ProfilePictureHeadlineLabel;
    }
}
