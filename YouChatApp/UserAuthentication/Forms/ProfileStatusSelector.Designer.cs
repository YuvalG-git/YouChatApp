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
            this.profileStatusControl1 = new YouChatApp.Controls.ProfileStatusControl();
            this.SuspendLayout();
            // 
            // profileStatusControl1
            // 
            this.profileStatusControl1.IsSelectedStatusShown = true;
            this.profileStatusControl1.Location = new System.Drawing.Point(72, 32);
            this.profileStatusControl1.Name = "profileStatusControl1";
            this.profileStatusControl1.Size = new System.Drawing.Size(320, 345);
            this.profileStatusControl1.TabIndex = 0;
            // 
            // ProfileStatusSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.profileStatusControl1);
            this.Name = "ProfileStatusSelector";
            this.Text = "ProfileStatusSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ProfileStatusControl profileStatusControl1;
    }
}