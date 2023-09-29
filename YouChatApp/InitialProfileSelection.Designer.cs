namespace YouChatApp
{
    partial class InitialProfileSelection
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ProfilePictureGroupBox = new System.Windows.Forms.GroupBox();
            this.StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.CharNumberLabel = new System.Windows.Forms.Label();
            this.ProfileStatusTextBox = new System.Windows.Forms.TextBox();
            this.RefreshTextButton = new System.Windows.Forms.Button();
            this.ProfileSettingsHeadlineLabel = new System.Windows.Forms.Label();
            this.ProfilePictureControl = new YouChatApp.Controls.ProfilePictureControl();
            this.ProfilePictureGroupBox.SuspendLayout();
            this.StatusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.Location = new System.Drawing.Point(676, 698);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(94, 29);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ProfilePictureGroupBox
            // 
            this.ProfilePictureGroupBox.AutoSize = true;
            this.ProfilePictureGroupBox.Controls.Add(this.ProfilePictureControl);
            this.ProfilePictureGroupBox.Location = new System.Drawing.Point(38, 62);
            this.ProfilePictureGroupBox.Name = "ProfilePictureGroupBox";
            this.ProfilePictureGroupBox.Size = new System.Drawing.Size(575, 622);
            this.ProfilePictureGroupBox.TabIndex = 1;
            this.ProfilePictureGroupBox.TabStop = false;
            // 
            // StatusGroupBox
            // 
            this.StatusGroupBox.Controls.Add(this.CharNumberLabel);
            this.StatusGroupBox.Controls.Add(this.ProfileStatusTextBox);
            this.StatusGroupBox.Controls.Add(this.RefreshTextButton);
            this.StatusGroupBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusGroupBox.Location = new System.Drawing.Point(760, 212);
            this.StatusGroupBox.Name = "StatusGroupBox";
            this.StatusGroupBox.Size = new System.Drawing.Size(308, 266);
            this.StatusGroupBox.TabIndex = 0;
            this.StatusGroupBox.TabStop = false;
            // 
            // CharNumberLabel
            // 
            this.CharNumberLabel.AutoSize = true;
            this.CharNumberLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharNumberLabel.Location = new System.Drawing.Point(19, 116);
            this.CharNumberLabel.Name = "CharNumberLabel";
            this.CharNumberLabel.Size = new System.Drawing.Size(38, 14);
            this.CharNumberLabel.TabIndex = 7;
            this.CharNumberLabel.Text = "0/150";
            // 
            // ProfileStatusTextBox
            // 
            this.ProfileStatusTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileStatusTextBox.ForeColor = System.Drawing.Color.Silver;
            this.ProfileStatusTextBox.Location = new System.Drawing.Point(22, 34);
            this.ProfileStatusTextBox.MaxLength = 150;
            this.ProfileStatusTextBox.Multiline = true;
            this.ProfileStatusTextBox.Name = "ProfileStatusTextBox";
            this.ProfileStatusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProfileStatusTextBox.Size = new System.Drawing.Size(262, 79);
            this.ProfileStatusTextBox.TabIndex = 3;
            this.ProfileStatusTextBox.Text = "Write Here Your YouChat Status";
            this.ProfileStatusTextBox.TextChanged += new System.EventHandler(this.ProfileStatusTextBox_TextChanged);
            this.ProfileStatusTextBox.Enter += new System.EventHandler(this.ProfileStatusTextBox_Enter);
            this.ProfileStatusTextBox.Leave += new System.EventHandler(this.ProfileStatusTextBox_Leave);
            // 
            // RefreshTextButton
            // 
            this.RefreshTextButton.BackgroundImage = global::YouChatApp.Properties.Resources.reset1;
            this.RefreshTextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshTextButton.Location = new System.Drawing.Point(164, 230);
            this.RefreshTextButton.Name = "RefreshTextButton";
            this.RefreshTextButton.Size = new System.Drawing.Size(30, 30);
            this.RefreshTextButton.TabIndex = 0;
            this.RefreshTextButton.UseVisualStyleBackColor = true;
            this.RefreshTextButton.Click += new System.EventHandler(this.RefreshTextButton_Click);
            // 
            // ProfileSettingsHeadlineLabel
            // 
            this.ProfileSettingsHeadlineLabel.AutoSize = true;
            this.ProfileSettingsHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileSettingsHeadlineLabel.Location = new System.Drawing.Point(414, 19);
            this.ProfileSettingsHeadlineLabel.Name = "ProfileSettingsHeadlineLabel";
            this.ProfileSettingsHeadlineLabel.Size = new System.Drawing.Size(0, 40);
            this.ProfileSettingsHeadlineLabel.TabIndex = 2;
            // 
            // ProfilePictureControl
            // 
            this.ProfilePictureControl.Location = new System.Drawing.Point(23, 33);
            this.ProfilePictureControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ProfilePictureControl.Name = "ProfilePictureControl";
            this.ProfilePictureControl.Size = new System.Drawing.Size(545, 561);
            this.ProfilePictureControl.TabIndex = 1;
            this.ProfilePictureControl.Click += new System.EventHandler(this.ProfilePictureControl_Click);
            // 
            // InitialProfileSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 755);
            this.Controls.Add(this.ProfileSettingsHeadlineLabel);
            this.Controls.Add(this.StatusGroupBox);
            this.Controls.Add(this.ProfilePictureGroupBox);
            this.Controls.Add(this.ConfirmButton);
            this.Name = "InitialProfileSelection";
            this.Text = "InitialProfileSelection";
            this.ProfilePictureGroupBox.ResumeLayout(false);
            this.StatusGroupBox.ResumeLayout(false);
            this.StatusGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button[,] ProfileAvatarMatrix;
        private System.Windows.Forms.Button[] ProfilePictureKindSelectionButtons;
        private System.Windows.Forms.GroupBox ProfilePictureGroupBox;
        private System.Windows.Forms.GroupBox StatusGroupBox;
        private System.Windows.Forms.Button RefreshTextButton;
        private System.Windows.Forms.TextBox ProfileStatusTextBox;
        private System.Windows.Forms.Label CharNumberLabel;
        private Controls.ProfilePictureControl ProfilePictureControl;
        private System.Windows.Forms.Label ProfileSettingsHeadlineLabel;
    }
}