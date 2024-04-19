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
            this.message1 = new YouChatApp.Message();
            this.SuspendLayout();
            // 
            // message1
            // 
            this.message1.BackColor = System.Drawing.SystemColors.Control;
            this.message1.IsYourMessage = true;
            this.message1.Location = new System.Drawing.Point(75, 94);
            this.message1.MaximumSize = new System.Drawing.Size(850, 0);
            this.message1.MessageType = YouChatApp.EnumHandler.MessageType_Enum.Image;
            this.message1.MinimumSize = new System.Drawing.Size(175, 70);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(450, 70);
            this.message1.TabIndex = 0;
            // 
            // tryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.message1);
            this.Name = "tryform";
            this.Text = "tryform";
            this.ResumeLayout(false);

        }

        #endregion

        private Message message1;
    }
}