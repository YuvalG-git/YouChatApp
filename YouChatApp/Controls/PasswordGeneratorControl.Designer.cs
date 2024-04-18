namespace YouChatApp.Controls
{
    partial class PasswordGeneratorControl
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
            this.components = new System.ComponentModel.Container();
            this.OldPasswordLabel = new System.Windows.Forms.Label();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PasswordExclamationCustomButton = new YouChatApp.Controls.CustomButton();
            this.SuspendLayout();
            // 
            // OldPasswordLabel
            // 
            this.OldPasswordLabel.AutoSize = true;
            this.OldPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OldPasswordLabel.Location = new System.Drawing.Point(10, 10);
            this.OldPasswordLabel.Name = "OldPasswordLabel";
            this.OldPasswordLabel.Size = new System.Drawing.Size(123, 18);
            this.OldPasswordLabel.TabIndex = 0;
            this.OldPasswordLabel.Text = "Old Password:";
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordLabel.Location = new System.Drawing.Point(10, 70);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(131, 18);
            this.NewPasswordLabel.TabIndex = 2;
            this.NewPasswordLabel.Text = "New Password:";
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(10, 130);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(158, 18);
            this.ConfirmPasswordLabel.TabIndex = 3;
            this.ConfirmPasswordLabel.Text = "Confirm Password:";
            // 
            // PasswordExclamationCustomButton
            // 
            this.PasswordExclamationCustomButton.BackColor = System.Drawing.Color.IndianRed;
            this.PasswordExclamationCustomButton.BackgroundColor = System.Drawing.Color.IndianRed;
            this.PasswordExclamationCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.ExclamationMark;
            this.PasswordExclamationCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PasswordExclamationCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.PasswordExclamationCustomButton.BorderRadius = 20;
            this.PasswordExclamationCustomButton.BorderSize = 0;
            this.PasswordExclamationCustomButton.Circular = false;
            this.PasswordExclamationCustomButton.FlatAppearance.BorderSize = 0;
            this.PasswordExclamationCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordExclamationCustomButton.ForeColor = System.Drawing.Color.White;
            this.PasswordExclamationCustomButton.Location = new System.Drawing.Point(280, 70);
            this.PasswordExclamationCustomButton.Name = "PasswordExclamationCustomButton";
            this.PasswordExclamationCustomButton.Size = new System.Drawing.Size(50, 40);
            this.PasswordExclamationCustomButton.TabIndex = 71;
            this.PasswordExclamationCustomButton.TextColor = System.Drawing.Color.White;
            this.PasswordExclamationCustomButton.UseVisualStyleBackColor = false;
            this.PasswordExclamationCustomButton.Visible = false;
            // 
            // PasswordGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PasswordExclamationCustomButton);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.OldPasswordLabel);
            this.Name = "PasswordGeneratorControl";
            this.Size = new System.Drawing.Size(350, 209);
            this.Load += new System.EventHandler(this.PasswordGeneratorControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OldPasswordLabel;
        private CustomTextBox[] PasswordTextBoxArray;

        private CustomButton[] PasswordViewerCustomButtonArray;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private CustomButton PasswordExclamationCustomButton;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
