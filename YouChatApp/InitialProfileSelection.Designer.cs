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
            this.ConfirmCustomButton = new YouChatApp.Controls.CustomButton();
            this.ProfileStatusControl = new YouChatApp.Controls.ProfileStatusControl();
            this.ProfilePictureControl = new YouChatApp.Controls.ProfilePictureControl();
            this.ProfilePicturePanel = new System.Windows.Forms.Panel();
            this.ProfilePicturePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmCustomButton
            // 
            this.ConfirmCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ConfirmCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ConfirmCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ConfirmCustomButton.BorderRadius = 10;
            this.ConfirmCustomButton.BorderSize = 0;
            this.ConfirmCustomButton.Circular = false;
            this.ConfirmCustomButton.Enabled = false;
            this.ConfirmCustomButton.FlatAppearance.BorderSize = 0;
            this.ConfirmCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmCustomButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmCustomButton.Location = new System.Drawing.Point(210, 630);
            this.ConfirmCustomButton.Name = "ConfirmCustomButton";
            this.ConfirmCustomButton.Size = new System.Drawing.Size(150, 40);
            this.ConfirmCustomButton.TabIndex = 2;
            this.ConfirmCustomButton.Text = "Confirm";
            this.ConfirmCustomButton.TextColor = System.Drawing.Color.White;
            this.ConfirmCustomButton.UseVisualStyleBackColor = false;
            this.ConfirmCustomButton.Click += new System.EventHandler(this.ConfirmCustomButton_Click);
            // 
            // ProfileStatusControl
            // 
            this.ProfileStatusControl.IsSelectedStatusShown = false;
            this.ProfileStatusControl.Location = new System.Drawing.Point(753, 174);
            this.ProfileStatusControl.Name = "ProfileStatusControl";
            this.ProfileStatusControl.Size = new System.Drawing.Size(320, 235);
            this.ProfileStatusControl.TabIndex = 3;
            // 
            // ProfilePictureControl
            // 
            this.ProfilePictureControl.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ProfilePictureControl.Location = new System.Drawing.Point(0, 0);
            this.ProfilePictureControl.MaximumSize = new System.Drawing.Size(570, 620);
            this.ProfilePictureControl.MinimumSize = new System.Drawing.Size(570, 620);
            this.ProfilePictureControl.Name = "ProfilePictureControl";
            this.ProfilePictureControl.Size = new System.Drawing.Size(570, 620);
            this.ProfilePictureControl.TabIndex = 4;
            // 
            // ProfilePicturePanel
            // 
            this.ProfilePicturePanel.Controls.Add(this.ProfilePictureControl);
            this.ProfilePicturePanel.Controls.Add(this.ConfirmCustomButton);
            this.ProfilePicturePanel.Location = new System.Drawing.Point(95, 12);
            this.ProfilePicturePanel.Name = "ProfilePicturePanel";
            this.ProfilePicturePanel.Size = new System.Drawing.Size(570, 680);
            this.ProfilePicturePanel.TabIndex = 5;
            // 
            // InitialProfileSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 755);
            this.Controls.Add(this.ProfilePicturePanel);
            this.Controls.Add(this.ProfileStatusControl);
            this.Name = "InitialProfileSelection";
            this.Text = "InitialProfileSelection";
            this.ProfilePicturePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        private System.Windows.Forms.Button[] ProfilePictureKindSelectionButtons;
        private Controls.CustomButton ConfirmCustomButton;
        private Controls.ProfileStatusControl ProfileStatusControl;
        private Controls.ProfilePictureControl ProfilePictureControl;
        private System.Windows.Forms.Panel ProfilePicturePanel;
    }
}