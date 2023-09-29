using System.Collections.Generic;

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
            this.ContactPanel = new System.Windows.Forms.Panel();
            this.SendButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.SearchBar = new YouChatApp.Controls.SearchBar();
            this.SuspendLayout();
            // 
            // ContactPanel
            // 
            this.ContactPanel.AutoScroll = true;
            this.ContactPanel.Location = new System.Drawing.Point(0, 69);
            this.ContactPanel.Name = "ContactPanel";
            this.ContactPanel.Size = new System.Drawing.Size(801, 284);
            this.ContactPanel.TabIndex = 0;
            // 
            // SendButton
            // 
            this.SendButton.BackgroundImage = global::YouChatApp.Properties.Resources.sendMessage;
            this.SendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SendButton.Location = new System.Drawing.Point(267, 388);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 63);
            this.SendButton.TabIndex = 0;
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RestartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RestartButton.Location = new System.Drawing.Point(398, 388);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(75, 63);
            this.RestartButton.TabIndex = 1;
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel.Location = new System.Drawing.Point(201, 51);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(367, 15);
            this.InstructionLabel.TabIndex = 0;
            this.InstructionLabel.Text = "<You may select up to 3 contacts from your contact list>";
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(456, 3);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(320, 60);
            this.SearchBar.TabIndex = 2;
            this.SearchBar.TextContent = "44545";
            // 
            // ContactSharing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ContactPanel);
            this.Controls.Add(this.SearchBar);
            this.Name = "ContactSharing";
            this.Text = "ContactSharing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ContactPanel;
        private List<ContactControl> ContactControlList;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Label InstructionLabel;
        private Controls.SearchBar SearchBar;
    }
}