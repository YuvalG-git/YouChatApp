namespace YouChatApp.Controls
{
    partial class ProfileStatusControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CharNumberLabel = new System.Windows.Forms.Label();
            this.StatusTextPanel = new System.Windows.Forms.Panel();
            this.CurrentStatusLabel = new System.Windows.Forms.Label();
            this.StatusMainPanel = new System.Windows.Forms.Panel();
            this.ProfileStatusCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            this.SaveStatusCustomButton = new YouChatApp.Controls.CustomButton();
            this.RefreshStatusCustomButton = new YouChatApp.Controls.CustomButton();
            this.StatusHeadlineLabel = new System.Windows.Forms.Label();
            this.StatusTextPanel.SuspendLayout();
            this.StatusMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CharNumberLabel
            // 
            this.CharNumberLabel.AutoSize = true;
            this.CharNumberLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharNumberLabel.Location = new System.Drawing.Point(7, 87);
            this.CharNumberLabel.Name = "CharNumberLabel";
            this.CharNumberLabel.Size = new System.Drawing.Size(38, 14);
            this.CharNumberLabel.TabIndex = 7;
            this.CharNumberLabel.Text = "0/150";
            // 
            // StatusTextPanel
            // 
            this.StatusTextPanel.AutoScroll = true;
            this.StatusTextPanel.Controls.Add(this.CurrentStatusLabel);
            this.StatusTextPanel.Location = new System.Drawing.Point(10, 50);
            this.StatusTextPanel.MaximumSize = new System.Drawing.Size(300, 200);
            this.StatusTextPanel.MinimumSize = new System.Drawing.Size(300, 0);
            this.StatusTextPanel.Name = "StatusTextPanel";
            this.StatusTextPanel.Size = new System.Drawing.Size(300, 100);
            this.StatusTextPanel.TabIndex = 16;
            // 
            // CurrentStatusLabel
            // 
            this.CurrentStatusLabel.AutoEllipsis = true;
            this.CurrentStatusLabel.AutoSize = true;
            this.CurrentStatusLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentStatusLabel.Location = new System.Drawing.Point(1, 0);
            this.CurrentStatusLabel.MaximumSize = new System.Drawing.Size(250, 200);
            this.CurrentStatusLabel.MinimumSize = new System.Drawing.Size(250, 0);
            this.CurrentStatusLabel.Name = "CurrentStatusLabel";
            this.CurrentStatusLabel.Size = new System.Drawing.Size(250, 18);
            this.CurrentStatusLabel.TabIndex = 6;
            this.CurrentStatusLabel.Text = "Current Status: ";
            // 
            // StatusMainPanel
            // 
            this.StatusMainPanel.Controls.Add(this.ProfileStatusCustomTextBox);
            this.StatusMainPanel.Controls.Add(this.SaveStatusCustomButton);
            this.StatusMainPanel.Controls.Add(this.RefreshStatusCustomButton);
            this.StatusMainPanel.Controls.Add(this.CharNumberLabel);
            this.StatusMainPanel.Location = new System.Drawing.Point(10, 160);
            this.StatusMainPanel.Name = "StatusMainPanel";
            this.StatusMainPanel.Size = new System.Drawing.Size(300, 175);
            this.StatusMainPanel.TabIndex = 43;
            // 
            // ProfileStatusCustomTextBox
            // 
            this.ProfileStatusCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ProfileStatusCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.ProfileStatusCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.ProfileStatusCustomTextBox.BorderRadius = 0;
            this.ProfileStatusCustomTextBox.BorderSize = 2;
            this.ProfileStatusCustomTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProfileStatusCustomTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileStatusCustomTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProfileStatusCustomTextBox.IsFocused = false;
            this.ProfileStatusCustomTextBox.Location = new System.Drawing.Point(10, 0);
            this.ProfileStatusCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProfileStatusCustomTextBox.MaxLength = 150;
            this.ProfileStatusCustomTextBox.Multiline = true;
            this.ProfileStatusCustomTextBox.Name = "ProfileStatusCustomTextBox";
            this.ProfileStatusCustomTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.ProfileStatusCustomTextBox.PasswordChar = false;
            this.ProfileStatusCustomTextBox.PlaceHolderColor = System.Drawing.Color.Silver;
            this.ProfileStatusCustomTextBox.PlaceHolderText = "Write Here Your YouChat Status";
            this.ProfileStatusCustomTextBox.ReadOnly = false;
            this.ProfileStatusCustomTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProfileStatusCustomTextBox.Size = new System.Drawing.Size(280, 83);
            this.ProfileStatusCustomTextBox.TabIndex = 41;
            this.ProfileStatusCustomTextBox.TabStop = false;
            this.ProfileStatusCustomTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ProfileStatusCustomTextBox.TextContent = "";
            this.ProfileStatusCustomTextBox.UnderlineStyle = false;
            this.ProfileStatusCustomTextBox.TextChangedEvent += new System.EventHandler(this.ProfileStatusCustomTextBox_TextChangedEvent);
            // 
            // SaveStatusCustomButton
            // 
            this.SaveStatusCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.SaveStatusCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.SaveStatusCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.approve;
            this.SaveStatusCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveStatusCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SaveStatusCustomButton.BorderRadius = 10;
            this.SaveStatusCustomButton.BorderSize = 0;
            this.SaveStatusCustomButton.Circular = false;
            this.SaveStatusCustomButton.Enabled = false;
            this.SaveStatusCustomButton.FlatAppearance.BorderSize = 0;
            this.SaveStatusCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveStatusCustomButton.ForeColor = System.Drawing.Color.White;
            this.SaveStatusCustomButton.Location = new System.Drawing.Point(40, 115);
            this.SaveStatusCustomButton.Name = "SaveStatusCustomButton";
            this.SaveStatusCustomButton.Size = new System.Drawing.Size(100, 50);
            this.SaveStatusCustomButton.TabIndex = 42;
            this.SaveStatusCustomButton.TextColor = System.Drawing.Color.White;
            this.SaveStatusCustomButton.UseVisualStyleBackColor = false;
            this.SaveStatusCustomButton.Click += new System.EventHandler(this.SaveStatusCustomButton_Click);
            // 
            // RefreshStatusCustomButton
            // 
            this.RefreshStatusCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshStatusCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.RefreshStatusCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset;
            this.RefreshStatusCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RefreshStatusCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RefreshStatusCustomButton.BorderRadius = 10;
            this.RefreshStatusCustomButton.BorderSize = 0;
            this.RefreshStatusCustomButton.Circular = false;
            this.RefreshStatusCustomButton.Enabled = false;
            this.RefreshStatusCustomButton.FlatAppearance.BorderSize = 0;
            this.RefreshStatusCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshStatusCustomButton.ForeColor = System.Drawing.Color.White;
            this.RefreshStatusCustomButton.Location = new System.Drawing.Point(160, 115);
            this.RefreshStatusCustomButton.Name = "RefreshStatusCustomButton";
            this.RefreshStatusCustomButton.Size = new System.Drawing.Size(100, 50);
            this.RefreshStatusCustomButton.TabIndex = 39;
            this.RefreshStatusCustomButton.TextColor = System.Drawing.Color.White;
            this.RefreshStatusCustomButton.UseVisualStyleBackColor = false;
            this.RefreshStatusCustomButton.Click += new System.EventHandler(this.RefreshStatusCustomButton_Click);
            // 
            // StatusHeadlineLabel
            // 
            this.StatusHeadlineLabel.AutoSize = true;
            this.StatusHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusHeadlineLabel.Location = new System.Drawing.Point(117, 10);
            this.StatusHeadlineLabel.Name = "StatusHeadlineLabel";
            this.StatusHeadlineLabel.Size = new System.Drawing.Size(85, 28);
            this.StatusHeadlineLabel.TabIndex = 48;
            this.StatusHeadlineLabel.Text = "Status";
            // 
            // ProfileStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusHeadlineLabel);
            this.Controls.Add(this.StatusMainPanel);
            this.Controls.Add(this.StatusTextPanel);
            this.Name = "ProfileStatusControl";
            this.Size = new System.Drawing.Size(320, 345);
            this.StatusTextPanel.ResumeLayout(false);
            this.StatusTextPanel.PerformLayout();
            this.StatusMainPanel.ResumeLayout(false);
            this.StatusMainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CharNumberLabel;
        private System.Windows.Forms.Panel StatusTextPanel;
        private System.Windows.Forms.Label CurrentStatusLabel;
        private CustomButton RefreshStatusCustomButton;
        private CustomTextBox ProfileStatusCustomTextBox;
        private CustomButton SaveStatusCustomButton;
        private System.Windows.Forms.Panel StatusMainPanel;
        private System.Windows.Forms.Label StatusHeadlineLabel;
    }
}
