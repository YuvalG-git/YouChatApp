namespace YouChatApp.AttachedFiles
{
    partial class ImageViewer
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
            this.ZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.ZoomScaleGroupBox = new System.Windows.Forms.GroupBox();
            this.ZoomMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.OffsetMousePositionRadioButton = new System.Windows.Forms.RadioButton();
            this.CenterMousePositionRadioButton = new System.Windows.Forms.RadioButton();
            this.CanvasCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.ImageLocationRadioButton = new System.Windows.Forms.RadioButton();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.RotationGroupBox = new System.Windows.Forms.GroupBox();
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).BeginInit();
            this.SettingsPanel.SuspendLayout();
            this.ZoomScaleGroupBox.SuspendLayout();
            this.ZoomMethodGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.RotationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ZoomTrackBar
            // 
            this.ZoomTrackBar.LargeChange = 10;
            this.ZoomTrackBar.Location = new System.Drawing.Point(21, 27);
            this.ZoomTrackBar.Maximum = 50;
            this.ZoomTrackBar.Name = "ZoomTrackBar";
            this.ZoomTrackBar.Size = new System.Drawing.Size(223, 45);
            this.ZoomTrackBar.TabIndex = 1;
            this.ZoomTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ZoomTrackBar.Scroll += new System.EventHandler(this.ZoomTrackBar_Scroll);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.RotationGroupBox);
            this.SettingsPanel.Controls.Add(this.ZoomScaleGroupBox);
            this.SettingsPanel.Controls.Add(this.ZoomMethodGroupBox);
            this.SettingsPanel.Location = new System.Drawing.Point(13, 413);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(764, 236);
            this.SettingsPanel.TabIndex = 1;
            // 
            // ZoomScaleGroupBox
            // 
            this.ZoomScaleGroupBox.Controls.Add(this.ZoomTrackBar);
            this.ZoomScaleGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomScaleGroupBox.ForeColor = System.Drawing.Color.White;
            this.ZoomScaleGroupBox.Location = new System.Drawing.Point(342, 111);
            this.ZoomScaleGroupBox.Name = "ZoomScaleGroupBox";
            this.ZoomScaleGroupBox.Size = new System.Drawing.Size(293, 78);
            this.ZoomScaleGroupBox.TabIndex = 4;
            this.ZoomScaleGroupBox.TabStop = false;
            this.ZoomScaleGroupBox.Text = "Zoom Scale:";
            // 
            // ZoomMethodGroupBox
            // 
            this.ZoomMethodGroupBox.Controls.Add(this.OffsetMousePositionRadioButton);
            this.ZoomMethodGroupBox.Controls.Add(this.CenterMousePositionRadioButton);
            this.ZoomMethodGroupBox.Controls.Add(this.CanvasCenterRadioButton);
            this.ZoomMethodGroupBox.Controls.Add(this.ImageLocationRadioButton);
            this.ZoomMethodGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomMethodGroupBox.ForeColor = System.Drawing.Color.White;
            this.ZoomMethodGroupBox.Location = new System.Drawing.Point(342, 17);
            this.ZoomMethodGroupBox.Name = "ZoomMethodGroupBox";
            this.ZoomMethodGroupBox.Size = new System.Drawing.Size(377, 88);
            this.ZoomMethodGroupBox.TabIndex = 2;
            this.ZoomMethodGroupBox.TabStop = false;
            this.ZoomMethodGroupBox.Text = "Zoom Methods:";
            // 
            // OffsetMousePositionRadioButton
            // 
            this.OffsetMousePositionRadioButton.AutoSize = true;
            this.OffsetMousePositionRadioButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetMousePositionRadioButton.Location = new System.Drawing.Point(168, 57);
            this.OffsetMousePositionRadioButton.Name = "OffsetMousePositionRadioButton";
            this.OffsetMousePositionRadioButton.Size = new System.Drawing.Size(196, 25);
            this.OffsetMousePositionRadioButton.TabIndex = 3;
            this.OffsetMousePositionRadioButton.TabStop = true;
            this.OffsetMousePositionRadioButton.Tag = "3";
            this.OffsetMousePositionRadioButton.Text = "Offset To Mouse Position";
            this.OffsetMousePositionRadioButton.UseVisualStyleBackColor = true;
            this.OffsetMousePositionRadioButton.CheckedChanged += new System.EventHandler(this.ZoomRadioButton_CheckedChanged);
            // 
            // CenterMousePositionRadioButton
            // 
            this.CenterMousePositionRadioButton.AutoSize = true;
            this.CenterMousePositionRadioButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CenterMousePositionRadioButton.Location = new System.Drawing.Point(168, 30);
            this.CenterMousePositionRadioButton.Name = "CenterMousePositionRadioButton";
            this.CenterMousePositionRadioButton.Size = new System.Drawing.Size(203, 25);
            this.CenterMousePositionRadioButton.TabIndex = 2;
            this.CenterMousePositionRadioButton.TabStop = true;
            this.CenterMousePositionRadioButton.Tag = "2";
            this.CenterMousePositionRadioButton.Text = "Center On Mouse Position";
            this.CenterMousePositionRadioButton.UseVisualStyleBackColor = true;
            this.CenterMousePositionRadioButton.CheckedChanged += new System.EventHandler(this.ZoomRadioButton_CheckedChanged);
            // 
            // CanvasCenterRadioButton
            // 
            this.CanvasCenterRadioButton.AutoSize = true;
            this.CanvasCenterRadioButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanvasCenterRadioButton.Location = new System.Drawing.Point(6, 57);
            this.CanvasCenterRadioButton.Name = "CanvasCenterRadioButton";
            this.CanvasCenterRadioButton.Size = new System.Drawing.Size(126, 25);
            this.CanvasCenterRadioButton.TabIndex = 1;
            this.CanvasCenterRadioButton.TabStop = true;
            this.CanvasCenterRadioButton.Tag = "1";
            this.CanvasCenterRadioButton.Text = "Canvas Center";
            this.CanvasCenterRadioButton.UseVisualStyleBackColor = true;
            this.CanvasCenterRadioButton.CheckedChanged += new System.EventHandler(this.ZoomRadioButton_CheckedChanged);
            // 
            // ImageLocationRadioButton
            // 
            this.ImageLocationRadioButton.AutoSize = true;
            this.ImageLocationRadioButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageLocationRadioButton.Location = new System.Drawing.Point(6, 30);
            this.ImageLocationRadioButton.Name = "ImageLocationRadioButton";
            this.ImageLocationRadioButton.Size = new System.Drawing.Size(133, 25);
            this.ImageLocationRadioButton.TabIndex = 0;
            this.ImageLocationRadioButton.TabStop = true;
            this.ImageLocationRadioButton.Tag = "0";
            this.ImageLocationRadioButton.Text = "Image Location";
            this.ImageLocationRadioButton.UseVisualStyleBackColor = true;
            this.ImageLocationRadioButton.CheckedChanged += new System.EventHandler(this.ZoomRadioButton_CheckedChanged);
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Location = new System.Drawing.Point(18, 12);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(759, 391);
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // RotationGroupBox
            // 
            this.RotationGroupBox.Controls.Add(this.RotationTrackBar);
            this.RotationGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationGroupBox.ForeColor = System.Drawing.Color.White;
            this.RotationGroupBox.Location = new System.Drawing.Point(18, 17);
            this.RotationGroupBox.Name = "RotationGroupBox";
            this.RotationGroupBox.Size = new System.Drawing.Size(293, 88);
            this.RotationGroupBox.TabIndex = 5;
            this.RotationGroupBox.TabStop = false;
            this.RotationGroupBox.Text = "Rotation:";
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.LargeChange = 10;
            this.RotationTrackBar.Location = new System.Drawing.Point(34, 30);
            this.RotationTrackBar.Maximum = 360;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(223, 45);
            this.RotationTrackBar.TabIndex = 1;
            this.RotationTrackBar.TickFrequency = 15;
            this.RotationTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.RotationTrackBar.Scroll += new System.EventHandler(this.RotationTrackBar_Scroll);
            // 
            // ImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.ImagePictureBox);
            this.Controls.Add(this.SettingsPanel);
            this.Name = "ImageViewer";
            this.Text = "ImageViewer";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ImageViewer_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).EndInit();
            this.SettingsPanel.ResumeLayout(false);
            this.ZoomScaleGroupBox.ResumeLayout(false);
            this.ZoomScaleGroupBox.PerformLayout();
            this.ZoomMethodGroupBox.ResumeLayout(false);
            this.ZoomMethodGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.RotationGroupBox.ResumeLayout(false);
            this.RotationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TrackBar ZoomTrackBar;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.GroupBox ZoomMethodGroupBox;
        private System.Windows.Forms.RadioButton ImageLocationRadioButton;
        private System.Windows.Forms.RadioButton OffsetMousePositionRadioButton;
        private System.Windows.Forms.RadioButton CenterMousePositionRadioButton;
        private System.Windows.Forms.RadioButton CanvasCenterRadioButton;
        private System.Windows.Forms.GroupBox ZoomScaleGroupBox;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.GroupBox RotationGroupBox;
        private System.Windows.Forms.TrackBar RotationTrackBar;
    }
}