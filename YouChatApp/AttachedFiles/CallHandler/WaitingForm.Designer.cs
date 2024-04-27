namespace YouChatApp.AttachedFiles.CallHandler
{
    partial class WaitingForm
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
            this.WaitingPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WaitingPictureBox
            // 
            this.WaitingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaitingPictureBox.Image = global::YouChatApp.Properties.Resources.WaitingGif;
            this.WaitingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.WaitingPictureBox.Name = "WaitingPictureBox";
            this.WaitingPictureBox.Size = new System.Drawing.Size(400, 400);
            this.WaitingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WaitingPictureBox.TabIndex = 0;
            this.WaitingPictureBox.TabStop = false;
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ControlBox = false;
            this.Controls.Add(this.WaitingPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "WaitingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SizeChanged += new System.EventHandler(this.WaitingForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WaitingPictureBox;
    }
}