namespace YouChatApp.Controls
{
    partial class BanControl
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
            this.BanPictureBox = new System.Windows.Forms.PictureBox();
            this.CountDownTimer = new System.Windows.Forms.Timer(this.components);
            this.CountDownTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BanPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BanPictureBox
            // 
            this.BanPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPictureBox.Image = global::YouChatApp.Properties.Resources.StopWatch;
            this.BanPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BanPictureBox.Name = "WaitingPictureBox";
            this.BanPictureBox.Size = new System.Drawing.Size(400, 400);
            this.BanPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BanPictureBox.TabIndex = 0;
            this.BanPictureBox.TabStop = false;
            // 
            // CountDownTimer
            // 
            this.CountDownTimer.Interval = 77;
            this.CountDownTimer.Tick += new System.EventHandler(this.CountDownTimer_Tick);
            // 
            // CountDownTimeLabel
            // 
            this.CountDownTimeLabel.AutoSize = true;
            this.CountDownTimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDownTimeLabel.Location = new System.Drawing.Point(129, 365);
            this.CountDownTimeLabel.Name = "CountDownTimeLabel";
            this.CountDownTimeLabel.Size = new System.Drawing.Size(146, 28);
            this.CountDownTimeLabel.TabIndex = 22;
            this.CountDownTimeLabel.Text = "CountDown";
            this.CountDownTimeLabel.Visible = false;
            // 
            // BanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CountDownTimeLabel);
            this.Controls.Add(this.BanPictureBox);
            this.Name = "BanControl";
            this.Size = new System.Drawing.Size(400, 400);
            ((System.ComponentModel.ISupportInitialize)(this.BanPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BanPictureBox;
        private System.Windows.Forms.Timer CountDownTimer;
        private System.Windows.Forms.Label CountDownTimeLabel;
    }
}
