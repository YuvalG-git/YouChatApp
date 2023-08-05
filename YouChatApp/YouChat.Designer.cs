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
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
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
            this.MessageTextBox.Location = new System.Drawing.Point(15, 965);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.MessageTextBox.Size = new System.Drawing.Size(1300, 30);
            this.MessageTextBox.TabIndex = 3;
            this.MessageTextBox.TextChanged += new System.EventHandler(this.MessageTextBox_TextChanged);
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
            this.MessagePanel.Location = new System.Drawing.Point(0, 0);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(1600, 900);
            this.MessagePanel.TabIndex = 8;
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
            // YouChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1011);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label ChatLabel;
        private System.Windows.Forms.Button NewGroupButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button SendMessageButton;
        public System.Windows.Forms.Panel MessagePanel;
        public List<System.Windows.Forms.Label> MessageLabels;
        private System.Windows.Forms.Button NewContactButton;
    }
}