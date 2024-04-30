using System.Collections.Generic;
using YouChatApp.Controls;

namespace YouChatApp.AttachedFiles
{
    partial class ContactSharing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactSharing));
            this.ContactPanel = new System.Windows.Forms.Panel();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.ChosenContactsPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hsdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchBar = new YouChatApp.Controls.SearchBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HeadlinePanel = new System.Windows.Forms.Panel();
            this.ContactSharingHeadlineLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CancelCustomButton = new YouChatApp.Controls.CustomButton();
            this.RestartCustomButton = new YouChatApp.Controls.CustomButton();
            this.ShareContactsCustomButton = new YouChatApp.Controls.CustomButton();
            this.SearchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.HeadlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ContactPanel
            // 
            this.ContactPanel.AutoScroll = true;
            this.ContactPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ContactPanel.Location = new System.Drawing.Point(200, 310);
            this.ContactPanel.Name = "ContactPanel";
            this.ContactPanel.Size = new System.Drawing.Size(350, 320);
            this.ContactPanel.TabIndex = 0;
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel.Location = new System.Drawing.Point(11, 80);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(329, 14);
            this.InstructionLabel.TabIndex = 0;
            this.InstructionLabel.Text = "<You may select up to 3 contacts from your contact list>";
            // 
            // ChosenContactsPanel
            // 
            this.ChosenContactsPanel.AutoScroll = true;
            this.ChosenContactsPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ChosenContactsPanel.Location = new System.Drawing.Point(200, 220);
            this.ChosenContactsPanel.Name = "ChosenContactsPanel";
            this.ChosenContactsPanel.Size = new System.Drawing.Size(350, 90);
            this.ChosenContactsPanel.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // hiToolStripMenuItem
            // 
            this.hiToolStripMenuItem.Name = "hiToolStripMenuItem";
            this.hiToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // hsdfToolStripMenuItem
            // 
            this.hsdfToolStripMenuItem.Name = "hsdfToolStripMenuItem";
            this.hsdfToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.LightBlue;
            this.SearchPanel.Controls.Add(this.InstructionLabel);
            this.SearchPanel.Controls.Add(this.SearchBar);
            this.SearchPanel.Location = new System.Drawing.Point(200, 120);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(350, 100);
            this.SearchPanel.TabIndex = 4;
            // 
            // SearchBar
            // 
            this.SearchBar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.SearchBar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.SearchBar.Location = new System.Drawing.Point(15, 15);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(320, 60);
            this.SearchBar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.RestartCustomButton);
            this.panel1.Controls.Add(this.ShareContactsCustomButton);
            this.panel1.Location = new System.Drawing.Point(200, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 100);
            this.panel1.TabIndex = 5;
            // 
            // HeadlinePanel
            // 
            this.HeadlinePanel.AutoScroll = true;
            this.HeadlinePanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.HeadlinePanel.Controls.Add(this.pictureBox1);
            this.HeadlinePanel.Controls.Add(this.CancelCustomButton);
            this.HeadlinePanel.Controls.Add(this.ContactSharingHeadlineLabel);
            this.HeadlinePanel.Location = new System.Drawing.Point(200, 20);
            this.HeadlinePanel.Name = "HeadlinePanel";
            this.HeadlinePanel.Size = new System.Drawing.Size(350, 100);
            this.HeadlinePanel.TabIndex = 4;
            // 
            // ContactSharingHeadlineLabel
            // 
            this.ContactSharingHeadlineLabel.AutoSize = true;
            this.ContactSharingHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactSharingHeadlineLabel.Location = new System.Drawing.Point(30, 40);
            this.ContactSharingHeadlineLabel.Name = "ContactSharingHeadlineLabel";
            this.ContactSharingHeadlineLabel.Size = new System.Drawing.Size(244, 33);
            this.ContactSharingHeadlineLabel.TabIndex = 0;
            this.ContactSharingHeadlineLabel.Text = "Contact Sharing";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::YouChatApp.Properties.Resources.Sharing;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(275, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CancelCustomButton
            // 
            this.CancelCustomButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.CancelCustomButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.CancelCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.returnArrow;
            this.CancelCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.CancelCustomButton.BorderRadius = 10;
            this.CancelCustomButton.BorderSize = 0;
            this.CancelCustomButton.FlatAppearance.BorderSize = 0;
            this.CancelCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelCustomButton.ForeColor = System.Drawing.Color.White;
            this.CancelCustomButton.Location = new System.Drawing.Point(3, 3);
            this.CancelCustomButton.Name = "CancelCustomButton";
            this.CancelCustomButton.Size = new System.Drawing.Size(60, 30);
            this.CancelCustomButton.TabIndex = 0;
            this.CancelCustomButton.TextColor = System.Drawing.Color.White;
            this.ToolTip.SetToolTip(this.CancelCustomButton, "Press to return to the main window");
            this.CancelCustomButton.UseVisualStyleBackColor = false;
            this.CancelCustomButton.Click += new System.EventHandler(this.CancelCustomButton_Click);
            // 
            // RestartCustomButton
            // 
            this.RestartCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RestartCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RestartCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RestartCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RestartCustomButton.BorderRadius = 10;
            this.RestartCustomButton.BorderSize = 0;
            this.RestartCustomButton.Enabled = false;
            this.RestartCustomButton.FlatAppearance.BorderSize = 0;
            this.RestartCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartCustomButton.ForeColor = System.Drawing.Color.White;
            this.RestartCustomButton.Location = new System.Drawing.Point(205, 20);
            this.RestartCustomButton.Name = "RestartCustomButton";
            this.RestartCustomButton.Size = new System.Drawing.Size(80, 60);
            this.RestartCustomButton.TabIndex = 3;
            this.RestartCustomButton.TextColor = System.Drawing.Color.White;
            this.RestartCustomButton.UseVisualStyleBackColor = false;
            this.RestartCustomButton.Click += new System.EventHandler(this.RestartCustomButton_Click);
            // 
            // ShareContactsCustomButton
            // 
            this.ShareContactsCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ShareContactsCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ShareContactsCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.Share;
            this.ShareContactsCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShareContactsCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ShareContactsCustomButton.BorderRadius = 10;
            this.ShareContactsCustomButton.BorderSize = 0;
            this.ShareContactsCustomButton.Enabled = false;
            this.ShareContactsCustomButton.FlatAppearance.BorderSize = 0;
            this.ShareContactsCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShareContactsCustomButton.ForeColor = System.Drawing.Color.White;
            this.ShareContactsCustomButton.Location = new System.Drawing.Point(65, 20);
            this.ShareContactsCustomButton.Name = "ShareContactsCustomButton";
            this.ShareContactsCustomButton.Size = new System.Drawing.Size(80, 60);
            this.ShareContactsCustomButton.TabIndex = 2;
            this.ShareContactsCustomButton.TextColor = System.Drawing.Color.White;
            this.ShareContactsCustomButton.UseVisualStyleBackColor = false;
            this.ShareContactsCustomButton.Click += new System.EventHandler(this.SendCustomButton_Click);
            // 
            // ContactSharing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 771);
            this.Controls.Add(this.HeadlinePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchPanel);
            this.Controls.Add(this.ContactPanel);
            this.Controls.Add(this.ChosenContactsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContactSharing";
            this.Text = "ContactSharing";
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.HeadlinePanel.ResumeLayout(false);
            this.HeadlinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ContactPanel;
        private List<ContactSharingControl> ContactControlList;
        private List<ProfileControl> ProfileControlList;
        private System.Windows.Forms.Label InstructionLabel;
        private Controls.SearchBar SearchBar;
        private System.Windows.Forms.Panel ChosenContactsPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hsdfToolStripMenuItem;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Panel panel1;
        private CustomButton CancelCustomButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private CustomButton ShareContactsCustomButton;
        private CustomButton RestartCustomButton;
        private System.Windows.Forms.Panel HeadlinePanel;
        private System.Windows.Forms.Label ContactSharingHeadlineLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}