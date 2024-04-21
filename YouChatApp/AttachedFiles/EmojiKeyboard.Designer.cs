using System.Collections.Generic;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles
{
    partial class EmojiKeyboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmojiKeyboard));
            this.TabImageList = new System.Windows.Forms.ImageList(this.components);
            this.EmojiTimer = new System.Windows.Forms.Timer(this.components);
            this.EmojiTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // TabImageList
            // 
            this.TabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabImageList.ImageStream")));
            this.TabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TabImageList.Images.SetKeyName(0, "1f600.png");
            this.TabImageList.Images.SetKeyName(1, "1f466-1f3fb.png");
            this.TabImageList.Images.SetKeyName(2, "1f43b.png");
            this.TabImageList.Images.SetKeyName(3, "2615.png");
            this.TabImageList.Images.SetKeyName(4, "26bd.png");
            this.TabImageList.Images.SetKeyName(5, "1f698.png");
            this.TabImageList.Images.SetKeyName(6, "1f4a1.png");
            this.TabImageList.Images.SetKeyName(7, "1f523.png");
            this.TabImageList.Images.SetKeyName(8, "1f3f4.png");
            // 
            // EmojiTimer
            // 
            this.EmojiTimer.Interval = 1000;
            // 
            // EmojiTabControl
            // 
            this.EmojiTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmojiTabControl.HotTrack = true;
            this.EmojiTabControl.ImageList = this.TabImageList;
            this.EmojiTabControl.ItemSize = new System.Drawing.Size(20, 36);
            this.EmojiTabControl.Location = new System.Drawing.Point(0, 0);
            this.EmojiTabControl.Multiline = true;
            this.EmojiTabControl.Name = "EmojiTabControl";
            this.EmojiTabControl.SelectedIndex = 0;
            this.EmojiTabControl.Size = new System.Drawing.Size(884, 462);
            this.EmojiTabControl.TabIndex = 0;
            // 
            // EmojiKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.EmojiTabControl);
            this.Name = "EmojiKeyboard";
            this.Text = "EmojiKeyboard";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage[] EmojiCategoryTabPage;
        private System.Windows.Forms.Panel[] EmojiCategoryPanel;
        private System.Windows.Forms.ImageList TabImageList;
        private List<System.Windows.Forms.PictureBox>[] EmojiPictureBoxArrayOfLists;
        private List<System.Windows.Forms.Panel> PeopleEmojiPanelList;
        private List<List<System.Windows.Forms.PictureBox>> PeopleEmojiPictureBoxListOfLists;
        private Timer EmojiTimer;
        private TabControl EmojiTabControl;
    }
}