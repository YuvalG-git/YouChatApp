namespace YouChatApp
{
    partial class BanForm
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
            this.components = new System.ComponentModel.Container();
            this.WaitingPictureBox = new System.Windows.Forms.PictureBox();
            this.CountDownTimer = new System.Windows.Forms.Timer(this.components);
            this.CountDownTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WaitingPictureBox
            // 
            this.WaitingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitingPictureBox.Image = global::YouChatApp.Properties.Resources.StopWatch;
            this.WaitingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.WaitingPictureBox.Name = "WaitingPictureBox";
            this.WaitingPictureBox.Size = new System.Drawing.Size(400, 400);
            this.WaitingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WaitingPictureBox.TabIndex = 0;
            this.WaitingPictureBox.TabStop = false;
            this.WaitingPictureBox.SizeChanged += new System.EventHandler(this.WaitingPictureBox_SizeChanged);
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
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ControlBox = false;
            this.Controls.Add(this.CountDownTimeLabel);
            this.Controls.Add(this.WaitingPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "BanForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BanForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.BanForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WaitingPictureBox;
        private System.Windows.Forms.Timer CountDownTimer;
        private System.Windows.Forms.Label CountDownTimeLabel;
    }
}