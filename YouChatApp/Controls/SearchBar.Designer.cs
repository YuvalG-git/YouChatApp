namespace YouChatApp.Controls
{
    partial class SearchBar
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
            this.SearchPictureBox = new System.Windows.Forms.PictureBox();
            this.SearchBackgroundCircularPictureBox = new YouChatApp.CircularPictureBox();
            this.SearchBarCustomTextBox = new YouChatApp.Controls.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBackgroundCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchPictureBox
            // 
            this.SearchPictureBox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SearchPictureBox.Image = global::YouChatApp.Properties.Resources.Search;
            this.SearchPictureBox.Location = new System.Drawing.Point(271, 16);
            this.SearchPictureBox.Name = "SearchPictureBox";
            this.SearchPictureBox.Size = new System.Drawing.Size(28, 28);
            this.SearchPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchPictureBox.TabIndex = 1;
            this.SearchPictureBox.TabStop = false;
            this.SearchPictureBox.Click += new System.EventHandler(this.OnSearch);
            // 
            // SearchBackgroundCircularPictureBox
            // 
            this.SearchBackgroundCircularPictureBox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SearchBackgroundCircularPictureBox.Location = new System.Drawing.Point(265, 10);
            this.SearchBackgroundCircularPictureBox.Name = "SearchBackgroundCircularPictureBox";
            this.SearchBackgroundCircularPictureBox.Size = new System.Drawing.Size(40, 40);
            this.SearchBackgroundCircularPictureBox.TabIndex = 2;
            this.SearchBackgroundCircularPictureBox.TabStop = false;
            this.SearchBackgroundCircularPictureBox.Click += new System.EventHandler(this.OnSearch);
            // 
            // SearchBarCustomTextBox
            // 
            this.SearchBarCustomTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SearchBarCustomTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.SearchBarCustomTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.SearchBarCustomTextBox.BorderRadius = 14;
            this.SearchBarCustomTextBox.BorderSize = 2;
            this.SearchBarCustomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SearchBarCustomTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.SearchBarCustomTextBox.IsFocused = false;
            this.SearchBarCustomTextBox.Location = new System.Drawing.Point(5, 15);
            this.SearchBarCustomTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SearchBarCustomTextBox.Multiline = false;
            this.SearchBarCustomTextBox.Name = "SearchBarCustomTextBox";
            this.SearchBarCustomTextBox.Padding = new System.Windows.Forms.Padding(7);
            this.SearchBarCustomTextBox.PasswordChar = false;
            this.SearchBarCustomTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.SearchBarCustomTextBox.PlaceHolderText = "Search...";
            this.SearchBarCustomTextBox.Size = new System.Drawing.Size(250, 31);
            this.SearchBarCustomTextBox.TabIndex = 3;
            this.SearchBarCustomTextBox.TextContent = "";
            this.SearchBarCustomTextBox.UnderlineStyle = false;
            this.SearchBarCustomTextBox.TextChangedEvent += new System.EventHandler(this.OnSearch);
            this.SearchBarCustomTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SearchBarCustomTextBox_MouseDown);
            // 
            // SearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SearchBarCustomTextBox);
            this.Controls.Add(this.SearchPictureBox);
            this.Controls.Add(this.SearchBackgroundCircularPictureBox);
            this.Name = "SearchBar";
            this.Size = new System.Drawing.Size(320, 60);
            this.Load += new System.EventHandler(this.SearchBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBackgroundCircularPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox SearchPictureBox;
        private CircularPictureBox SearchBackgroundCircularPictureBox;
        private CustomTextBox SearchBarCustomTextBox;
    }
}
