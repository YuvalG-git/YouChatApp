namespace YouChatApp
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.PaintMenuStrip = new System.Windows.Forms.MenuStrip();
            this.PaintFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintToolStrip = new System.Windows.Forms.ToolStrip();
            this.FirstColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SecondColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ThirdColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FourthColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PenSizeToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.PenSizeValue5ToolStripDropDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PenSizeValue10ToolStripDropDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PenSizeValue15ToolStripDropDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintColorDialog = new System.Windows.Forms.ColorDialog();
            this.PaintOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PaintSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.DrawingBoardPictureBox = new System.Windows.Forms.PictureBox();
            this.MultiColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BackgroundColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintMenuStrip.SuspendLayout();
            this.PaintToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBoardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PaintMenuStrip
            // 
            this.PaintMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PaintFileToolStripMenuItem});
            this.PaintMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.PaintMenuStrip.Name = "PaintMenuStrip";
            this.PaintMenuStrip.Size = new System.Drawing.Size(800, 29);
            this.PaintMenuStrip.TabIndex = 0;
            this.PaintMenuStrip.Text = "menuStrip1";
            // 
            // PaintFileToolStripMenuItem
            // 
            this.PaintFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveOptionToolStripMenuItem,
            this.OpenOptionToolStripMenuItem,
            this.DeleteOptionToolStripMenuItem,
            this.SendOptionToolStripMenuItem});
            this.PaintFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaintFileToolStripMenuItem.Name = "PaintFileToolStripMenuItem";
            this.PaintFileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.PaintFileToolStripMenuItem.Text = "File";
            // 
            // PaintToolStrip
            // 
            this.PaintToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstColorOptionToolStripButton,
            this.SecondColorOptionToolStripButton,
            this.ThirdColorOptionToolStripButton,
            this.FourthColorOptionToolStripButton,
            this.MultiColorOptionToolStripButton,
            this.PenSizeToolStripDropDownButton,
            this.BackgroundColorToolStripButton});
            this.PaintToolStrip.Location = new System.Drawing.Point(0, 29);
            this.PaintToolStrip.Name = "PaintToolStrip";
            this.PaintToolStrip.Size = new System.Drawing.Size(800, 25);
            this.PaintToolStrip.TabIndex = 1;
            this.PaintToolStrip.Text = "toolStrip1";
            // 
            // FirstColorOptionToolStripButton
            // 
            this.FirstColorOptionToolStripButton.BackColor = System.Drawing.Color.Black;
            this.FirstColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstColorOptionToolStripButton.Name = "FirstColorOptionToolStripButton";
            this.FirstColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.FirstColorOptionToolStripButton.Text = "toolStripButton1";
            this.FirstColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // SecondColorOptionToolStripButton
            // 
            this.SecondColorOptionToolStripButton.BackColor = System.Drawing.Color.Red;
            this.SecondColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SecondColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SecondColorOptionToolStripButton.Name = "SecondColorOptionToolStripButton";
            this.SecondColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SecondColorOptionToolStripButton.Text = "toolStripButton2";
            this.SecondColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // ThirdColorOptionToolStripButton
            // 
            this.ThirdColorOptionToolStripButton.BackColor = System.Drawing.Color.Green;
            this.ThirdColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ThirdColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThirdColorOptionToolStripButton.Name = "ThirdColorOptionToolStripButton";
            this.ThirdColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ThirdColorOptionToolStripButton.Text = "toolStripButton3";
            this.ThirdColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // FourthColorOptionToolStripButton
            // 
            this.FourthColorOptionToolStripButton.BackColor = System.Drawing.Color.Blue;
            this.FourthColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FourthColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FourthColorOptionToolStripButton.Name = "FourthColorOptionToolStripButton";
            this.FourthColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.FourthColorOptionToolStripButton.Text = "toolStripButton4";
            this.FourthColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // PenSizeToolStripDropDownButton
            // 
            this.PenSizeToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PenSizeToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenSizeValue5ToolStripDropDownButton,
            this.PenSizeValue10ToolStripDropDownButton,
            this.PenSizeValue15ToolStripDropDownButton});
            this.PenSizeToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PenSizeToolStripDropDownButton.Name = "PenSizeToolStripDropDownButton";
            this.PenSizeToolStripDropDownButton.Size = new System.Drawing.Size(63, 22);
            this.PenSizeToolStripDropDownButton.Text = "Pen Size";
            // 
            // PenSizeValue5ToolStripDropDownButton
            // 
            this.PenSizeValue5ToolStripDropDownButton.Name = "PenSizeValue5ToolStripDropDownButton";
            this.PenSizeValue5ToolStripDropDownButton.Size = new System.Drawing.Size(86, 22);
            this.PenSizeValue5ToolStripDropDownButton.Text = "5";
            this.PenSizeValue5ToolStripDropDownButton.Click += new System.EventHandler(this.PenSizeChangeValue_Click);
            // 
            // PenSizeValue10ToolStripDropDownButton
            // 
            this.PenSizeValue10ToolStripDropDownButton.Name = "PenSizeValue10ToolStripDropDownButton";
            this.PenSizeValue10ToolStripDropDownButton.Size = new System.Drawing.Size(86, 22);
            this.PenSizeValue10ToolStripDropDownButton.Text = "10";
            this.PenSizeValue10ToolStripDropDownButton.Click += new System.EventHandler(this.PenSizeChangeValue_Click);
            // 
            // PenSizeValue15ToolStripDropDownButton
            // 
            this.PenSizeValue15ToolStripDropDownButton.Name = "PenSizeValue15ToolStripDropDownButton";
            this.PenSizeValue15ToolStripDropDownButton.Size = new System.Drawing.Size(86, 22);
            this.PenSizeValue15ToolStripDropDownButton.Text = "15";
            this.PenSizeValue15ToolStripDropDownButton.Click += new System.EventHandler(this.PenSizeChangeValue_Click);
            // 
            // PaintOpenFileDialog
            // 
            this.PaintOpenFileDialog.FileName = "openFileDialog1";
            // 
            // DrawingBoardPictureBox
            // 
            this.DrawingBoardPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DrawingBoardPictureBox.Location = new System.Drawing.Point(0, 52);
            this.DrawingBoardPictureBox.Name = "DrawingBoardPictureBox";
            this.DrawingBoardPictureBox.Size = new System.Drawing.Size(800, 400);
            this.DrawingBoardPictureBox.TabIndex = 2;
            this.DrawingBoardPictureBox.TabStop = false;
            this.DrawingBoardPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseClick);
            this.DrawingBoardPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseState);
            this.DrawingBoardPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseMove);
            this.DrawingBoardPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseState);
            // 
            // MultiColorOptionToolStripButton
            // 
            this.MultiColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MultiColorOptionToolStripButton.Image = global::YouChatApp.Properties.Resources.colors;
            this.MultiColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MultiColorOptionToolStripButton.Name = "MultiColorOptionToolStripButton";
            this.MultiColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.MultiColorOptionToolStripButton.Text = "toolStripButton5";
            this.MultiColorOptionToolStripButton.Click += new System.EventHandler(this.MultiColorOptionToolStripButton_Click);
            // 
            // BackgroundColorToolStripButton
            // 
            this.BackgroundColorToolStripButton.Image = global::YouChatApp.Properties.Resources.BackgroundColor;
            this.BackgroundColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackgroundColorToolStripButton.Name = "BackgroundColorToolStripButton";
            this.BackgroundColorToolStripButton.Size = new System.Drawing.Size(123, 22);
            this.BackgroundColorToolStripButton.Text = "Background Color";
            this.BackgroundColorToolStripButton.Click += new System.EventHandler(this.BackgroundColorToolStripButton_Click);
            // 
            // SaveOptionToolStripMenuItem
            // 
            this.SaveOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.SaveOption;
            this.SaveOptionToolStripMenuItem.Name = "SaveOptionToolStripMenuItem";
            this.SaveOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.SaveOptionToolStripMenuItem.Text = "Save";
            this.SaveOptionToolStripMenuItem.Click += new System.EventHandler(this.SaveOptionToolStripMenuItem_Click);
            // 
            // OpenOptionToolStripMenuItem
            // 
            this.OpenOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.OpenOption;
            this.OpenOptionToolStripMenuItem.Name = "OpenOptionToolStripMenuItem";
            this.OpenOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.OpenOptionToolStripMenuItem.Text = "Open";
            this.OpenOptionToolStripMenuItem.Click += new System.EventHandler(this.OpenOptionToolStripMenuItem_Click);
            // 
            // DeleteOptionToolStripMenuItem
            // 
            this.DeleteOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.DeleteOption1;
            this.DeleteOptionToolStripMenuItem.Name = "DeleteOptionToolStripMenuItem";
            this.DeleteOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.DeleteOptionToolStripMenuItem.Text = "Delete";
            this.DeleteOptionToolStripMenuItem.Click += new System.EventHandler(this.DeleteOptionToolStripMenuItem_Click);
            // 
            // SendOptionToolStripMenuItem
            // 
            this.SendOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.SendOption1;
            this.SendOptionToolStripMenuItem.Name = "SendOptionToolStripMenuItem";
            this.SendOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.SendOptionToolStripMenuItem.Text = "Send";
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DrawingBoardPictureBox);
            this.Controls.Add(this.PaintToolStrip);
            this.Controls.Add(this.PaintMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.PaintMenuStrip;
            this.Name = "Paint";
            this.Text = "Paint";
            this.PaintMenuStrip.ResumeLayout(false);
            this.PaintMenuStrip.PerformLayout();
            this.PaintToolStrip.ResumeLayout(false);
            this.PaintToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBoardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip PaintMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PaintFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip PaintToolStrip;
        private System.Windows.Forms.ToolStripButton FirstColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton SecondColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton ThirdColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton MultiColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton PenSizeToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem PenSizeValue5ToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem PenSizeValue10ToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem PenSizeValue15ToolStripDropDownButton;
        private System.Windows.Forms.ColorDialog PaintColorDialog;
        private System.Windows.Forms.PictureBox DrawingBoardPictureBox;
        private System.Windows.Forms.ToolStripButton FourthColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteOptionToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog PaintOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog PaintSaveFileDialog;
        private System.Windows.Forms.ToolStripButton BackgroundColorToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem SendOptionToolStripMenuItem;
    }
}