namespace YouChatApp.Controls
{
    partial class CaptchaRotatingImageControl
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
            this.CaptchaPicturesScoreLabel = new System.Windows.Forms.Label();
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.CaptchaCodeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CaptchaCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.CaptchaCheckerCustomButton = new YouChatApp.Controls.CustomButton();
            this.RefreshLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptchaPicturesScoreLabel
            // 
            this.CaptchaPicturesScoreLabel.AutoSize = true;
            this.CaptchaPicturesScoreLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaPicturesScoreLabel.Location = new System.Drawing.Point(47, 255);
            this.CaptchaPicturesScoreLabel.Name = "CaptchaPicturesScoreLabel";
            this.CaptchaPicturesScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CaptchaPicturesScoreLabel.Size = new System.Drawing.Size(61, 18);
            this.CaptchaPicturesScoreLabel.TabIndex = 26;
            this.CaptchaPicturesScoreLabel.Text = "Score:";
            this.CaptchaPicturesScoreLabel.Click += new System.EventHandler(this.CaptchaPicturesScoreLabel_Click);
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptchaPictureBox.Location = new System.Drawing.Point(5, 5);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(150, 150);
            this.CaptchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptchaPictureBox.TabIndex = 36;
            this.CaptchaPictureBox.TabStop = false;
            this.CaptchaPictureBox.Click += new System.EventHandler(this.CaptchaPictureBox_Click);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.AutoSize = true;
            this.InstructionsLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLabel.Location = new System.Drawing.Point(21, 60);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(218, 15);
            this.InstructionsLabel.TabIndex = 37;
            this.InstructionsLabel.Text = "To succeed answer 3/5 correctly";
            // 
            // CaptchaCodeLabel
            // 
            this.CaptchaCodeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaCodeLabel.Location = new System.Drawing.Point(30, 10);
            this.CaptchaCodeLabel.Name = "CaptchaCodeLabel";
            this.CaptchaCodeLabel.Size = new System.Drawing.Size(200, 50);
            this.CaptchaCodeLabel.TabIndex = 38;
            this.CaptchaCodeLabel.Text = "CAPTCHA";
            this.CaptchaCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CaptchaCircularPictureBox);
            this.panel1.Controls.Add(this.CaptchaPictureBox);
            this.panel1.Location = new System.Drawing.Point(50, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 160);
            this.panel1.TabIndex = 48;
            // 
            // CaptchaCircularPictureBox
            // 
            this.CaptchaCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptchaCircularPictureBox.BorderColor = System.Drawing.Color.Gray;
            this.CaptchaCircularPictureBox.BorderSize = 1;
            this.CaptchaCircularPictureBox.HasBorder = false;
            this.CaptchaCircularPictureBox.Location = new System.Drawing.Point(5, 5);
            this.CaptchaCircularPictureBox.Name = "CaptchaCircularPictureBox";
            this.CaptchaCircularPictureBox.Size = new System.Drawing.Size(150, 150);
            this.CaptchaCircularPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptchaCircularPictureBox.TabIndex = 35;
            this.CaptchaCircularPictureBox.TabStop = false;
            this.CaptchaCircularPictureBox.BackgroundImageChanged += new System.EventHandler(this.CaptchaCircularPictureBox_BackgroundImageChanged);
            this.CaptchaCircularPictureBox.Click += new System.EventHandler(this.CaptchaCircularPictureBox_Click);
            // 
            // CaptchaCheckerCustomButton
            // 
            this.CaptchaCheckerCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.CaptchaCheckerCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.CaptchaCheckerCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CaptchaCheckerCustomButton.BorderRadius = 10;
            this.CaptchaCheckerCustomButton.BorderSize = 0;
            this.CaptchaCheckerCustomButton.Circular = false;
            this.CaptchaCheckerCustomButton.FlatAppearance.BorderSize = 0;
            this.CaptchaCheckerCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptchaCheckerCustomButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaCheckerCustomButton.ForeColor = System.Drawing.Color.White;
            this.CaptchaCheckerCustomButton.Location = new System.Drawing.Point(50, 280);
            this.CaptchaCheckerCustomButton.Name = "CaptchaCheckerCustomButton";
            this.CaptchaCheckerCustomButton.Size = new System.Drawing.Size(160, 40);
            this.CaptchaCheckerCustomButton.TabIndex = 47;
            this.CaptchaCheckerCustomButton.Text = "Check Captcha";
            this.CaptchaCheckerCustomButton.TextColor = System.Drawing.Color.White;
            this.CaptchaCheckerCustomButton.UseVisualStyleBackColor = false;
            this.CaptchaCheckerCustomButton.Click += new System.EventHandler(this.CaptchaCheckerCustomButton_Click);
            // 
            // RefreshLabel
            // 
            this.RefreshLabel.AutoSize = true;
            this.RefreshLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshLabel.Location = new System.Drawing.Point(34, 88);
            this.RefreshLabel.Name = "RefreshLabel";
            this.RefreshLabel.Size = new System.Drawing.Size(196, 30);
            this.RefreshLabel.TabIndex = 49;
            this.RefreshLabel.Text = "Press Check Captcha Button!\r\nToo many rotation attempts!";
            this.RefreshLabel.Visible = false;
            // 
            // CaptchaRotatingImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.RefreshLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CaptchaCheckerCustomButton);
            this.Controls.Add(this.CaptchaCodeLabel);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.CaptchaPicturesScoreLabel);
            this.Name = "CaptchaRotatingImageControl";
            this.Size = new System.Drawing.Size(260, 330);
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaCircularPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label CaptchaPicturesScoreLabel;
        private CircularPictureBox CaptchaCircularPictureBox;
        private System.Windows.Forms.PictureBox CaptchaPictureBox;
        private System.Windows.Forms.Label InstructionsLabel;
        private System.Windows.Forms.Label CaptchaCodeLabel;
        private CustomButton CaptchaCheckerCustomButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label RefreshLabel;
    }
}
