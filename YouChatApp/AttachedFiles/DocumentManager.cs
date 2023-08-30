using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Graphics;

namespace YouChatApp.AttachedFiles
{
    public partial class Document : Form
    {
        PdfDocument PdfViewer = new PdfDocument();
        public Document()
        {
            InitializeComponent();
            // Add a page
            PdfPageBase page = PdfViewer.Pages.Add();

            // Save the PDF to a file
            // Close the document
            PdfViewer.Close();
        }

        private void OpenDocumentDialogButton_Click(object sender, EventArgs e)
        {
            DocumentOpenFileDialog.Filter = "PDF Files(*.pdf)|*.pdf|Doc Files (*.doc)|*.doc|All Files (*.*)|*.*";
            if (DocumentOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(DocumentOpenFileDialog.FileName))
                {
                   PdfViewer.LoadFromFile(DocumentOpenFileDialog.FileName);
 
                }
            
            }
        }
    }
}
