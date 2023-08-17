using System.Collections.Generic;
using System.Drawing;

namespace YouChatApp
{
    partial class YouChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YouChat));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ChatLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NewContactButton = new System.Windows.Forms.Button();
            this.NewGroupButton = new System.Windows.Forms.Button();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ContactManagementPanel = new System.Windows.Forms.Panel();
            this.HashtagLabel = new System.Windows.Forms.Label();
            this.UserTagLineTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.RequestSender = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IDNameLabel = new System.Windows.Forms.Label();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.CurrentChatPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.MessagePanel.SuspendLayout();
            this.ContactManagementPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vScrollBar1.Location = new System.Drawing.Point(1631, 70);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(13, 980);
            this.vScrollBar1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1647, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 941);
            this.panel1.TabIndex = 2;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTextBox.ForeColor = System.Drawing.Color.Silver;
            this.MessageTextBox.Location = new System.Drawing.Point(15, 965);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTextBox.Size = new System.Drawing.Size(1300, 30);
            this.MessageTextBox.TabIndex = 3;
            this.MessageTextBox.Text = "Here You Write Your Message";
            this.MessageTextBox.TextChanged += new System.EventHandler(this.MessageTextBox_TextChanged);
            this.MessageTextBox.Enter += new System.EventHandler(this.MessageTextBox_Enter);
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            this.MessageTextBox.Leave += new System.EventHandler(this.MessageTextBox_Leave);
            // 
            // ChatLabel
            // 
            this.ChatLabel.AutoSize = true;
            this.ChatLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatLabel.Location = new System.Drawing.Point(1649, 9);
            this.ChatLabel.Name = "ChatLabel";
            this.ChatLabel.Size = new System.Drawing.Size(129, 37);
            this.ChatLabel.TabIndex = 4;
            this.ChatLabel.Text = "CHATS";
            // 
            // NewContactButton
            // 
            this.NewContactButton.BackgroundImage = global::YouChatApp.Properties.Resources.contact;
            this.NewContactButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewContactButton.Location = new System.Drawing.Point(1835, 4);
            this.NewContactButton.Name = "NewContactButton";
            this.NewContactButton.Size = new System.Drawing.Size(60, 60);
            this.NewContactButton.TabIndex = 9;
            this.ToolTip.SetToolTip(this.NewContactButton, "To create a new YouChat group");
            this.NewContactButton.UseVisualStyleBackColor = true;
            this.NewContactButton.Click += new System.EventHandler(this.NewContactButton_Click);
            // 
            // NewGroupButton
            // 
            this.NewGroupButton.BackgroundImage = global::YouChatApp.Properties.Resources.group;
            this.NewGroupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewGroupButton.Location = new System.Drawing.Point(1775, 4);
            this.NewGroupButton.Name = "NewGroupButton";
            this.NewGroupButton.Size = new System.Drawing.Size(60, 60);
            this.NewGroupButton.TabIndex = 5;
            this.ToolTip.SetToolTip(this.NewGroupButton, "To create a new YouChat group");
            this.NewGroupButton.UseVisualStyleBackColor = true;
            // 
            // MessagePanel
            // 
            this.MessagePanel.AutoScroll = true;
            this.MessagePanel.Controls.Add(this.button3);
            this.MessagePanel.Controls.Add(this.button2);
            this.MessagePanel.Location = new System.Drawing.Point(5, 90);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(1600, 852);
            this.MessagePanel.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::YouChatApp.Properties.Resources.DocumentFile;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1425, 789);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 23;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::YouChatApp.Properties.Resources.DrawingFile;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1501, 789);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 22;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ContactManagementPanel
            // 
            this.ContactManagementPanel.Controls.Add(this.HashtagLabel);
            this.ContactManagementPanel.Controls.Add(this.UserTagLineTextBox);
            this.ContactManagementPanel.Controls.Add(this.UserIDTextBox);
            this.ContactManagementPanel.Controls.Add(this.RequestSender);
            this.ContactManagementPanel.Controls.Add(this.label2);
            this.ContactManagementPanel.Controls.Add(this.IDNameLabel);
            this.ContactManagementPanel.Controls.Add(this.UserIDLabel);
            this.ContactManagementPanel.Location = new System.Drawing.Point(1506, 70);
            this.ContactManagementPanel.Name = "ContactManagementPanel";
            this.ContactManagementPanel.Size = new System.Drawing.Size(386, 522);
            this.ContactManagementPanel.TabIndex = 10;
            this.ContactManagementPanel.Visible = false;
            // 
            // HashtagLabel
            // 
            this.HashtagLabel.AutoSize = true;
            this.HashtagLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HashtagLabel.Location = new System.Drawing.Point(128, 446);
            this.HashtagLabel.Name = "HashtagLabel";
            this.HashtagLabel.Size = new System.Drawing.Size(25, 28);
            this.HashtagLabel.TabIndex = 23;
            this.HashtagLabel.Text = "#";
            // 
            // UserTagLineTextBox
            // 
            this.UserTagLineTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTagLineTextBox.ForeColor = System.Drawing.Color.Silver;
            this.UserTagLineTextBox.Location = new System.Drawing.Point(152, 448);
            this.UserTagLineTextBox.Name = "UserTagLineTextBox";
            this.UserTagLineTextBox.Size = new System.Drawing.Size(100, 26);
            this.UserTagLineTextBox.TabIndex = 21;
            this.UserTagLineTextBox.Text = "TAGLINE";
            this.UserTagLineTextBox.Enter += new System.EventHandler(this.UserTagLineTextBox_Enter);
            this.UserTagLineTextBox.Leave += new System.EventHandler(this.UserTagLineTextBox_Leave);
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDTextBox.ForeColor = System.Drawing.Color.Silver;
            this.UserIDTextBox.Location = new System.Drawing.Point(22, 448);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(100, 26);
            this.UserIDTextBox.TabIndex = 4;
            this.UserIDTextBox.Text = "YouChat ID";
            this.UserIDTextBox.Enter += new System.EventHandler(this.UserIDTextBox_Enter);
            this.UserIDTextBox.Leave += new System.EventHandler(this.UserIDTextBox_Leave);
            // 
            // RequestSender
            // 
            this.RequestSender.BackgroundImage = global::YouChatApp.Properties.Resources.Add;
            this.RequestSender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RequestSender.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestSender.Location = new System.Drawing.Point(310, 431);
            this.RequestSender.Name = "RequestSender";
            this.RequestSender.Size = new System.Drawing.Size(55, 55);
            this.RequestSender.TabIndex = 3;
            this.RequestSender.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "#A3V3";
            // 
            // IDNameLabel
            // 
            this.IDNameLabel.AutoSize = true;
            this.IDNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDNameLabel.Location = new System.Drawing.Point(115, 22);
            this.IDNameLabel.Name = "IDNameLabel";
            this.IDNameLabel.Size = new System.Drawing.Size(0, 18);
            this.IDNameLabel.TabIndex = 1;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDLabel.Location = new System.Drawing.Point(30, 22);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(71, 18);
            this.UserIDLabel.TabIndex = 0;
            this.UserIDLabel.Text = "Your ID:";
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(10, 10);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(0, 18);
            this.TimeLabel.TabIndex = 20;
            // 
            // CurrentChatPanel
            // 
            this.CurrentChatPanel.Location = new System.Drawing.Point(5, 5);
            this.CurrentChatPanel.Name = "CurrentChatPanel";
            this.CurrentChatPanel.Size = new System.Drawing.Size(1597, 79);
            this.CurrentChatPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::YouChatApp.Properties.Resources.VideoFile;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1396, 948);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.BackgroundImage = global::YouChatApp.Properties.Resources.sendMessage;
            this.SendMessageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SendMessageButton.Enabled = false;
            this.SendMessageButton.Location = new System.Drawing.Point(1330, 948);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(60, 60);
            this.SendMessageButton.TabIndex = 6;
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackgroundImage = global::YouChatApp.Properties.Resources.UserProfile2;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileButton.Location = new System.Drawing.Point(1853, 954);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(42, 45);
            this.ProfileButton.TabIndex = 0;
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::YouChatApp.Properties.Resources.PictureFile;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1528, 945);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 24;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::YouChatApp.Properties.Resources.UserFile;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1462, 947);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 25;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // YouChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CurrentChatPanel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ContactManagementPanel);
            this.Controls.Add(this.NewContactButton);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.SendMessageButton);
            this.Controls.Add(this.NewGroupButton);
            this.Controls.Add(this.ChatLabel);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.ProfileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YouChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouChat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.YouChat_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YouChat_MouseDown);
            this.MessagePanel.ResumeLayout(false);
            this.ContactManagementPanel.ResumeLayout(false);
            this.ContactManagementPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        public System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label ChatLabel;
        private System.Windows.Forms.Button NewGroupButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button SendMessageButton;
        public System.Windows.Forms.Panel MessagePanel;
        public List<System.Windows.Forms.Label> MessageLabels;
        public List<MessageControl> MessageControls;
        private System.Windows.Forms.Button NewContactButton;
        private System.Windows.Forms.Panel ContactManagementPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IDNameLabel;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button RequestSender;
        private System.Windows.Forms.TextBox UserTagLineTextBox;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.Label HashtagLabel;
        private System.Windows.Forms.Panel CurrentChatPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}