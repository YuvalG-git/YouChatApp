namespace YouChatApp.AttachedFiles
{
    partial class Document
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Document));
            this.DocumentOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenDocumentDialogButton = new System.Windows.Forms.Button();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.SuspendLayout();
            // 
            // DocumentOpenFileDialog
            // 
            this.DocumentOpenFileDialog.FileName = "openFileDialog1";
            // 
            // OpenDocumentDialogButton
            // 
            this.OpenDocumentDialogButton.Location = new System.Drawing.Point(355, 752);
            this.OpenDocumentDialogButton.Name = "OpenDocumentDialogButton";
            this.OpenDocumentDialogButton.Size = new System.Drawing.Size(75, 23);
            this.OpenDocumentDialogButton.TabIndex = 0;
            this.OpenDocumentDialogButton.Text = "button1";
            this.OpenDocumentDialogButton.UseVisualStyleBackColor = true;
            this.OpenDocumentDialogButton.Click += new System.EventHandler(this.OpenDocumentDialogButton_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pdfViewer1.FormFillEnabled = false;
            this.pdfViewer1.IgnoreCase = false;
            this.pdfViewer1.IsToolBarVisible = true;
            this.pdfViewer1.Location = new System.Drawing.Point(12, 22);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(776, 724);
            this.pdfViewer1.TabIndex = 1;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 808);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.OpenDocumentDialogButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Document";
            this.Text = "Document";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog DocumentOpenFileDialog;
        private System.Windows.Forms.Button OpenDocumentDialogButton;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
    }
}