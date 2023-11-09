namespace YouChatApp.Controls
{
    partial class SmtpControl
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
            this.VerifyCustomButton = new YouChatApp.Controls.CustomButton();
            this.SmtpCodeCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.SmtpCodeLabel = new System.Windows.Forms.Label();
            this.RestartSmtpCodeCustomButton = new YouChatApp.Controls.CustomButton();
            this.CaptchaCodeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VerifyCustomButton
            // 
            this.VerifyCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.VerifyCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.VerifyCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.VerifyCustomButton.BorderRadius = 10;
            this.VerifyCustomButton.BorderSize = 0;
            this.VerifyCustomButton.Circular = false;
            this.VerifyCustomButton.FlatAppearance.BorderSize = 0;
            this.VerifyCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyCustomButton.ForeColor = System.Drawing.Color.White;
            this.VerifyCustomButton.Location = new System.Drawing.Point(100, 140);
            this.VerifyCustomButton.Name = "VerifyCustomButton";
            this.VerifyCustomButton.Size = new System.Drawing.Size(150, 40);
            this.VerifyCustomButton.TabIndex = 52;
            this.VerifyCustomButton.Text = "Verify";
            this.VerifyCustomButton.TextColor = System.Drawing.Color.White;
            this.VerifyCustomButton.UseVisualStyleBackColor = false;
            // 
            // SmtpCodeCustomTextBox
            // 
            this.SmtpCodeCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SmtpCodeCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.SmtpCodeCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.SmtpCodeCustomTextBox.BorderRadius = 0;
            this.SmtpCodeCustomTextBox.BorderSize = 2;
            this.SmtpCodeCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmtpCodeCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.SmtpCodeCustomTextBox.IsFocused = false;
            this.SmtpCodeCustomTextBox.Location = new System.Drawing.Point(39, 90);
            this.SmtpCodeCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SmtpCodeCustomTextBox.MaxLength = 10;
            this.SmtpCodeCustomTextBox.Multiline = false;
            this.SmtpCodeCustomTextBox.Name = "SmtpCodeCustomTextBox";
            this.SmtpCodeCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.SmtpCodeCustomTextBox.PasswordChar = false;
            this.SmtpCodeCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.SmtpCodeCustomTextBox.PlaceHolderText = "Enter Verification Code";
            this.SmtpCodeCustomTextBox.ReadOnly = false;
            this.SmtpCodeCustomTextBox.Size = new System.Drawing.Size(230, 33);
            this.SmtpCodeCustomTextBox.TabIndex = 50;
            this.SmtpCodeCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SmtpCodeCustomTextBox.TextContent = "";
            this.SmtpCodeCustomTextBox.UnderlineStyle = true;
            this.SmtpCodeCustomTextBox.TextChangedEvent += new System.EventHandler(this.SmtpCodeCustomTextBox_TextChangedEvent);
            // 
            // SmtpCodeLabel
            // 
            this.SmtpCodeLabel.AutoSize = true;
            this.SmtpCodeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmtpCodeLabel.Location = new System.Drawing.Point(35, 65);
            this.SmtpCodeLabel.Name = "SmtpCodeLabel";
            this.SmtpCodeLabel.Size = new System.Drawing.Size(64, 22);
            this.SmtpCodeLabel.TabIndex = 49;
            this.SmtpCodeLabel.Text = "Code:";
            // 
            // RestartSmtpCodeCustomButton
            // 
            this.RestartSmtpCodeCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartSmtpCodeCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartSmtpCodeCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RestartSmtpCodeCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RestartSmtpCodeCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RestartSmtpCodeCustomButton.BorderRadius = 10;
            this.RestartSmtpCodeCustomButton.BorderSize = 0;
            this.RestartSmtpCodeCustomButton.Circular = false;
            this.RestartSmtpCodeCustomButton.FlatAppearance.BorderSize = 0;
            this.RestartSmtpCodeCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartSmtpCodeCustomButton.ForeColor = System.Drawing.Color.White;
            this.RestartSmtpCodeCustomButton.Location = new System.Drawing.Point(287, 90);
            this.RestartSmtpCodeCustomButton.Name = "RestartSmtpCodeCustomButton";
            this.RestartSmtpCodeCustomButton.Size = new System.Drawing.Size(33, 33);
            this.RestartSmtpCodeCustomButton.TabIndex = 48;
            this.RestartSmtpCodeCustomButton.TextColor = System.Drawing.Color.White;
            this.RestartSmtpCodeCustomButton.UseVisualStyleBackColor = false;
            // 
            // CaptchaCodeLabel
            // 
            this.CaptchaCodeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaCodeLabel.Location = new System.Drawing.Point(30, 10);
            this.CaptchaCodeLabel.Name = "CaptchaCodeLabel";
            this.CaptchaCodeLabel.Size = new System.Drawing.Size(290, 50);
            this.CaptchaCodeLabel.TabIndex = 47;
            this.CaptchaCodeLabel.Text = "Verification Code";
            this.CaptchaCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SmtpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VerifyCustomButton);
            this.Controls.Add(this.SmtpCodeCustomTextBox);
            this.Controls.Add(this.SmtpCodeLabel);
            this.Controls.Add(this.RestartSmtpCodeCustomButton);
            this.Controls.Add(this.CaptchaCodeLabel);
            this.Name = "SmtpControl";
            this.Size = new System.Drawing.Size(350, 190);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButton VerifyCustomButton;
        private CustomTextBox SmtpCodeCustomTextBox;
        private System.Windows.Forms.Label SmtpCodeLabel;
        private CustomButton RestartSmtpCodeCustomButton;
        private System.Windows.Forms.Label CaptchaCodeLabel;
    }
}
