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
            this.EmojiTabControl = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TabImageList = new System.Windows.Forms.ImageList(this.components);
            this.EmojiTimer = new System.Windows.Forms.Timer(this.components);
            this.EmojiTabControl.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmojiTabControl
            // 
            this.EmojiTabControl.Controls.Add(this.TabPage1);
            this.EmojiTabControl.Controls.Add(this.TabPage2);
            this.EmojiTabControl.Controls.Add(this.tabPage3);
            this.EmojiTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmojiTabControl.HotTrack = true;
            this.EmojiTabControl.ImageList = this.TabImageList;
            this.EmojiTabControl.ItemSize = new System.Drawing.Size(20, 36);
            this.EmojiTabControl.Location = new System.Drawing.Point(0, 0);
            this.EmojiTabControl.Multiline = true;
            this.EmojiTabControl.Name = "EmojiTabControl";
            this.EmojiTabControl.SelectedIndex = 0;
            this.EmojiTabControl.Size = new System.Drawing.Size(799, 450);
            this.EmojiTabControl.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabPage1.Controls.Add(this.flowLayoutPanel1);
            this.TabPage1.Controls.Add(this.button2);
            this.TabPage1.ImageIndex = 0;
            this.TabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TabPage1.Location = new System.Drawing.Point(4, 40);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(791, 406);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(288, 184);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Visible = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            this.flowLayoutPanel1.MouseEnter += new System.EventHandler(this.flowLayoutPanel1_MouseEnter);
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // TabPage2
            // 
            this.TabPage2.ImageIndex = 1;
            this.TabPage2.Location = new System.Drawing.Point(4, 40);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(791, 406);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(791, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(95, 150);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::YouChatApp.Properties.Resources.colors;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(219, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 43);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.Location = new System.Drawing.Point(403, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(318, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBox1_ContentsResized);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
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
            // EmojiKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EmojiTabControl);
            this.Name = "EmojiKeyboard";
            this.Text = "EmojiKeyboard";
            this.EmojiTabControl.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl EmojiTabControl;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage[] EmojiCategoryTabPage;
        private System.Windows.Forms.Panel[] EmojiCategoryPanel;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ImageList TabImageList;
        private List<System.Windows.Forms.PictureBox>[] EmojiPictureBoxArrayOfLists;
        private List<System.Windows.Forms.Panel> PeopleEmojiPanelList;
        private List<List<System.Windows.Forms.PictureBox>> PeopleEmojiPictureBoxListOfLists;


        private WebBrowser webBrowser1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Timer EmojiTimer;
    }
}