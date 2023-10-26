namespace YouChatApp.AttachedFiles
{
    partial class ImageHandler
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UploadedPictureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UploadedPictureRotationButton = new System.Windows.Forms.Button();
            this.LoadedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.MessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadedImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // UploadedPictureOpenFileDialog
            // 
            this.UploadedPictureOpenFileDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UploadedPictureRotationButton
            // 
            this.UploadedPictureRotationButton.BackgroundImage = global::YouChatApp.Properties.Resources.RotatePicture;
            this.UploadedPictureRotationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UploadedPictureRotationButton.Location = new System.Drawing.Point(615, 56);
            this.UploadedPictureRotationButton.Name = "UploadedPictureRotationButton";
            this.UploadedPictureRotationButton.Size = new System.Drawing.Size(75, 62);
            this.UploadedPictureRotationButton.TabIndex = 2;
            this.UploadedPictureRotationButton.UseVisualStyleBackColor = true;
            this.UploadedPictureRotationButton.Click += new System.EventHandler(this.UploadedPictureRotationButton_Click);
            // 
            // LoadedImagePictureBox
            // 
            this.LoadedImagePictureBox.Location = new System.Drawing.Point(177, 99);
            this.LoadedImagePictureBox.Name = "LoadedImagePictureBox";
            this.LoadedImagePictureBox.Size = new System.Drawing.Size(400, 339);
            this.LoadedImagePictureBox.TabIndex = 1;
            this.LoadedImagePictureBox.TabStop = false;
            this.LoadedImagePictureBox.Click += new System.EventHandler(this.LoadedImagePictureBox_Click);
            // 
            // MessageRichTextBox
            // 
            this.MessageRichTextBox.BackColor = System.Drawing.Color.Black;
            this.MessageRichTextBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageRichTextBox.ForeColor = System.Drawing.Color.Silver;
            this.MessageRichTextBox.Location = new System.Drawing.Point(12, 202);
            this.MessageRichTextBox.Name = "MessageRichTextBox";
            this.MessageRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MessageRichTextBox.Size = new System.Drawing.Size(743, 54);
            this.MessageRichTextBox.TabIndex = 39;
            this.MessageRichTextBox.Text = "Here You Write Your Message";
            // 
            // ImageHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MessageRichTextBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.UploadedPictureRotationButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.LoadedImagePictureBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageHandler";
            this.Text = "ImageHandler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadedImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox LoadedImagePictureBox;
        private System.Windows.Forms.Button UploadedPictureRotationButton;
        private System.Windows.Forms.OpenFileDialog UploadedPictureOpenFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.RichTextBox MessageRichTextBox;
    }
}