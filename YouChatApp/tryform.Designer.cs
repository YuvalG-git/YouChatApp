namespace YouChatApp
{
    partial class tryform
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
            this.chatControl1 = new YouChatApp.ChatControl();
            this.message1 = new YouChatApp.AdvancedMessageControl();
            this.SuspendLayout();
            // 
            // chatControl1
            // 
            this.chatControl1.BackgroundColor = System.Drawing.Color.Transparent;
            this.chatControl1.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.chatControl1.ChatId = null;
            this.chatControl1.Location = new System.Drawing.Point(213, 136);
            this.chatControl1.Name = "chatControl1";
            this.chatControl1.OnFocusBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.chatControl1.Size = new System.Drawing.Size(315, 80);
            this.chatControl1.TabIndex = 1;
            // 
            // message1
            // 
            this.message1.AutoSize = true;
            this.message1.BackColor = System.Drawing.SystemColors.Control;
            this.message1.IsYourMessage = true;
            this.message1.Location = new System.Drawing.Point(88, 118);
            this.message1.MaximumSize = new System.Drawing.Size(850, 0);
            this.message1.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Text;
            this.message1.MinimumSize = new System.Drawing.Size(175, 70);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(408, 70);
            this.message1.TabIndex = 0;
            // 
            // tryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.chatControl1);
            this.Controls.Add(this.message1);
            this.Name = "tryform";
            this.Text = "tryform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdvancedMessageControl message1;
        private ChatControl chatControl1;
    }
}