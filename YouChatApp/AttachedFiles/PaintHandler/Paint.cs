using Spire.Pdf.Exporting.XPS.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.AttachedFiles.PaintHandler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.AttachedFiles.PaintHandler
{
    public partial class Paint : Form
    {
        private readonly Image UndoIsShown = global::YouChatApp.Properties.Resources.Undo;
        private readonly Image UndoIsNotShown = global::YouChatApp.Properties.Resources.UndoNotPressed;
        private readonly Image RedoIsShown = global::YouChatApp.Properties.Resources.Redo;
        private readonly Image RedoIsNotShown = global::YouChatApp.Properties.Resources.RedoNotPressed;
        private List<Drawing> LastCanvasUpdates;
        private int currentCanvasIndex = 0;
        private Graphics Graphics;
        private int CursorX = -1;
        private int CursorY = -1;
        private int X;
        private int Y;
        private int cX;
        private int cY;
        private int CursorWidth;
        private int CursorHeight;
        /// <summary>
        /// Represents which one of the drawing should happen...
        /// Index 0 -> Pencil
        /// Index 1 -> Eraser
        /// Index 2 -> Text
        /// Index 3 -> Line
        /// Index 4 -> Circle
        /// Index 5 -> Rectangle
        /// </summary>
        private bool[] PaintOption_IsChosenList;
        private int DrawingWidth, DrawingHeight;
        private int BackgroundImageWidth = 0;
        private int BackgroundImageHeight = 0;

        private Bitmap DrawingBitMap;
        private Bitmap TemporaryBitMap;
        private int PenSize = 5;
        private Pen DrawingPen = new Pen(Color.Black, 5);
        private SolidBrush drawBrush = new SolidBrush(Color.Black);
        private Graphics TemporaryGraphics;
        private bool IsCursorMoving = false;
        private bool IsDrawing = false;
        private Image OpenedBackgroundImage;
        private int ColoredButtons = 4;
        private Color PenColor = Color.Black;
        private Color BrushColor = Color.Black;
        private bool IsTextContentTextBoxEntered = false;
        private bool IsTextBold = false;
        private bool IsTextItalic = false;
        private bool IsTextUnderline = false;
        private bool IsTextStrikeout = false;
        public static Image finalImage;

        public Paint()
        {
            InitializeComponent();
            InitializeGraphics();
            InitializeLastCanvasUpdates();
            PaintOption_IsChosenList = new bool[6];
            SetPaintOptionIsChosenListToFalse();
            TextContentTextBoxList = new List<System.Windows.Forms.TextBox>();
            InitializeFontToolStripComboBox();
            TextSizeToolStripComboBox.SelectedIndex = 4;
        }
        public void SetBitMap()
        {
            DrawingWidth = DrawingBoardPictureBox.Width;
            DrawingHeight = DrawingBoardPictureBox.Height;
            DrawingBitMap = new Bitmap(DrawingWidth, DrawingHeight);
            TemporaryBitMap = new Bitmap(DrawingWidth, DrawingHeight);

        }
        private void InitializeGraphics()
        {
            SetBitMap();
            Graphics = Graphics.FromImage(DrawingBitMap);
            Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            DrawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            TemporaryGraphics = Graphics.FromImage(TemporaryBitMap);
            TemporaryGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Graphics.Clear(Color.White);
            DrawingBoardPictureBox.Image = DrawingBitMap;
        }
        private void InitializeLastCanvasUpdates()
        {
            if (LastCanvasUpdates != null)
            {
                foreach (Drawing drawing in LastCanvasUpdates)
                {
                    drawing.DrawingImage.Dispose();
                }
            }
            LastCanvasUpdates = new List<Drawing>();
            InsertDrawing();
            UndoToolStripButton.Enabled = false;
        }
        private void InsertDrawing()
        {
            UndoToolStripButton.Enabled = true;
            RedoToolStripButton.Enabled = false;

            Image currentImage = new Bitmap(DrawingBitMap);
            Drawing drawing = new Drawing(DrawingWidth, DrawingHeight, currentImage);

            LastCanvasUpdates.Insert(0, drawing);
            currentCanvasIndex = 0;
        }
        private void InitializeFontToolStripComboBox()
        {
            foreach (FontFamily Font in System.Drawing.FontFamily.Families)
            {
                FontToolStripComboBox.Items.Add(Font.Name);
            }
            FontToolStripComboBox.SelectedIndex = 3;
        }
        private void SetPaintOptionIsChosenListToFalse()
        {
            for (int Index = 0; Index < PaintOption_IsChosenList.Length; Index++)
            {
                PaintOption_IsChosenList[Index] = false;
            }
        }

        private void DrawingBoardPictureBox_MouseDown(object sender, MouseEventArgs e) //was used for both mousedown and mouse up...
        {
            IsCursorMoving = true;
            CursorX = e.X;
            CursorY = e.Y;
            cX = e.X;
            cY = e.Y;
           
        }        
        private void DrawingBoardPictureBox_MouseUp(object sender, MouseEventArgs e) //was used for both mousedown and mouse up...
        {
            IsCursorMoving = false;
            CursorX = -1;
            CursorY = -1;
            CursorWidth = X - cX;
            CursorHeight = Y - cY;

            if(PaintOption_IsChosenList[3])
            {
                Graphics.DrawLine(DrawingPen, cX, cY, X, Y);
                DrawingBoardPictureBox.Image = DrawingBitMap;
            }
            else if (PaintOption_IsChosenList[4])
            {
                Graphics.DrawEllipse(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = DrawingBitMap;
            }
            else if (PaintOption_IsChosenList[5])
            {
                Graphics.DrawRectangle(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = DrawingBitMap;
            }
            if (IsDrawing)
            {
                InsertDrawing();
            }

            IsDrawing = false;
        }
        private void DrawingBoardPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((CursorX != -1) && (CursorY != -1) && (IsCursorMoving))
            {

                IsDrawing = true;
                if (PaintOption_IsChosenList[0] || PaintOption_IsChosenList[1])
                {
                    Graphics.DrawLine(DrawingPen, new Point(CursorX, CursorY), e.Location);
                    DrawingBoardPictureBox.Image = DrawingBitMap;

                    CursorX = e.X;
                    CursorY = e.Y;
                }
                else
                {
                    SetShapes();
                }
            }
            else
            {
                IsDrawing = false;
            }
            X = e.X;
            Y = e.Y;
            CursorWidth = X - cX;
            CursorHeight = Y - cY;
        }

        private void ColorChange_Click(object sender, EventArgs e)
        {
            DrawingPen.Color = ((ToolStripButton)(sender)).BackColor;
        }

        private void PenSizeChangeValue_Click(object sender, EventArgs e)
        {
            PenSize = int.Parse(((ToolStripMenuItem)(sender)).Text);
            DrawingPen.Width = (float)PenSize;
        }

        private void SaveOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintSaveFileDialog.Filter = "jpg Files(*.jpg)|*.jpg|PNG Files (*.png)|*.png|Bitmap Files (*.bmp)|*.bmp|All Files (*.*)|*.*";
            PaintSaveFileDialog.Title = "Save an Image File";
            PaintSaveFileDialog.ShowDialog();
            Image image = LastCanvasUpdates[currentCanvasIndex].DrawingImage;
            if (PaintSaveFileDialog.FileName != "")
            {
                using (System.IO.FileStream FileStreamConnection = (System.IO.FileStream)PaintSaveFileDialog.OpenFile())
                {
                    switch (PaintSaveFileDialog.FilterIndex)
                    {
                        case 0:
                            image.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 1:
                            image.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case 2:
                            image.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                }
            }
        }

        private void OpenOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult PaintDialogResult = PaintOpenFileDialog.ShowDialog();
            if (PaintDialogResult == DialogResult.OK)
            {
                OpenedBackgroundImage = Image.FromFile(PaintOpenFileDialog.FileName);
                ChangeBackgroundColor(Color.Transparent);
                BackgroundImageWidth = OpenedBackgroundImage.Width;
                BackgroundImageHeight = OpenedBackgroundImage.Height;
                float scale = Math.Min((float)DrawingBoardPictureBox.Width / BackgroundImageWidth,
                              (float)DrawingBoardPictureBox.Height / BackgroundImageHeight);
                int newWidth = (int)(BackgroundImageWidth * scale);
                int newHeight = (int)(BackgroundImageHeight * scale);
                Image scaledImage = new Bitmap(OpenedBackgroundImage, newWidth, newHeight);      
                Graphics.DrawImage(scaledImage, 0, 0, newWidth, newHeight);
                DrawingBoardPictureBox.Image = DrawingBitMap;
                InsertDrawing();

            }
        }

     

        private void DeleteOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCanvas();
            InsertDrawing();
            InitializeLastCanvasUpdates();
        }
        private void DeleteCanvas()
        {
            DrawingBitMap = new Bitmap(DrawingWidth, DrawingHeight); //todo confirm about deleting
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();

        }


        private void MultiColorOptionToolStripButton_Click(object sender, EventArgs e)
        {
            if (PaintColorDialog.ShowDialog() == DialogResult.OK)
            {
                ToolStripButton ButtonToMoveToBegining = PaintToolStrip.Items[ColoredButtons - 1] as ToolStripButton;

                if (ButtonToMoveToBegining != null)
                {
                    PaintToolStrip.Items.Remove(ButtonToMoveToBegining); 
                    PaintToolStrip.Items.Insert(2, ButtonToMoveToBegining);
                }
                PenColor = PaintColorDialog.Color; ;
                ButtonToMoveToBegining.BackColor = PenColor;
                DrawingPen.Color = PenColor;

            }
        }

        private void TextMultiColorOptionToolStripButton_Click(object sender, EventArgs e)
        {
            if (PaintColorDialog.ShowDialog() == DialogResult.OK)
            {
                ToolStripButton ButtonToMoveToBegining = TextToolStrip.Items[ColoredButtons - 1] as ToolStripButton;

                if (ButtonToMoveToBegining != null)
                {
                    TextToolStrip.Items.Remove(ButtonToMoveToBegining); 
                    TextToolStrip.Items.Insert(0, ButtonToMoveToBegining); 
                }
                BrushColor = PaintColorDialog.Color; ;
                ButtonToMoveToBegining.BackColor = BrushColor;
                TextContentTextBox.ForeColor = BrushColor;
            }
        }


        private void DrawingBoardPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsDrawing)
            {
                if (PaintOption_IsChosenList[0] || PaintOption_IsChosenList[1])
                {
                    int left = e.X - PenSize / 2;
                    int top = e.Y - PenSize / 2;

                    // Draw the ellipse centered at (e.X, e.Y)
                    Graphics.DrawEllipse(DrawingPen, left, top, PenSize, PenSize);
                    DrawingBoardPictureBox.Image = DrawingBitMap;
                    InsertDrawing();
                }
                else if (PaintOption_IsChosenList[2])
                {
                    TextContentTextBox.Visible = true;
                    TextContentTextBox.Location = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }




        private void PencilToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[0] = true;
            DrawingPen.Color = PenColor;

        }

        private void EraserToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[1] = true;
            DrawingPen.Color = Color.White;
        }

        private void TextToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[2] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = true;
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[3] = true;
            DrawingPen.Color = PenColor;
        }

        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[4] = true;
            DrawingPen.Color = PenColor;
        }

        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[5] = true;
            DrawingPen.Color = PenColor;
        }





        private void TextContentTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsTextContentTextBoxEntered = true;
        }
        private void ChangeTextContentTextBoxFont(FontStyle fontStyle)
        {
            Font originalFont = TextContentTextBox.Font; // The original font
            FontStyle style = fontStyle; // The style you want to remove
            FontStyle newStyle;
            // Check if the style to remove is present in the original font
            if (originalFont.Style.HasFlag(style))
            {
                // Remove the specified style from the original font style
                newStyle = originalFont.Style & ~style;
            }
            else
            {
                newStyle = originalFont.Style | style;
            }

            // Create a new font with the modified style
            Font newFont = new Font(originalFont, newStyle);
            TextContentTextBox.Font = newFont;
        }



        private void BoldtoolStripButton_Click(object sender, EventArgs e) 
        {
            IsTextBold = !IsTextBold;
            if (IsTextBold)
            {
                BoldtoolStripButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
            else
            {
                BoldtoolStripButton.BackColor = System.Drawing.SystemColors.Control;
            }
            ChangeTextContentTextBoxFont(FontStyle.Bold);
        }

        private void ItalicToolStripButton_Click(object sender, EventArgs e)
        {
            IsTextItalic = !IsTextItalic;
            if (IsTextItalic)
            {
                ItalicToolStripButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
            else
            {
                ItalicToolStripButton.BackColor = System.Drawing.SystemColors.Control;
            }
            ChangeTextContentTextBoxFont(FontStyle.Italic);
        }


        private void UnderlineToolStripButton_Click(object sender, EventArgs e)
        {
            IsTextUnderline = !IsTextUnderline;
            if (IsTextUnderline)
            {
                UnderlineToolStripButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
            else
            {
                UnderlineToolStripButton.BackColor = System.Drawing.SystemColors.Control;
            }
            ChangeTextContentTextBoxFont(FontStyle.Underline);
        }

        private void StrikeoutToolStripButton_Click(object sender, EventArgs e)
        {
            IsTextStrikeout = !IsTextStrikeout;
            if (IsTextStrikeout)
            {
                StrikeoutToolStripButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
            else
            {
                StrikeoutToolStripButton.BackColor = System.Drawing.SystemColors.Control;
            }
            ChangeTextContentTextBoxFont(FontStyle.Strikeout);
        }

        public void SetShapes()
        {
            TemporaryBitMap = new Bitmap(DrawingBitMap);
            TemporaryGraphics = Graphics.FromImage(TemporaryBitMap);

            if (PaintOption_IsChosenList[3])
            {
                TemporaryGraphics.DrawLine(DrawingPen, cX, cY, X, Y);
                DrawingBoardPictureBox.Image = TemporaryBitMap;

            }
            else if (PaintOption_IsChosenList[4])
            {
                TemporaryGraphics.DrawEllipse(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = TemporaryBitMap;
            }
            else if (PaintOption_IsChosenList[5])
            {
                TemporaryGraphics.DrawRectangle(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = TemporaryBitMap;

            }
        }
 

        private void BackgroundColorToolStripButton_Click(object sender, EventArgs e)
        {
            if (PaintColorDialog.ShowDialog() == DialogResult.OK)
            {
                Color ChosenColor = PaintColorDialog.Color;
                DrawingBoardPictureBox.Image = DrawingBitMap;
                ChangeBackgroundColor(ChosenColor);
                DrawingBoardPictureBox.BackColor = ChosenColor;
                InsertDrawing();
            }
        }

        private void Paint_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteCanvas();
        }

        private void RotateRight90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = RotateImage90DegreesRight((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        private void FlipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = FlipImageVertically((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        private Bitmap FlipImageHorizontally(Bitmap original)
        {
            Bitmap flipped = new Bitmap(original.Width, original.Height);
            using (Graphics graphics = Graphics.FromImage(flipped))
            {
                graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                    new Rectangle(original.Width - 1, 0, -original.Width, original.Height), GraphicsUnit.Pixel);
            }
            return flipped;
        }
        private Bitmap FlipImageVertically(Bitmap original)
        {
            Bitmap flipped = new Bitmap(original.Width, original.Height);

            using (Graphics graphics = Graphics.FromImage(flipped))
            {
                graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                    new Rectangle(0, original.Height - 1, original.Width, -original.Height), GraphicsUnit.Pixel);
            }
            return flipped;
        }

        private Bitmap RotateImage90DegreesRight(Bitmap original)
        {
            DrawingWidth = DrawingBoardPictureBox.Height;
            DrawingHeight = DrawingBoardPictureBox.Width;
            DrawingBoardPictureBox.Width = DrawingWidth;
            DrawingBoardPictureBox.Height = DrawingHeight;
            original.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return new Bitmap(original);
        }
        private Bitmap RotateImage90DegreesLeft(Bitmap original)
        {
            DrawingWidth = DrawingBoardPictureBox.Height;
            DrawingHeight = DrawingBoardPictureBox.Width;
            DrawingBoardPictureBox.Width = DrawingWidth;
            DrawingBoardPictureBox.Height = DrawingHeight;
            original.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return new Bitmap(original);
        }
        private Bitmap RotateImage180Degrees(Bitmap original)
        {
            original.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return new Bitmap(original);
        }
        private void FlipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = FlipImageHorizontally((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        private void RotateLeft90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = RotateImage90DegreesLeft((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        private void Rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = RotateImage180Degrees((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            currentCanvasIndex--;
            if (currentCanvasIndex == 0)
            {
                RedoToolStripButton.Enabled = false;
            }
            if(currentCanvasIndex == LastCanvasUpdates.Count - 2)
            {
                UndoToolStripButton.Enabled = true;
            }
            HandleCanvas();
        }

        private void UndoToolStripButton_Click(object sender, EventArgs e)
        {
            currentCanvasIndex++;
            if (currentCanvasIndex == 1)
            {
                RedoToolStripButton.Enabled = true;
            }
            if (currentCanvasIndex == LastCanvasUpdates.Count - 1)
            {
                UndoToolStripButton.Enabled = false;
            }
            HandleCanvas();
        }
        private void HandleCanvas()
        {
            Drawing drawing = LastCanvasUpdates[currentCanvasIndex];
            DrawingBoardPictureBox.Width = drawing.Width;
            DrawingBoardPictureBox.Height = drawing.Height;
            DrawingBitMap = (Bitmap)drawing.DrawingImage.Clone();
            Graphics = Graphics.FromImage(DrawingBitMap);
            DrawingBoardPictureBox.Image = DrawingBitMap;
        }

 
        private void TextSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SizeAsString = TextSizeToolStripComboBox.Text;
            int newSize = int.Parse(SizeAsString);
            Font originalFont = TextContentTextBox.Font; // The original font
            Font newFont = new Font(originalFont.FontFamily, newSize, originalFont.Style);
            TextContentTextBox.Font = newFont;
            TextContentTextBox.Refresh();
            AdjustTextBoxHeight(TextContentTextBox);
            AdjustTextBoxWidth(TextContentTextBox);
        }

        private void FontToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newFontName = FontToolStripComboBox.Text;
            Font originalFont = TextContentTextBox.Font; // The original font
            Font newFont = new Font(newFontName, originalFont.Size, originalFont.Style);
            TextContentTextBox.Font = newFont;
            TextContentTextBox.Refresh();
            AdjustTextBoxHeight(TextContentTextBox);
            AdjustTextBoxWidth(TextContentTextBox);
        }

        private void TextContentTextBox_TextChanged(object sender, EventArgs e)
        {
            AdjustTextBoxHeight((System.Windows.Forms.TextBox)(sender));
            AdjustTextBoxWidth((System.Windows.Forms.TextBox)(sender));
        }
        private void AdjustTextBoxHeight(System.Windows.Forms.TextBox textBox)
        {
            int preferredHeight = TextRenderer.MeasureText(textBox.Text, textBox.Font, new System.Drawing.Size(textBox.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;
            textBox.Height = Math.Max(preferredHeight, textBox.Font.Height + 2); // Adding some padding
        }
        private void AdjustTextBoxWidth(System.Windows.Forms.TextBox textBox)
        {
            int maxWidth = BackgroundPanel.Width + BackgroundPanel.Location.X - textBox.Location.X;
            int minWidth = 100;
            int preferredWidth = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.Width = Math.Min(preferredWidth, maxWidth);
            textBox.Width = Math.Max(minWidth, Math.Min(preferredWidth, maxWidth));
            textBox.Multiline = (preferredWidth > maxWidth);
        }

        private void DrawingBoardPictureBox_Click(object sender, EventArgs e)
        {
            if (TextContentTextBox.Visible)
            {
                if (IsTextContentTextBoxEntered)
                {
                    ShowText();
                }
            }
        }
        private void TextContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowText();
            }
        }
        private void ShowText()
        {
            IsTextContentTextBoxEntered = false;
            string Text = TextContentTextBox.Text;
            if (Text != "")
            {
                string Font = FontToolStripComboBox.Text;
                string SizeAsString = TextSizeToolStripComboBox.Text;
                int Size = int.Parse(SizeAsString);
                FontStyle FontStyle = FontStyle.Regular; 

                if (IsTextBold)
                    FontStyle |= FontStyle.Bold;

                if (IsTextItalic)
                    FontStyle |= FontStyle.Italic;

                if (IsTextUnderline)
                    FontStyle |= FontStyle.Underline;

                if (IsTextStrikeout)
                    FontStyle |= FontStyle.Strikeout;

                Font DrawFont = new Font(Font, Size, FontStyle);
                SolidBrush drawBrush = new SolidBrush(BrushColor);

                Graphics.DrawString(Text, DrawFont, drawBrush, TextContentTextBox.Location.X, TextContentTextBox.Location.Y);
                DrawingBoardPictureBox.Image = DrawingBitMap;

            }
            TextContentTextBox.Text = "";
            TextContentTextBox.Visible = false;
            PaintOption_IsChosenList[2] = false;
            TextToolStrip.Visible = false;
            InsertDrawing();
        }

        private void TextColorChange(object sender, EventArgs e)
        {
            BrushColor = ((ToolStripButton)(sender)).BackColor;
            TextContentTextBox.ForeColor = BrushColor;
        }



        private void SendOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            finalImage = LastCanvasUpdates[currentCanvasIndex].DrawingImage;
        }

        private void ChangeBackgroundColor(Color BackgroundColor)
        {
            for (int i = 0; i < DrawingWidth; i++)
            {
                for (int j = 0; j < DrawingHeight; j++)
                {
                    if ((i >= BackgroundImageWidth) && (j >= BackgroundImageHeight))
                        DrawingBitMap.SetPixel(i, j, BackgroundColor);
                }
            }
        }
    }
}
