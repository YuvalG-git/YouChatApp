using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class Paint : Form
    {
        int DrawingWidth, DrawingHeight;
        int BackgroundImageWidth = 0, BackgroundImageHeight = 0;

        Bitmap DrawingBitMap;
        int PenSize = 5;
        Pen DrawingPen = new Pen(Color.Black, 5); //change the 5 to pen size...
        bool IsDrawing = false;
        Image OpenedBackgroundImage;
        int ColoredButtons = 4;
        Image ExportImage;
        Color BackgroundColor = Color.White;
            //whenever a color is selected the border will become green...
            //in the menu there will be the last chosen colors...
        public Paint()
        {
            InitializeComponent();
            SetBitMap();
        }

        private void DrawingBoardPictureBox_MouseState(object sender, MouseEventArgs e)
        {
            IsDrawing = !IsDrawing; //todo solve the problem...
        }

        private void DrawingBoardPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                Graphics graphics = Graphics.FromImage(DrawingBitMap);
                graphics.DrawRectangle(DrawingPen, e.X, e.Y, PenSize, PenSize); //needs to check if this is the best way...
                DrawingBoardPictureBox.Image = DrawingBitMap;
            }
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
            MergeBackgroundImageAndImage();
            if (PaintSaveFileDialog.FileName != "")
            {
                System.IO.FileStream FileStreamConnection = (System.IO.FileStream)PaintSaveFileDialog.OpenFile();
                switch (PaintSaveFileDialog.FilterIndex)//todo change switch with if... or learn that method
                {
                    case 0:
                        ExportImage.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 1:
                        ExportImage.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 2:
                        ExportImage.Save(FileStreamConnection, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
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
                DrawingBoardPictureBox.BackColor = Color.Transparent;
                DrawingBoardPictureBox.BackgroundImage = OpenedBackgroundImage;
            }
        }

        private void MergeBackgroundImageAndImage()
        {
            DialogResult PaintDialogResult = PaintOpenFileDialog.ShowDialog();
            if (PaintDialogResult == DialogResult.OK)
            {
                Image DrawingBoardBackgroundImage = DrawingBoardPictureBox.BackgroundImage;
                Image DrawingBoardImage = DrawingBoardPictureBox.Image;
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
            }
        }

        private void DeleteOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = new Bitmap(DrawingWidth, DrawingHeight); //todo confirm about deleting
            DrawingBoardPictureBox.Image = DrawingBitMap;

        }

        public void SetBitMap()
        {
            DrawingWidth = DrawingBoardPictureBox.Width;
            DrawingHeight = DrawingBoardPictureBox.Height;
            DrawingBitMap = new Bitmap(DrawingWidth, DrawingHeight);
        }

        private void MultiColorOptionToolStripButton_Click(object sender, EventArgs e)
        {
            if (PaintColorDialog.ShowDialog() == DialogResult.OK)
            {
                ToolStripButton ButtonToMoveToBegining = PaintToolStrip.Items[ColoredButtons-1] as ToolStripButton;

                if (ButtonToMoveToBegining != null)
                {
                    PaintToolStrip.Items.Remove(ButtonToMoveToBegining); // Remove the button from its current position
                    PaintToolStrip.Items.Insert(0, ButtonToMoveToBegining); // Insert the button at the first position
                }
                ButtonToMoveToBegining.BackColor = PaintColorDialog.Color;
            }
        }

        private void DrawingBoardPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(DrawingBitMap);
            graphics.DrawEllipse(DrawingPen, e.X, e.Y, PenSize, PenSize);
            DrawingBoardPictureBox.Image = DrawingBitMap;
        }

        private void BackgroundColorToolStripButton_Click(object sender, EventArgs e)
        {
            if (PaintColorDialog.ShowDialog() == DialogResult.OK)
            {
                Color ChosenColor = PaintColorDialog.Color;
                ChangeBackgroundColor(ChosenColor);
                BackgroundColor = ChosenColor;
                DrawingBoardPictureBox.BackColor = ChosenColor;
            }
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
        // בשינוי צבע לעשות בדיקה האם תמונה מופיעה שם או לא ובהתאם לשנות את הצבע
    }
}
