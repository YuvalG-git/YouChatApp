namespace YouChatApp
{
    partial class ContactControl
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
            this.ProfilePictureCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.ContactNameLabel = new System.Windows.Forms.Label();
            this.ContactSharingCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfilePictureCircularPictureBox
            // 
            this.ProfilePictureCircularPictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProfilePictureCircularPictureBox.Name = "ProfilePictureCircularPictureBox";
            this.ProfilePictureCircularPictureBox.Size = new System.Drawing.Size(60, 60);
            this.ProfilePictureCircularPictureBox.TabIndex = 0;
            this.ProfilePictureCircularPictureBox.TabStop = false;
            // 
            // ContactNameLabel
            // 
            this.ContactNameLabel.AutoSize = true;
            this.ContactNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactNameLabel.Location = new System.Drawing.Point(90, 29);
            this.ContactNameLabel.Name = "ContactNameLabel";
            this.ContactNameLabel.Size = new System.Drawing.Size(63, 22);
            this.ContactNameLabel.TabIndex = 1;
            this.ContactNameLabel.Text = "Name";
            // 
            // ContactSharingCheckBox
            // 
            this.ContactSharingCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ContactSharingCheckBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ContactSharingCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ContactSharingCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ContactSharingCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.ContactSharingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactSharingCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactSharingCheckBox.Location = new System.Drawing.Point(300, 55);
            this.ContactSharingCheckBox.Name = "ContactSharingCheckBox";
            this.ContactSharingCheckBox.Size = new System.Drawing.Size(20, 20);
            this.ContactSharingCheckBox.TabIndex = 2;
            this.ContactSharingCheckBox.UseVisualStyleBackColor = false;
            this.ContactSharingCheckBox.CheckedChanged += new System.EventHandler(this.ContactSharingCheckBox_CheckedChanged);
            this.ContactSharingCheckBox.Click += new System.EventHandler(this.ContactSharingCheckBox_Click);
            // 
            // ContactControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContactSharingCheckBox);
            this.Controls.Add(this.ContactNameLabel);
            this.Controls.Add(this.ProfilePictureCircularPictureBox);
            this.Name = "ContactControl";
            this.Size = new System.Drawing.Size(325, 80);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureCircularPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularPictureBox ProfilePictureCircularPictureBox;
        private System.Windows.Forms.Label ContactNameLabel;
        private System.Windows.Forms.CheckBox ContactSharingCheckBox;
    }
}
