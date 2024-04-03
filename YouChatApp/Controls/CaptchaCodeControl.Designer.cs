namespace YouChatApp.Controls
{
    partial class CaptchaCodeControl
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
            this.components = new System.ComponentModel.Container();
            this.CaptchaCodeLabel = new System.Windows.Forms.Label();
            this.RestartCaptchaCustomButton = new YouChatApp.Controls.CustomButton();
            this.CaptchaLabel = new System.Windows.Forms.Label();
            this.CaptchaCodeCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CaptchaCheckerCustomButton = new YouChatApp.Controls.CustomButton();
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptchaCodeLabel
            // 
            this.CaptchaCodeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaCodeLabel.Location = new System.Drawing.Point(30, 10);
            this.CaptchaCodeLabel.Name = "CaptchaCodeLabel";
            this.CaptchaCodeLabel.Size = new System.Drawing.Size(200, 50);
            this.CaptchaCodeLabel.TabIndex = 20;
            this.CaptchaCodeLabel.Text = "CAPTCHA";
            this.CaptchaCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestartCaptchaCustomButton
            // 
            this.RestartCaptchaCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartCaptchaCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartCaptchaCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RestartCaptchaCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RestartCaptchaCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RestartCaptchaCustomButton.BorderRadius = 10;
            this.RestartCaptchaCustomButton.BorderSize = 0;
            this.RestartCaptchaCustomButton.Circular = false;
            this.RestartCaptchaCustomButton.FlatAppearance.BorderSize = 0;
            this.RestartCaptchaCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartCaptchaCustomButton.ForeColor = System.Drawing.Color.White;
            this.RestartCaptchaCustomButton.Location = new System.Drawing.Point(190, 200);
            this.RestartCaptchaCustomButton.Name = "RestartCaptchaCustomButton";
            this.RestartCaptchaCustomButton.Size = new System.Drawing.Size(40, 40);
            this.RestartCaptchaCustomButton.TabIndex = 38;
            this.RestartCaptchaCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.RestartCaptchaCustomButton, "To Generate Another Captcha");
            this.RestartCaptchaCustomButton.UseVisualStyleBackColor = false;
            this.RestartCaptchaCustomButton.Click += new System.EventHandler(this.RestartCaptchaCustomButton_Click);
            // 
            // CaptchaLabel
            // 
            this.CaptchaLabel.AutoSize = true;
            this.CaptchaLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaLabel.Location = new System.Drawing.Point(26, 130);
            this.CaptchaLabel.Name = "CaptchaLabel";
            this.CaptchaLabel.Size = new System.Drawing.Size(93, 22);
            this.CaptchaLabel.TabIndex = 43;
            this.CaptchaLabel.Text = "Captcha:";
            // 
            // CaptchaCodeCustomTextBox
            // 
            this.CaptchaCodeCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CaptchaCodeCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CaptchaCodeCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.CaptchaCodeCustomTextBox.BorderRadius = 0;
            this.CaptchaCodeCustomTextBox.BorderSize = 2;
            this.CaptchaCodeCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaCodeCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.CaptchaCodeCustomTextBox.IsFocused = false;
            this.CaptchaCodeCustomTextBox.Location = new System.Drawing.Point(30, 155);
            this.CaptchaCodeCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CaptchaCodeCustomTextBox.MaxLength = 10;
            this.CaptchaCodeCustomTextBox.Multiline = false;
            this.CaptchaCodeCustomTextBox.Name = "CaptchaCodeCustomTextBox";
            this.CaptchaCodeCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CaptchaCodeCustomTextBox.PasswordChar = false;
            this.CaptchaCodeCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.CaptchaCodeCustomTextBox.PlaceHolderText = "Enter Captcha Code";
            this.CaptchaCodeCustomTextBox.ReadOnly = false;
            this.CaptchaCodeCustomTextBox.Size = new System.Drawing.Size(200, 33);
            this.CaptchaCodeCustomTextBox.TabIndex = 44;
            this.CaptchaCodeCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptchaCodeCustomTextBox.TextContent = "";
            this.CaptchaCodeCustomTextBox.UnderlineStyle = true;
            this.CaptchaCodeCustomTextBox.TextChangedEvent += new System.EventHandler(this.CaptchaCodeCustomTextBox_TextChangedEvent);
            // 
            // CaptchaCheckerCustomButton
            // 
            this.CaptchaCheckerCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CaptchaCheckerCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.CaptchaCheckerCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CaptchaCheckerCustomButton.BorderRadius = 10;
            this.CaptchaCheckerCustomButton.BorderSize = 0;
            this.CaptchaCheckerCustomButton.Circular = false;
            this.CaptchaCheckerCustomButton.Enabled = false;
            this.CaptchaCheckerCustomButton.FlatAppearance.BorderSize = 0;
            this.CaptchaCheckerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptchaCheckerCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaCheckerCustomButton.ForeColor = System.Drawing.Color.White;
            this.CaptchaCheckerCustomButton.Location = new System.Drawing.Point(30, 200);
            this.CaptchaCheckerCustomButton.Name = "CaptchaCheckerCustomButton";
            this.CaptchaCheckerCustomButton.Size = new System.Drawing.Size(150, 40);
            this.CaptchaCheckerCustomButton.TabIndex = 46;
            this.CaptchaCheckerCustomButton.Text = "Check Captcha";
            this.CaptchaCheckerCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.CaptchaCheckerCustomButton, "To Check The Code");
            this.CaptchaCheckerCustomButton.UseVisualStyleBackColor = false;
            this.CaptchaCheckerCustomButton.Click += new System.EventHandler(this.CaptchaCheckerCustomButton_Click);
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.Location = new System.Drawing.Point(30, 70);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(200, 50);
            this.CaptchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CaptchaPictureBox.TabIndex = 45;
            this.CaptchaPictureBox.TabStop = false;
            // 
            // CaptchaCodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CaptchaCheckerCustomButton);
            this.Controls.Add(this.CaptchaPictureBox);
            this.Controls.Add(this.CaptchaCodeCustomTextBox);
            this.Controls.Add(this.CaptchaLabel);
            this.Controls.Add(this.RestartCaptchaCustomButton);
            this.Controls.Add(this.CaptchaCodeLabel);
            this.Name = "CaptchaCodeControl";
            this.Size = new System.Drawing.Size(260, 250);
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CaptchaCodeLabel;
        private CustomButton RestartCaptchaCustomButton;
        private System.Windows.Forms.Label CaptchaLabel;
        private CustomTextBox CaptchaCodeCustomTextBox;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.PictureBox CaptchaPictureBox;
        private CustomButton CaptchaCheckerCustomButton;
    }
}
