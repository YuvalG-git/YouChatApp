namespace YouChatApp.UserAuthentication.Forms
{
    partial class ProfileStatusSelector
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
            this.ProfileStatusControl = new YouChatApp.Controls.ProfileStatusControl();
            this.SuspendLayout();
            // 
            // ProfileStatusControl
            // 
            this.ProfileStatusControl.IsSelectedStatusShown = false;
            this.ProfileStatusControl.Location = new System.Drawing.Point(208, 51);
            this.ProfileStatusControl.Name = "ProfileStatusControl";
            this.ProfileStatusControl.Size = new System.Drawing.Size(320, 235);
            this.ProfileStatusControl.TabIndex = 0;
            // 
            // ProfileStatusSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProfileStatusControl);
            this.Name = "ProfileStatusSelector";
            this.Text = "ProfileStatusSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ProfileStatusControl ProfileStatusControl;
    }
}