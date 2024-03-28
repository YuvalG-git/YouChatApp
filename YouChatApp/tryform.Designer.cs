namespace YouChatApp
{
    partial class tryform
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
            this.smtpControl1 = new YouChatApp.Controls.SmtpControl();
            this.personalVerificationAnswersControl1 = new YouChatApp.Controls.PersonalVerificationAnswersControl();
            this.SuspendLayout();
            // 
            // smtpControl1
            // 
            this.smtpControl1.ControlType = YouChatApp.EnumHandler.UserAuthentication_Enum.PasswordUpdate;
            this.smtpControl1.Location = new System.Drawing.Point(79, 65);
            this.smtpControl1.Name = "smtpControl1";
            this.smtpControl1.Size = new System.Drawing.Size(350, 190);
            this.smtpControl1.TabIndex = 0;
            // 
            // personalVerificationAnswersControl1
            // 
            this.personalVerificationAnswersControl1.Location = new System.Drawing.Point(388, 194);
            this.personalVerificationAnswersControl1.Name = "personalVerificationAnswersControl1";
            this.personalVerificationAnswersControl1.Size = new System.Drawing.Size(400, 387);
            this.personalVerificationAnswersControl1.TabIndex = 1;
            // 
            // tryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.personalVerificationAnswersControl1);
            this.Controls.Add(this.smtpControl1);
            this.Name = "tryform";
            this.Text = "tryform";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SmtpControl smtpControl1;
        private Controls.PersonalVerificationAnswersControl personalVerificationAnswersControl1;
    }
}