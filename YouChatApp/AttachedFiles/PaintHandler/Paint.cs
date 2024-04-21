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
        Image UndoIsShown = global::YouChatApp.Properties.Resources.Undo;
        Image UndoIsNotShown = global::YouChatApp.Properties.Resources.UndoNotPressed;
        Image RedoIsShown = global::YouChatApp.Properties.Resources.Redo;
        Image RedoIsNotShown = global::YouChatApp.Properties.Resources.RedoNotPressed;
        List<Drawing> LastCanvasUpdates; //needs to also keep the canvas size...
        int currentCanvasIndex = 0;
        Image currentCanvas;
        Graphics Graphics;
        int CursorX = -1;
        int CursorY = -1;
        int X;
        int Y;
        int cX;
        int cY;
        int CursorWidth;
        int CursorHeight;
        /// <summary>
        /// Represents which one of the drawing should happen...
        /// Index 0 -> Pencil
        /// Index 1 -> Eraser
        /// Index 2 -> Text
        /// Index 3 -> Line
        /// Index 4 -> Circle
        /// Index 5 -> Rectangle
        /// Index 6 -> Triangle
        /// Index 7 -> Fill
        /// </summary>
        bool[] PaintOptionIsChosenList;
        int DrawingWidth, DrawingHeight;
        int BackgroundImageWidth = 0, BackgroundImageHeight = 0;

        Bitmap DrawingBitMap;
        Bitmap TemporaryBitMap;
        int PenSize = 5;
        Pen DrawingPen = new Pen(Color.Black, 5); //change the 5 to pen size...
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Graphics TemporaryGraphics;
        bool IsCursorMoving = false;
        bool IsDrawing = false;
        Image OpenedBackgroundImage;
        int ColoredButtons = 4;
        Image ExportImage;
        Color BackgroundColor = Color.White;
        Color PenColor = Color.Black;
        Color BrushColor = Color.Black;
        int TextBoxCount = 0;
        bool IsTextContentTextBoxEntered = false;

        bool IsTextBold = false;
        bool IsTextItalic = false;
        bool IsTextUnderline = false;
        bool IsTextStrikeout = false;
        static public Image finalImage;

        //whenever a color is selected the border will become green...
        //in the menu there will be the last chosen colors...
        public Paint()
        {
            InitializeComponent();
            InitializeGraphics();
            InitializeLastCanvasUpdates();
            //SetBitMap();
            PaintOptionIsChosenList = new bool[8];
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
            //Graphics = DrawingBoardPictureBox.CreateGraphics();
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
            //LastCanvasUpdates = new Image[15];
            //LastCanvasUpdates[0] = DrawingBoardPictureBox.Image; //maybe i should use a two-way list and then just run on it with the undo redo...'
            if (LastCanvasUpdates != null)
            {
                foreach (Drawing drawing in LastCanvasUpdates)
                {
                    drawing.DrawingImage.Dispose();
                }
            }
            LastCanvasUpdates = new List<Drawing>();
            InsertDrawing();
            UndoToolStripButton.Enabled = false; // can also add if with a bool var...

        }
        private void InsertDrawing()
        {
            UndoToolStripButton.Enabled = true;
            RedoToolStripButton.Enabled = false;

            //Drawing drawing = new Drawing(DrawingWidth, DrawingHeight, DrawingBoardPictureBox.Image);
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
            for (int Index = 0; Index < PaintOptionIsChosenList.Length; Index++)
            {
                PaintOptionIsChosenList[Index] = false;
            }
        }


        //private void DrawingBoardPictureBox_MouseState(object sender, MouseEventArgs e) //was used for both mousedown and mouse up...
        //{
        //    IsDrawing = !IsDrawing; //todo solve the problem...
        //}
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

            if(PaintOptionIsChosenList[3])
            {
                Graphics.DrawLine(DrawingPen, cX, cY, X, Y);
                DrawingBoardPictureBox.Image = DrawingBitMap;
            }
            else if (PaintOptionIsChosenList[4])
            {
                Graphics.DrawEllipse(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = DrawingBitMap;


            }
            else if (PaintOptionIsChosenList[5])
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
            //if (IsDrawing)
            //{
            //    Graphics graphics = Graphics.FromImage(DrawingBitMap);
            //    graphics.DrawRectangle(DrawingPen, e.X, e.Y, PenSize, PenSize); //needs to check if this is the best way...
            //    DrawingBoardPictureBox.Image = DrawingBitMap;
            //}

            if ((CursorX != -1) && (CursorY != -1) && (IsCursorMoving))
            {

                IsDrawing = true;
                if (PaintOptionIsChosenList[0] || PaintOptionIsChosenList[1])
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
            //when mouse down i need to save a copy of the current board in order to return to it later - i need to use an array that has the ability to save the 15 last images for example...
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
                    switch (PaintSaveFileDialog.FilterIndex)//todo change switch with if... or learn that method
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
                //System.IO.FileStream FileStreamConnection = (System.IO.FileStream)PaintSaveFileDialog.OpenFile();
                //switch (PaintSaveFileDialog.FilterIndex)//todo change switch with if... or learn that method
                //{
                //    case 0:
                //        image.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Jpeg);
                //        break;
                //    case 1:
                //        image.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Png);
                //        break;
                //    case 2:
                //        image.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Bmp);
                //        break;
                //}

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
                //DrawingBoardPictureBox.BackgroundImage = OpenedBackgroundImage;
                //trying to add the picture to the canvas instead: in that case i will need to save the current drawing and then to copy it on top of the image
                Graphics.DrawImage(scaledImage, 0, 0, newWidth, newHeight); //maybe i should let the user select the location - meaning where he pressed will be the location the top right will be
                DrawingBoardPictureBox.Image = DrawingBitMap;
                InsertDrawing();

            }
        }

        private Image MergeBackgroundImageAndImage()
        {
            Image DrawingBoardBackgroundImage = DrawingBoardPictureBox.BackgroundImage;
            Image DrawingBoardImage = DrawingBoardPictureBox.Image; //todo - needs to save a bitmap for only the drawing and for everything this way i will be able to do this..
            Bitmap MergedBitmap = new Bitmap(DrawingWidth, DrawingHeight);

            if (DrawingBoardPictureBox.BackgroundImage != null)
            {
                using (Graphics graphics = Graphics.FromImage(MergedBitmap))
                {
                    graphics.DrawImage(DrawingBoardBackgroundImage, new PointF(0, 0));
                    graphics.DrawImage(DrawingBoardImage, new PointF(0, 0));
                }
                ExportImage = MergedBitmap;
            }
            else
            {
                if (BackgroundColor == Color.Transparent)
                    ChangeBackgroundColor(Color.White);
                else
                    ChangeBackgroundColor(BackgroundColor);
                ExportImage = DrawingBoardPictureBox.Image;
            }
            return ExportImage;
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
                    PaintToolStrip.Items.Remove(ButtonToMoveToBegining); // Remove the button from its current position
                    PaintToolStrip.Items.Insert(2, ButtonToMoveToBegining); // Insert the button at the first position
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
                    TextToolStrip.Items.Remove(ButtonToMoveToBegining); // Remove the button from its current position
                    TextToolStrip.Items.Insert(0, ButtonToMoveToBegining); // Insert the button at the first position
                }
                BrushColor = PaintColorDialog.Color; ;
                ButtonToMoveToBegining.BackColor = BrushColor;
                TextContentTextBox.ForeColor = BrushColor;
            }
        }

        private void SetPenSizeList()
        {
            //todo to create a list of pen size buttons and add them to the pensize headline...
        }

        private void DrawingBoardPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Graphics graphics = Graphics.FromImage(DrawingBitMap);
            //graphics.DrawEllipse(DrawingPen, e.X, e.Y, PenSize, PenSize);
            //DrawingBoardPictureBox.Image = DrawingBitMap;
            if (!IsDrawing)
            {
                if (PaintOptionIsChosenList[0] || PaintOptionIsChosenList[1])
                {
                    int left = e.X - PenSize / 2;
                    int top = e.Y - PenSize / 2;

                    // Draw the ellipse centered at (e.X, e.Y)
                    Graphics.DrawEllipse(DrawingPen, left, top, PenSize, PenSize);
                    DrawingBoardPictureBox.Image = DrawingBitMap;
                    InsertDrawing();
                }//maybe i need to use a timer and after mouse down to count  a second or something
                else if (PaintOptionIsChosenList[2])
                {
                    //needs to create a new textbox
                    //after leaving the textbox need to make it untouchable or else (better option) make a way to get rid of the border...
                    //AddNewTextContentTextBox();
                    TextContentTextBox.Visible = true;
                    //Point CursorLocation = this.PointToClient(((Control)sender).PointToScreen(e.Location));

                    //TextContentTextBox.Location = new System.Drawing.Point(CursorLocation.X, CursorLocation.Y);
                    TextContentTextBox.Location = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        static Point SetPoint(PictureBox PictureBox, Point Point)
        {
            float PointX = 1f * PictureBox.Image.Width / PictureBox.Width;
            float PointY = 1f * PictureBox.Image.Height / PictureBox.Height;
            return new Point((int)(Point.X * PointX), (int)(Point.Y * PointY));

        }


        private void PencilToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[0] = true;
            DrawingPen.Color = PenColor;

        }

        private void EraserToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[1] = true;
            DrawingPen.Color = Color.White;
        }

        private void TextToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[2] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = true;
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[3] = true;
            DrawingPen.Color = PenColor;

        }

        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[4] = true;
            DrawingPen.Color = PenColor;

        }

        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[5] = true;
            DrawingPen.Color = PenColor;

        }

        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[6] = true;
            DrawingPen.Color = PenColor;

        }

        private void FillToolStripButton_Click(object sender, EventArgs e)
        {
            //if (fontDialog1.ShowDialog() == DialogResult.OK)
            //{

            //}

            SetPaintOptionIsChosenListToFalse();
            PaintOptionIsChosenList[7] = true;
            DrawingPen.Color = PenColor;
        }

        private void TextContentTextBox_MouseLeave(object sender, EventArgs e) //maybe to switch this with mouse click anywhere else...
        {
            //if (IsTextContentTextBoxEntered)
            //{
            //    IsTextContentTextBoxEntered = false;
            //    string Text = TextContentTextBox.Text;
            //    if (Text != "")
            //    {
            //        string Font = FontToolStripComboBox.Text;
            //        string SizeAsString = TextSizeToolStripComboBox.Text;
            //        int Size = int.Parse(SizeAsString);
            //        FontStyle FontStyle = FontStyle.Regular; // Start with regular style

            //        // Apply styles based on boolean values
            //        if (IsTextBold)
            //            FontStyle |= FontStyle.Bold;

            //        if (IsTextItalic)
            //            FontStyle |= FontStyle.Italic;

            //        if (IsTextUnderline)
            //            FontStyle |= FontStyle.Underline;

            //        if (IsTextStrikeout)
            //            FontStyle |= FontStyle.Strikeout;

            //        Font DrawFont = new Font(Font, Size, FontStyle);
            //        SolidBrush drawBrush = new SolidBrush(BrushColor);
            //        Graphics.DrawString(Text, DrawFont, drawBrush, TextContentTextBox.Location.X, TextContentTextBox.Location.Y);
            //        DrawingBoardPictureBox.Image = DrawingBitMap;

            //    }
            //    TextContentTextBox.Text = "";
            //    TextContentTextBox.Visible = false;
            //    PaintOptionIsChosenList[2] = false;
            //    TextToolStrip.Visible = false;//needs to add a method of refreshing some of the things maybe?

            //}
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

            // Use the newFont as needed

            // Don't forget to dispose of the newFont when you're done
            TextContentTextBox.Font = newFont;
        }



        private void BoldtoolStripButton_Click(object sender, EventArgs e) //to change the visuallity as well for the for of them... (to show they have been selected)
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

        private void DrawingBoardPictureBox_Paint(object sender, PaintEventArgs e) //todo - add a way that when drawing shapes, the current shape size and all will be shown - code below should have worked but it doesnt - maybe because the way i am using grapics
        {
            //SetShapes();
        }

        public void SetShapes()
        {
            //CopyBitMap(DrawingBitMap, TemporaryBitMap);

            //if ((isCropping)&& (e.Button == MouseButtons.Left))
            //{
            //    // Resize the selection region
            //    selectionCropRectangle.Width = e.X - selectionCropRectangle.X;
            //    selectionCropRectangle.Height = e.Y - selectionCropRectangle.Y;
            //    UserImageTakenPictureBox.Invalidate();
            //}
            //DrawingBoardPictureBox.Image = currentCanvas;
            //DrawingBoardPictureBox.Image = DrawingBitMap;
            TemporaryBitMap = new Bitmap(DrawingBitMap);
            //Graphics graphics = Graphics.FromImage(TemporaryBitMap);
            TemporaryGraphics = Graphics.FromImage(TemporaryBitMap);

            //    DrawingBoardPictureBox.Image = DrawingBitMap;
            if (PaintOptionIsChosenList[3])
            {
                TemporaryGraphics.DrawLine(DrawingPen, cX, cY, X, Y);
                DrawingBoardPictureBox.Image = TemporaryBitMap;

            }
            else if (PaintOptionIsChosenList[4])
            {
                TemporaryGraphics.DrawEllipse(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = TemporaryBitMap;
            }
            else if (PaintOptionIsChosenList[5])
            {
                TemporaryGraphics.DrawRectangle(DrawingPen, cX, cY, CursorWidth, CursorHeight);
                DrawingBoardPictureBox.Image = TemporaryBitMap;

            }
            //Graphics.DrawImage(currentCanvas, 0, 0);
            //DrawingBoardPictureBox.Image = currentCanvas;
            //DrawingBoardPictureBox.Invalidate();
        }
 

        private void BackgroundColorToolStripButton_Click(object sender, EventArgs e)
        {
            if (PaintColorDialog.ShowDialog() == DialogResult.OK)
            {
                Color ChosenColor = PaintColorDialog.Color;
                DrawingBoardPictureBox.Image = DrawingBitMap;
                ChangeBackgroundColor(ChosenColor);
                BackgroundColor = ChosenColor;
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

            using (Graphics g = Graphics.FromImage(flipped))
            {
                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                    new Rectangle(original.Width - 1, 0, -original.Width, original.Height), GraphicsUnit.Pixel);
            }

            return flipped;
        }
        private Bitmap FlipImageVertically(Bitmap original)
        {
            Bitmap flipped = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(flipped))
            {
                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
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

        private void TextContentTextBox_Leave(object sender, EventArgs e) //maybe when pressing enter and than to a add a tooltip explaining this
        {
            //if (IsTextContentTextBoxEntered)
            //{
            //    IsTextContentTextBoxEntered = false;
            //    string Text = TextContentTextBox.Text;
            //    if (Text != "")
            //    {
            //        string Font = FontToolStripComboBox.Text;
            //        string SizeAsString = TextSizeToolStripComboBox.Text;
            //        int Size = int.Parse(SizeAsString);
            //        FontStyle FontStyle = FontStyle.Regular; // Start with regular style

            //        // Apply styles based on boolean values
            //        if (IsTextBold)
            //            FontStyle |= FontStyle.Bold;

            //        if (IsTextItalic)
            //            FontStyle |= FontStyle.Italic;

            //        if (IsTextUnderline)
            //            FontStyle |= FontStyle.Underline;

            //        if (IsTextStrikeout)
            //            FontStyle |= FontStyle.Strikeout;

            //        Font DrawFont = new Font(Font, Size, FontStyle);
            //        SolidBrush drawBrush = new SolidBrush(BrushColor);
            //        Graphics.DrawString(Text, DrawFont, drawBrush, TextContentTextBox.Location.X, TextContentTextBox.Location.Y);
            //        DrawingBoardPictureBox.Image = DrawingBitMap;

            //    }
            //    TextContentTextBox.Text = "";
            //    TextContentTextBox.Visible = false;
            //    PaintOptionIsChosenList[2] = false;
            //    TextToolStrip.Visible = false;//needs to add a method of refreshing some of the things maybe?

            //}
        }

        private void FontToolStripComboBox_Click(object sender, EventArgs e)
        {

        }

        private void TextSizeToolStripComboBox_Click(object sender, EventArgs e)
        {

        }
        private void TextSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SizeAsString = TextSizeToolStripComboBox.Text;
            int newSize = int.Parse(SizeAsString);
            Font originalFont = TextContentTextBox.Font; // The original font

            // Create a new font with the desired font name
            Font newFont = new Font(originalFont.FontFamily, newSize, originalFont.Style);
            // Create a new font with the modified style

            // Use the newFont as needed

            // Don't forget to dispose of the newFont when you're done
            TextContentTextBox.Font = newFont;
            TextContentTextBox.Refresh();
            AdjustTextBoxHeight(TextContentTextBox);
            AdjustTextBoxWidth(TextContentTextBox);
        }

        private void FontToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newFontName = FontToolStripComboBox.Text;

            Font originalFont = TextContentTextBox.Font; // The original font

            // Create a new font with the desired font name
            Font newFont = new Font(newFontName, originalFont.Size, originalFont.Style);
            // Create a new font with the modified style

            // Use the newFont as needed

            // Don't forget to dispose of the newFont when you're done
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
            // Calculate the preferred height based on the text and the width
            int preferredHeight = TextRenderer.MeasureText(textBox.Text, textBox.Font, new System.Drawing.Size(textBox.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;

            // Set the new height, ensuring a minimum height
            textBox.Height = Math.Max(preferredHeight, textBox.Font.Height + 2); // Adding some padding
        }
        private void AdjustTextBoxWidth(System.Windows.Forms.TextBox textBox)
        {
            // Limit the width to a maximum value (e.g., 300)
            int maxWidth = BackgroundPanel.Width + BackgroundPanel.Location.X - textBox.Location.X;
            int minWidth = 100;
            // Calculate the preferred width based on the text length
            int preferredWidth = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            // Set the width of the TextBox, ensuring it doesn't exceed the maximum width
            textBox.Width = Math.Min(preferredWidth, maxWidth);
            textBox.Width = Math.Max(minWidth, Math.Min(preferredWidth, maxWidth));
            textBox.Multiline = (preferredWidth > maxWidth);

        }

        private void DrawingBoardPictureBox_Click(object sender, EventArgs e)
        {
            //System.Drawing.Point TextContentTextBoxRealLocation = TextContentTextBox.Location;
            //if (TextContentTextBox.Parent != null && TextContentTextBox.Parent is Panel) //panel location
            //{
            //    System.Drawing.Point panelLocation = TextContentTextBox.Parent.Location;
            //    TextContentTextBoxRealLocation.Offset(panelLocation.X, panelLocation.Y);
            //}
            //int pictureBoxRealXLocation = TextContentTextBoxRealLocation.X;
            //int pictureBoxRealYLocation = TextContentTextBoxRealLocation.Y;
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
                FontStyle FontStyle = FontStyle.Regular; // Start with regular style

                // Apply styles based on boolean values
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
            PaintOptionIsChosenList[2] = false;
            TextToolStrip.Visible = false;//needs to add a method of refreshing some of the things maybe?
            InsertDrawing();
        }

        private void TextColorChange(object sender, EventArgs e)
        {
            BrushColor = ((ToolStripButton)(sender)).BackColor;
            TextContentTextBox.ForeColor = BrushColor;
        }

        private void TextContentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Check if the Enter key is pressed
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    // Insert a line break
            //    int selectionStart = TextContentTextBox.SelectionStart;
            //    TextContentTextBox.Text = TextContentTextBox.Text.Insert(selectionStart, "\r\n");
            //    TextContentTextBox.SelectionStart = selectionStart + 2; // Move the caret after the inserted line break
            //    e.Handled = true; // Suppress the Enter key
            //}
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

        private void CopyBitMap(Bitmap CopyFromBitMap, Bitmap CopyToBitMap)
        {
            int Width = CopyFromBitMap.Width;
            int Height = CopyFromBitMap.Height;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color PixelColor = CopyFromBitMap.GetPixel(i, j);

                    CopyToBitMap.SetPixel(i, j, PixelColor);
                }
            }
        }
        // בשינוי צבע לעשות בדיקה האם תמונה מופיעה שם או לא ובהתאם לשנות את הצבע
    }
}
