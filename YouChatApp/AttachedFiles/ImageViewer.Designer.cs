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
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.RotationGroupBox = new System.Windows.Forms.GroupBox();
            this.RotationAngleValueLabel = new System.Windows.Forms.Label();
            this.RotationAngleLabel = new System.Windows.Forms.Label();
            this.RotationTrackBar = new System.Windows.Forms.TrackBar();
            this.ZoomMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.OffsetMousePositionRadioButton = new System.Windows.Forms.RadioButton();
            this.CenterMousePositionRadioButton = new System.Windows.Forms.RadioButton();
            this.CanvasCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.ImageLocationRadioButton = new System.Windows.Forms.RadioButton();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.SettingsPanel.SuspendLayout();
            this.RotationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).BeginInit();
            this.ZoomMethodGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.Black;
            this.SettingsPanel.Controls.Add(this.RotationGroupBox);
            this.SettingsPanel.Controls.Add(this.ZoomMethodGroupBox);
            this.SettingsPanel.Location = new System.Drawing.Point(10, 470);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(760, 120);
            this.SettingsPanel.TabIndex = 1;
            // 
            // RotationGroupBox
            // 
            this.RotationGroupBox.Controls.Add(this.RotationAngleValueLabel);
            this.RotationGroupBox.Controls.Add(this.RotationAngleLabel);
            this.RotationGroupBox.Controls.Add(this.RotationTrackBar);
            this.RotationGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationGroupBox.ForeColor = System.Drawing.Color.White;
            this.RotationGroupBox.Location = new System.Drawing.Point(440, 10);
            this.RotationGroupBox.Name = "RotationGroupBox";
            this.RotationGroupBox.Size = new System.Drawing.Size(300, 100);
            this.RotationGroupBox.TabIndex = 5;
            this.RotationGroupBox.TabStop = false;
            this.RotationGroupBox.Text = "Rotation";
            // 
            // RotationAngleValueLabel
            // 
            this.RotationAngleValueLabel.AutoSize = true;
            this.RotationAngleValueLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationAngleValueLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.RotationAngleValueLabel.Location = new System.Drawing.Point(184, 70);
            this.RotationAngleValueLabel.Name = "RotationAngleValueLabel";
            this.RotationAngleValueLabel.Size = new System.Drawing.Size(19, 21);
            this.RotationAngleValueLabel.TabIndex = 3;
            this.RotationAngleValueLabel.Text = "0";
            // 
            // RotationAngleLabel
            // 
            this.RotationAngleLabel.AutoSize = true;
            this.RotationAngleLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationAngleLabel.Location = new System.Drawing.Point(74, 70);
            this.RotationAngleLabel.Name = "RotationAngleLabel";
            this.RotationAngleLabel.Size = new System.Drawing.Size(119, 21);
            this.RotationAngleLabel.TabIndex = 2;
            this.RotationAngleLabel.Text = "Rotation Angle: ";
            // 
            // RotationTrackBar
            // 
            this.RotationTrackBar.Location = new System.Drawing.Point(25, 25);
            this.RotationTrackBar.Maximum = 360;
            this.RotationTrackBar.Name = "RotationTrackBar";
            this.RotationTrackBar.Size = new System.Drawing.Size(250, 45);
            this.RotationTrackBar.TabIndex = 1;
            this.RotationTrackBar.TickFrequency = 15;
            this.RotationTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.RotationTrackBar.Scroll += new System.EventHandler(this.RotationTrackBar_Scroll);
            // 
            // ZoomMethodGroupBox
            // 
            this.ZoomMethodGroupBox.Controls.Add(this.OffsetMousePositionRadioButton);
            this.ZoomMethodGroupBox.Controls.Add(this.CenterMousePositionRadioButton);
            this.ZoomMethodGroupBox.Controls.Add(this.CanvasCenterRadioButton);
            this.ZoomMethodGroupBox.Controls.Add(this.ImageLocationRadioButton);
            this.ZoomMethodGroupBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomMethodGroupBox.ForeColor = System.Drawing.Color.White;
            this.ZoomMethodGroupBox.Location = new System.Drawing.Point(20, 10);
            this.ZoomMethodGroupBox.Name = "ZoomMethodGroupBox";
            this.ZoomMethodGroupBox.Size = new System.Drawing.Size(400, 100);
            this.ZoomMethodGroupBox.TabIndex = 2;
            this.ZoomMethodGroupBox.TabStop = false;
            this.ZoomMethodGroupBox.Text = "Zoom Methods";
            // 
            // OffsetMousePositionRadioButton
            // 
            this.OffsetMousePositionRadioButton.AutoSize = true;
            this.OffsetMousePositionRadioButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetMousePositionRadioButton.Location = new System.Drawing.Point(170, 60);
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
            this.CenterMousePositionRadioButton.Location = new System.Drawing.Point(170, 30);
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
            this.CanvasCenterRadioButton.Location = new System.Drawing.Point(10, 60);
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
            this.ImageLocationRadioButton.Location = new System.Drawing.Point(10, 30);
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
            this.ImagePictureBox.BackColor = System.Drawing.Color.Black;
            this.ImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePictureBox.Location = new System.Drawing.Point(10, 10);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(760, 450);
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // ImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.ImagePictureBox);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageViewer";
            this.Deactivate += new System.EventHandler(this.ImageViewer_Deactivate);
            this.MouseEnter += new System.EventHandler(this.ImageViewer_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ImageViewer_MouseLeave);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ImageViewer_MouseWheel);
            this.SettingsPanel.ResumeLayout(false);
            this.RotationGroupBox.ResumeLayout(false);
            this.RotationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrackBar)).EndInit();
            this.ZoomMethodGroupBox.ResumeLayout(false);
            this.ZoomMethodGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.GroupBox ZoomMethodGroupBox;
        private System.Windows.Forms.RadioButton ImageLocationRadioButton;
        private System.Windows.Forms.RadioButton OffsetMousePositionRadioButton;
        private System.Windows.Forms.RadioButton CenterMousePositionRadioButton;
        private System.Windows.Forms.RadioButton CanvasCenterRadioButton;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.GroupBox RotationGroupBox;
        private System.Windows.Forms.TrackBar RotationTrackBar;
        private System.Windows.Forms.Label RotationAngleLabel;
        private System.Windows.Forms.Label RotationAngleValueLabel;
    }
}