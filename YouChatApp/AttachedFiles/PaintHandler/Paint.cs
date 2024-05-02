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
    /// <summary>
    /// The "Paint" class represents a form for painting and drawing operations.
    /// </summary>
    /// <remarks>
    /// This form provides functionality for painting and drawing images using various tools and options.
    /// It includes features such as choosing colors, selecting pen sizes, drawing shapes, writing text,
    /// and managing undo and redo operations.
    /// </remarks>
    public partial class Paint : Form
    {
        #region Private Drawing History Fields

        /// <summary>
        /// The List<Drawing> "LastCanvasUpdates" represents the list of last canvas updates.
        /// </summary>
        private List<Drawing> LastCanvasUpdates;

        /// <summary>
        /// The int "currentCanvasIndex" represents the index of the current canvas.
        /// </summary>
        private int currentCanvasIndex = 0;

        #endregion

        #region Private Graphics Fields

        /// <summary>
        /// The Graphics "Graphics" represents the graphics object.
        /// </summary>
        private Graphics Graphics;

        /// <summary>
        /// The Bitmap "DrawingBitMap" represents the bitmap for drawing.
        /// </summary>
        private Bitmap DrawingBitMap;

        /// <summary>
        /// The Bitmap "TemporaryBitMap" represents the temporary bitmap for drawing.
        /// </summary>
        private Bitmap TemporaryBitMap;

        /// <summary>
        /// The int "PenSize" represents the size of the pen.
        /// </summary>
        private int PenSize = 5;

        /// <summary>
        /// The Pen "DrawingPen" represents the pen for drawing.
        /// </summary>
        private Pen DrawingPen = new Pen(Color.Black, 5);

        /// <summary>
        /// The Graphics "TemporaryGraphics" represents the temporary graphics object.
        /// </summary>
        private Graphics TemporaryGraphics;

        /// <summary>
        /// The Color "PenColor" represents the color of the pen.
        /// </summary>
        private Color PenColor = Color.Black;

        /// <summary>
        /// The Color "BrushColor" represents the color of the brush.
        /// </summary>
        private Color BrushColor = Color.Black;

        #endregion

        #region Private Location Fields

        /// <summary>
        /// The int "CursorX" represents the X coordinate of the cursor.
        /// </summary>
        private int CursorX = -1;

        /// <summary>
        /// The int "CursorY" represents the Y coordinate of the cursor.
        /// </summary>
        private int CursorY = -1;

        /// <summary>
        /// The int "X" represents the X coordinate.
        /// </summary>
        private int X;

        /// <summary>
        /// The int "Y" represents the Y coordinate.
        /// </summary>
        private int Y;

        /// <summary>
        /// The int "cX" represents the X coordinate for the cursor.
        /// </summary>
        private int cX;

        /// <summary>
        /// The int "cY" represents the Y coordinate for the cursor.
        /// </summary>
        private int cY;

        /// <summary>
        /// The int "CursorWidth" represents the width of the cursor.
        /// </summary>
        private int CursorWidth;

        /// <summary>
        /// The int "CursorHeight" represents the height of the cursor.
        /// </summary>
        private int CursorHeight;

        /// <summary>
        /// The int "DrawingWidth" represents the width of the drawing area.
        /// </summary>
        private int DrawingWidth;

        /// <summary>
        /// The int "DrawingHeight" represents the height of the drawing area.
        /// </summary>
        private int DrawingHeight;

        /// <summary>
        /// The int "BackgroundImageWidth" represents the width of the background image.
        /// </summary>
        private int BackgroundImageWidth = 0;

        /// <summary>
        /// The int "BackgroundImageHeight" represents the height of the background image.
        /// </summary>
        private int BackgroundImageHeight = 0;

        #endregion

        #region Private Font Fields

        /// <summary>
        /// The bool "IsTextBold" indicates whether the text is bold.
        /// </summary>
        private bool IsTextBold = false;

        /// <summary>
        /// The bool "IsTextItalic" indicates whether the text is italic.
        /// </summary>
        private bool IsTextItalic = false;

        /// <summary>
        /// The bool "IsTextUnderline" indicates whether the text is underlined.
        /// </summary>
        private bool IsTextUnderline = false;

        /// <summary>
        /// The bool "IsTextStrikeout" indicates whether the text is strikeout.
        /// </summary>
        private bool IsTextStrikeout = false;

        #endregion

        #region Private Fields

        /// <summary>
        /// The bool array "PaintOption_IsChosenList" indicates whether each paint option is chosen.
        /// Index 0 -> Pencil
        /// Index 1 -> Eraser
        /// Index 2 -> Text
        /// Index 3 -> Line
        /// Index 4 -> Circle
        /// Index 5 -> Rectangle
        /// </summary>
        private bool[] PaintOption_IsChosenList;

        /// <summary>
        /// The bool "IsCursorMoving" indicates whether the cursor is moving.
        /// </summary>
        private bool IsCursorMoving = false;

        /// <summary>
        /// The bool "IsDrawing" indicates whether drawing is in progress.
        /// </summary>
        private bool IsDrawing = false;

        /// <summary>
        /// The Image "OpenedBackgroundImage" represents the opened background image.
        /// </summary>
        private Image OpenedBackgroundImage;

        /// <summary>
        /// The bool "IsTextContentTextBoxEntered" indicates whether text content textbox is entered.
        /// </summary>
        private bool IsTextContentTextBoxEntered = false;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "UndoIsShown" represents the image for when undo is shown.
        /// </summary>
        private readonly Image UndoIsShown = global::YouChatApp.Properties.Resources.Undo;

        /// <summary>
        /// The readonly Image "UndoIsNotShown" represents the image for when undo is not shown.
        /// </summary>
        private readonly Image UndoIsNotShown = global::YouChatApp.Properties.Resources.UndoNotPressed;

        /// <summary>
        /// The readonly Image "RedoIsShown" represents the image for when redo is shown.
        /// </summary>
        private readonly Image RedoIsShown = global::YouChatApp.Properties.Resources.Redo;

        /// <summary>
        /// The readonly Image "RedoIsNotShown" represents the image for when redo is not shown.
        /// </summary>
        private readonly Image RedoIsNotShown = global::YouChatApp.Properties.Resources.RedoNotPressed;

        /// <summary>
        /// The readonly int "ColoredButtons" represents the number of colored buttons.
        /// </summary>
        private readonly int ColoredButtons = 4;

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The static Image "finalImage" represents the final image.
        /// </summary>
        private static Image finalImage;

        #endregion

        #region Constructors

        /// <summary>
        /// The "Paint" constructor initializes a new instance of the <see cref="Paint"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up various components for the Paint application, including initializing the form,
        /// initializing graphics, setting up canvas updates, and initializing lists and combo boxes for text content and font size.
        /// </remarks>
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

        #endregion

        #region Static Properties

        /// <summary>
        /// The "FinalImage" property represents the final image.
        /// It gets or sets the final image.
        /// </summary>
        /// <value>
        /// The final image.
        /// </value>
        public static Image FinalImage
        {
            get
            {
                return finalImage;
            }
            set
            {
                finalImage = value;
            }
        }

        #endregion

        #region Private Initializion Methods

        /// <summary>
        /// The "SetBitMap" method initializes the DrawingBitMap and TemporaryBitMap with the dimensions of the DrawingBoardPictureBox.
        /// </summary>
        /// <remarks>
        /// This method is called to set up the bitmaps used for drawing on the DrawingBoardPictureBox.
        /// It creates new bitmaps with the same width and height as the DrawingBoardPictureBox.
        /// </remarks>
        private void SetBitMap()
        {
            DrawingWidth = DrawingBoardPictureBox.Width;
            DrawingHeight = DrawingBoardPictureBox.Height;
            DrawingBitMap = new Bitmap(DrawingWidth, DrawingHeight);
            TemporaryBitMap = new Bitmap(DrawingWidth, DrawingHeight);
        }

        /// <summary>
        /// The "InitializeGraphics" method sets up the graphics objects for drawing on the DrawingBoardPictureBox.
        /// </summary>
        /// <remarks>
        /// This method initializes the Graphics object with anti-aliasing for smooth drawing.
        /// It also sets up the DrawingPen with round start and end caps for better visual appearance.
        /// The TemporaryGraphics object is initialized for temporary drawing operations.
        /// The DrawingBoardPictureBox is cleared with a white background and set to display the DrawingBitMap.
        /// </remarks>
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

        /// <summary>
        /// The "InitializeLastCanvasUpdates" method initializes the LastCanvasUpdates list.
        /// </summary>
        /// <remarks>
        /// If the LastCanvasUpdates list is not null, it disposes of all the DrawingImage objects in the list.
        /// It then creates a new empty list and calls the InsertDrawing method to add the current drawing to the list.
        /// Finally, it disables the UndoToolStripButton.
        /// </remarks>
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

        /// <summary>
        /// The "InitializeFontToolStripComboBox" method initializes the FontToolStripComboBox with available font names.
        /// </summary>
        /// <remarks>
        /// It iterates through all available font families and adds their names to the FontToolStripComboBox.
        /// The default selected index is set to 3.
        /// </remarks>
        private void InitializeFontToolStripComboBox()
        {
            foreach (FontFamily Font in System.Drawing.FontFamily.Families)
            {
                FontToolStripComboBox.Items.Add(Font.Name);
            }
            FontToolStripComboBox.SelectedIndex = 3;
        }

        #endregion

        #region Private Drawing History Methods

        /// <summary>
        /// The "InsertDrawing" method inserts the current drawing into the LastCanvasUpdates list.
        /// </summary>
        /// <remarks>
        /// It enables the UndoToolStripButton and disables the RedoToolStripButton.
        /// It creates a new Bitmap from the DrawingBitMap and then creates a new Drawing object with the current image.
        /// The new Drawing object is inserted at index 0 of the LastCanvasUpdates list, and the currentCanvasIndex is set to 0.
        /// </remarks>
        private void InsertDrawing()
        {
            UndoToolStripButton.Enabled = true;
            RedoToolStripButton.Enabled = false;

            Image currentImage = new Bitmap(DrawingBitMap);
            Drawing drawing = new Drawing(DrawingWidth, DrawingHeight, currentImage);

            LastCanvasUpdates.Insert(0, drawing);
            currentCanvasIndex = 0;
        }

        #endregion

        #region Private Painting Options Methods

        /// <summary>
        /// The "SetPaintOptionIsChosenListToFalse" method sets all elements in the PaintOption_IsChosenList array to false.
        /// </summary>
        /// <remarks>
        /// It iterates through the PaintOption_IsChosenList array and sets each element to false.
        /// </remarks>
        private void SetPaintOptionIsChosenListToFalse()
        {
            for (int Index = 0; Index < PaintOption_IsChosenList.Length; Index++)
            {
                PaintOption_IsChosenList[Index] = false;
            }
        }

        /// <summary>
        /// The "PencilToolStripButton_Click" method handles the click event for the pencil tool in the toolbar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the paint option is chosen list to false, sets the pencil tool as chosen, and updates the drawing pen color.
        /// </remarks>
        private void PencilToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[0] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = false;
        }

        /// <summary>
        /// The "EraserToolStripButton_Click" method handles the click event for the eraser tool in the toolbar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the paint option is chosen list to false, sets the eraser tool as chosen, and updates the drawing pen color to white.
        /// </remarks>
        private void EraserToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[1] = true;
            DrawingPen.Color = Color.White;
            TextToolStrip.Visible = false;
        }

        /// <summary>
        /// The "TextToolStripButton_Click" method handles the click event for the text tool in the toolbar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the paint option is chosen list to false, sets the text tool as chosen, updates the drawing pen color to the selected pen color,
        /// and makes the text tool strip visible.
        /// </remarks>
        private void TextToolStripButton_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[2] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = true;
        }

        /// <summary>
        /// The "LineToolStripMenuItem_Click" method handles the click event for drawing a line in the toolbar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the paint option is chosen list to false, sets the line tool as chosen, and updates the drawing pen color to the selected pen color.
        /// </remarks>
        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[3] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = false;
        }

        /// <summary>
        /// The "CircleToolStripMenuItem_Click" method handles the click event for drawing a circle in the toolbar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the paint option is chosen list to false, sets the circle tool as chosen, and updates the drawing pen color to the selected pen color.
        /// </remarks>
        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[4] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = false;
        }

        /// <summary>
        /// The "RectangleToolStripMenuItem_Click" method handles the click event for drawing a rectangle in the toolbar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the paint option is chosen list to false, sets the rectangle tool as chosen, and updates the drawing pen color to the selected pen color.
        /// </remarks>
        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPaintOptionIsChosenListToFalse();
            PaintOption_IsChosenList[5] = true;
            DrawingPen.Color = PenColor;
            TextToolStrip.Visible = false;
        }

        #endregion

        #region Private Mouse Methods

        /// <summary>
        /// The "DrawingBoardPictureBox_Click" method handles the click event on the DrawingBoardPictureBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the TextContentTextBox is visible and if the IsTextContentTextBoxEntered flag is set.
        /// If both conditions are true, it calls the ShowText method to display the text at the clicked position.
        /// </remarks>
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

        /// <summary>
        /// The "DrawingBoardPictureBox_MouseDown" method handles the mouse down event on the DrawingBoardPictureBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The MouseEventArgs containing event data.</param>
        /// <remarks>
        /// It sets IsCursorMoving to true, captures the current cursor position (CursorX and CursorY),
        /// and sets cX and cY to the current cursor position.
        /// </remarks>
        private void DrawingBoardPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsCursorMoving = true;
            CursorX = e.X;
            CursorY = e.Y;
            cX = e.X;
            cY = e.Y;        
        }

        /// <summary>
        /// The "DrawingBoardPictureBox_MouseUp" method handles the mouse up event on the DrawingBoardPictureBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The MouseEventArgs containing event data.</param>
        /// <remarks>
        /// It sets IsCursorMoving to false, resets the cursor position (CursorX and CursorY) to -1,
        /// calculates the cursor's width and height, and then based on the selected paint option, 
        /// draws a line, ellipse, or rectangle on the DrawingBoardPictureBox using the Graphics object.
        /// It updates the DrawingBoardPictureBox's image with the DrawingBitMap and, if IsDrawing is true,
        /// inserts the current drawing into the LastCanvasUpdates list.
        /// Finally, it sets IsDrawing to false.
        /// </remarks>
        private void DrawingBoardPictureBox_MouseUp(object sender, MouseEventArgs e)
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

        /// <summary>
        /// The "DrawingBoardPictureBox_MouseMove" method handles the mouse move event on the DrawingBoardPictureBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The MouseEventArgs containing event data.</param>
        /// <remarks>
        /// If the cursor position (CursorX and CursorY) is not -1 and IsCursorMoving is true,
        /// it sets IsDrawing to true and, based on the selected paint option, draws a line from the 
        /// previous cursor position to the current mouse location using the Graphics object.
        /// It updates the DrawingBoardPictureBox's image with the DrawingBitMap and updates the cursor position.
        /// If the current paint option is not for freehand drawing (e.g., line or shape), it calls the SetShapes method.
        /// Finally, it updates the current cursor position (X and Y) and calculates the cursor's width and height.
        /// </remarks>
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

        /// <summary>
        /// The "DrawingBoardPictureBox_MouseClick" method handles the mouse click event on the drawing board picture box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// If not in drawing mode, it checks if the pencil or brush tool is selected and draws a small ellipse at the clicked location.
        /// If the text tool is selected, it shows the text content text box at the clicked location for entering text.
        /// </remarks>
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

        #endregion

        #region Private Drawing Pen Properties Methods

        /// <summary>
        /// The "ColorChange_Click" method handles the click event of color change buttons.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// It sets the DrawingPen's color to the BackColor of the clicked ToolStripButton.
        /// </remarks>
        private void ColorChange_Click(object sender, EventArgs e)
        {
            DrawingPen.Color = ((ToolStripButton)(sender)).BackColor;
        }

        /// <summary>
        /// The "PenSizeChangeValue_Click" method handles the click event of pen size change ToolStripMenuItems.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// It parses the Text of the clicked ToolStripMenuItem to an integer and sets the PenSize to that value.
        /// It then sets the DrawingPen's width to the PenSize.
        /// </remarks>
        private void PenSizeChangeValue_Click(object sender, EventArgs e)
        {
            PenSize = int.Parse(((ToolStripMenuItem)(sender)).Text);
            DrawingPen.Width = (float)PenSize;
        }

        /// <summary>
        /// The "MultiColorOptionToolStripButton_Click" method handles the click event for the multi-color option button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// If the color dialog result is OK, it moves the last colored button to the beginning of the tool strip,
        /// updates the pen color and button color, and sets the drawing pen color to the selected color.
        /// </remarks>
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

        /// <summary>
        /// The "BackgroundColorToolStripButton_Click" method handles the event when the background color button is clicked.
        /// It opens a color dialog to allow the user to choose a color for the background of the drawing board.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
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

        #endregion

        #region Private Paint Options Methods

        /// <summary>
        /// The "SendOptionToolStripMenuItem_Click" method handles the event when the user clicks the Send option.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the DialogResult of the form to OK, indicating that the user has chosen to send the final image.
        /// It retrieves the final image from the LastCanvasUpdates list based on the current canvas index.
        /// </remarks>
        private void SendOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            finalImage = LastCanvasUpdates[currentCanvasIndex].DrawingImage;
        }

        /// <summary>
        /// The "SaveOptionToolStripMenuItem_Click" method handles the click event of the save option ToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// It sets the filter and title for the save file dialog, then shows the dialog to allow the user to choose where to save the image.
        /// It gets the image to save from the last canvas update at the current canvas index.
        /// If a valid file name is chosen, it opens a FileStream and saves the image in the selected format based on the filter index.
        /// </remarks>
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

        /// <summary>
        /// The "OpenOptionToolStripMenuItem_Click" method handles the click event of the open option ToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// It shows an open file dialog to allow the user to choose an image file to open.
        /// If a file is chosen, it loads the image and sets it as the background image.
        /// It then resizes and draws the image on the drawing board, updating the drawing bitmap and inserting a new drawing.
        /// </remarks>
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

        /// <summary>
        /// The "DeleteOptionToolStripMenuItem_Click" method handles the click event of the delete option ToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// It deletes the current canvas, inserts a new drawing, and initializes the last canvas updates.
        /// </remarks>
        private void DeleteOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCanvas();
            InsertDrawing();
            InitializeLastCanvasUpdates();
        }

        #endregion

        #region Private Delete Canvas Methods

        /// <summary>
        /// The "DeleteCanvas" method deletes the current canvas by creating a new empty bitmap and updating the drawing board picture box.
        /// </summary>
        /// <remarks>
        /// It then inserts a new drawing to track the change.
        /// </remarks>
        private void DeleteCanvas()
        {
            DrawingBitMap = new Bitmap(DrawingWidth, DrawingHeight);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        /// <summary>
        /// The "Paint_FormClosing" method handles the form closing event.
        /// It deletes the current canvas to free up resources before closing the form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Paint_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteCanvas();
        }

        #endregion

        #region Private Text Properties Methods

        /// <summary>
        /// The "TextColorChange" method handles the event when the text color is changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the BrushColor to the BackColor of the ToolStripButton that triggered the event.
        /// It then sets the ForeColor of the TextContentTextBox to the selected BrushColor, changing the text color.
        /// </remarks>
        private void TextColorChange(object sender, EventArgs e)
        {
            BrushColor = ((ToolStripButton)(sender)).BackColor;
            TextContentTextBox.ForeColor = BrushColor;
        }

        /// <summary>
        /// The "TextMultiColorOptionToolStripButton_Click" method handles the click event for the text multi-color option button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// If the color dialog result is OK, it moves the last colored button to the beginning of the tool strip,
        /// updates the brush color and button color, and sets the text content text box foreground color to the selected color.
        /// </remarks>
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

        /// <summary>
        /// The "TextSizeToolStripComboBox_SelectedIndexChanged" method handles the event when the selected index changes in the TextSizeToolStripComboBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the selected text size from the TextSizeToolStripComboBox and parses it to an integer.
        /// It then creates a new font with the selected size and the same style as the original font of the TextContentTextBox.
        /// The TextContentTextBox's font is updated to the new font, and the TextBox is refreshed.
        /// Finally, it adjusts the height and width of the TextContentTextBox to accommodate the new font size.
        /// </remarks>
        private void TextSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SizeAsString = TextSizeToolStripComboBox.Text;
            int newSize = int.Parse(SizeAsString);
            Font originalFont = TextContentTextBox.Font;
            Font newFont = new Font(originalFont.FontFamily, newSize, originalFont.Style);
            TextContentTextBox.Font = newFont;
            TextContentTextBox.Refresh();
            AdjustTextBoxHeight(TextContentTextBox);
            AdjustTextBoxWidth(TextContentTextBox);
        }

        /// <summary>
        /// The "FontToolStripComboBox_SelectedIndexChanged" method handles the event when the selected index changes in the FontToolStripComboBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the selected font name from the FontToolStripComboBox.
        /// It then creates a new font with the selected font name, the same size, and style as the original font of the TextContentTextBox.
        /// The TextContentTextBox's font is updated to the new font, and the TextBox is refreshed.
        /// Finally, it adjusts the height and width of the TextContentTextBox to accommodate the new font.
        /// </remarks>
        private void FontToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newFontName = FontToolStripComboBox.Text;
            Font originalFont = TextContentTextBox.Font;
            Font newFont = new Font(newFontName, originalFont.Size, originalFont.Style);
            TextContentTextBox.Font = newFont;
            TextContentTextBox.Refresh();
            AdjustTextBoxHeight(TextContentTextBox);
            AdjustTextBoxWidth(TextContentTextBox);
        }

        #endregion

        #region Private TextBox Methods

        /// <summary>
        /// The "TextContentTextBox_KeyDown" method handles the KeyDown event on the TextContentTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the key pressed is the Enter key.
        /// If it is, it calls the ShowText method to display the text.
        /// </remarks>
        private void TextContentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowText();
            }
        }

        /// <summary>
        /// The "TextContentTextBox_MouseDown" method handles the mouse down event for the text content text box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Sets the "IsTextContentTextBoxEntered" flag to true, indicating that the text content text box has been entered.
        /// </remarks>
        private void TextContentTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsTextContentTextBoxEntered = true;
        }

        /// <summary>
        /// The "TextContentTextBox_TextChanged" method handles the event when the text content of the TextContentTextBox changes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adjusts the height and width of the TextContentTextBox to accommodate the new text content.
        /// </remarks>
        private void TextContentTextBox_TextChanged(object sender, EventArgs e)
        {
            AdjustTextBoxHeight((System.Windows.Forms.TextBox)(sender));
            AdjustTextBoxWidth((System.Windows.Forms.TextBox)(sender));
        }

        /// <summary>
        /// The "AdjustTextBoxHeight" method adjusts the height of the specified TextBox to fit its content.
        /// </summary>
        /// <param name="textBox">The TextBox whose height needs to be adjusted.</param>
        /// <remarks>
        /// This method calculates the preferred height of the TextBox based on its current font and text content, considering word wrapping.
        /// The TextBox's height is set to the maximum of the preferred height and the height of a single line of text plus a small buffer.
        /// </remarks>
        private void AdjustTextBoxHeight(System.Windows.Forms.TextBox textBox)
        {
            int preferredHeight = TextRenderer.MeasureText(textBox.Text, textBox.Font, new System.Drawing.Size(textBox.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;
            textBox.Height = Math.Max(preferredHeight, textBox.Font.Height + 2);
        }

        /// <summary>
        /// The "AdjustTextBoxWidth" method adjusts the width of the specified TextBox to fit its content within the available space.
        /// </summary>
        /// <param name="textBox">The TextBox whose width needs to be adjusted.</param>
        /// <remarks>
        /// This method calculates the maximum width available for the TextBox based on the size of the BackgroundPanel.
        /// It then calculates the preferred width of the TextBox based on its current font and text content.
        /// The TextBox's width is set to the minimum of the preferred width and the maximum width available.
        /// If the preferred width exceeds the maximum width available, the TextBox is set to multiline mode.
        /// </remarks>
        private void AdjustTextBoxWidth(System.Windows.Forms.TextBox textBox)
        {
            int maxWidth = BackgroundPanel.Width + BackgroundPanel.Location.X - textBox.Location.X;
            int minWidth = 100;
            int preferredWidth = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.Width = Math.Min(preferredWidth, maxWidth);
            textBox.Width = Math.Max(minWidth, Math.Min(preferredWidth, maxWidth));
            textBox.Multiline = (preferredWidth > maxWidth);
        }

        #endregion

        #region Private Text Font Methods

        /// <summary>
        /// The "ChangeTextContentTextBoxFont" method changes the font style of the text content text box.
        /// </summary>
        /// <param name="fontStyle">The font style to apply (e.g., bold, italic, underline).</param>
        /// <remarks>
        /// If the specified font style is already applied to the text box font, it is removed. 
        /// Otherwise, it is added.
        /// </remarks>
        private void ChangeTextContentTextBoxFont(FontStyle fontStyle)
        {
            Font originalFont = TextContentTextBox.Font;
            FontStyle style = fontStyle;
            FontStyle newStyle;

            // Checks if the style to remove is present in the original font
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

        /// <summary>
        /// The "BoldtoolStripButton_Click" method toggles the bold font style for the text content text box.
        /// </summary>
        /// <remarks>
        /// If the text is currently bold, the method removes the bold style. 
        /// If the text is not bold, the method applies the bold style.
        /// </remarks>
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

        /// <summary>
        /// The "ItalicToolStripButton_Click" method toggles the italic font style for the text content text box.
        /// </summary>
        /// <remarks>
        /// If the text is currently italicized, the method removes the italic style. 
        /// If the text is not italicized, the method applies the italic style.
        /// </remarks>
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

        /// <summary>
        /// The "UnderlineToolStripButton_Click" method toggles the underline font style for the text content text box.
        /// </summary>
        /// <remarks>
        /// If the text is currently underlined, the method removes the underline style. 
        /// If the text is not underlined, the method applies the underline style.
        /// </remarks>
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

        /// <summary>
        /// The "StrikeoutToolStripButton_Click" method toggles the strikeout font style for the text content text box.
        /// </summary>
        /// <remarks>
        /// If the text is currently strikeout, the method removes the strikeout style. 
        /// If the text is not strikeout, the method applies the strikeout style.
        /// </remarks>
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

        #endregion

        #region Private Draw Methods

        /// <summary>
        /// The "SetShapes" method draws temporary shapes on the drawing board based on the current selected shape option.
        /// </summary>
        /// <remarks>
        /// If the line shape is selected, the method draws a temporary line from the starting point to the current cursor position.
        /// If the circle shape is selected, the method draws a temporary ellipse representing a circle at the starting point with the current cursor position determining the width and height.
        /// If the rectangle shape is selected, the method draws a temporary rectangle from the starting point to the current cursor position.
        /// </remarks>
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

        /// <summary>
        /// The "ShowText" method displays the text entered in the TextContentTextBox on the DrawingBoardPictureBox.
        /// </summary>
        /// <remarks>
        /// This method sets IsTextContentTextBoxEntered to false to indicate that text entry is complete.
        /// It then retrieves the text from the TextContentTextBox and checks if it's empty.
        /// If the text is not empty, it retrieves the font, size, and style settings from the respective controls.
        /// Based on the style settings (bold, italic, underline, strikeout), it creates a new Font object.
        /// It then creates a SolidBrush with the selected brush color.
        /// Using the Graphics object, it draws the text on the DrawingBoardPictureBox at the location of the TextContentTextBox.
        /// Finally, it clears the TextContentTextBox, hides it, resets the text paint option, hides the TextToolStrip, and inserts the drawing into the canvas.
        /// </remarks>
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

        /// <summary>
        /// The "ChangeBackgroundColor" method changes the background color of the drawing area.
        /// </summary>
        /// <param name="BackgroundColor">The new background color.</param>
        /// <remarks>
        /// This method iterates over the pixels of the DrawingBitMap and sets the color to BackgroundColor
        /// for pixels beyond the dimensions of the background image (if any).
        /// This is useful when the background image is smaller than the drawing area.
        /// </remarks>
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

        #endregion

        #region Private Rotate Options Methods

        /// <summary>
        /// The "RotateRight90ToolStripMenuItem_Click" method handles the click event for rotating the image 90 degrees to the right.
        /// It rotates the current image displayed on the drawing board PictureBox by 90 degrees clockwise and updates the display.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void RotateRight90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = RotateImage90DegreesRight((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        /// <summary>
        /// The "RotateLeft90ToolStripMenuItem_Click" method handles the click event for rotating the image 90 degrees to the left.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method rotates the image 90 degrees to the left by calling the RotateImage90DegreesLeft method,
        /// updates the DrawingBoardPictureBox's image, and inserts the updated drawing.
        /// </remarks>
        private void RotateLeft90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = RotateImage90DegreesLeft((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        /// <summary>
        /// The "Rotate180ToolStripMenuItem_Click" method handles the click event for rotating the image 180 degrees.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method rotates the image 180 degrees by calling the RotateImage180Degrees method,
        /// updates the DrawingBoardPictureBox's image, and inserts the updated drawing.
        /// </remarks>
        private void Rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = RotateImage180Degrees((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        /// <summary>
        /// The "FlipVerticalToolStripMenuItem_Click" method handles the click event for flipping the image vertically.
        /// It flips the current image displayed on the drawing board PictureBox vertically and updates the display.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FlipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = FlipImageVertically((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        /// <summary>
        /// The "FlipHorizontalToolStripMenuItem_Click" method handles the click event for flipping the image horizontally.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method flips the image horizontally by calling the FlipImageHorizontally method,
        /// updates the DrawingBoardPictureBox's image, and inserts the updated drawing.
        /// </remarks>
        private void FlipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingBitMap = FlipImageHorizontally((Bitmap)DrawingBoardPictureBox.Image);
            DrawingBoardPictureBox.Image = DrawingBitMap;
            InsertDrawing();
        }

        #endregion

        #region Private Drawing Rotate Methods

        /// <summary>
        /// The "FlipImageHorizontally" method flips the provided bitmap horizontally.
        /// </summary>
        /// <param name="original">The original bitmap to flip.</param>
        /// <returns>The horizontally flipped bitmap.</returns>
        /// <remarks>
        /// This method creates a new bitmap with the same dimensions as the original but
        /// flips the image horizontally. It uses Graphics.DrawImage to achieve the flipping effect.
        /// </remarks>
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

        /// <summary>
        /// The "FlipImageVertically" method flips the provided bitmap vertically.
        /// </summary>
        /// <param name="original">The original bitmap to flip.</param>
        /// <returns>The vertically flipped bitmap.</returns>
        /// <remarks>
        /// This method creates a new bitmap with the same dimensions as the original but
        /// flips the image vertically. It uses Graphics.DrawImage to achieve the flipping effect.
        /// </remarks>
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

        /// <summary>
        /// The "RotateImage90DegreesRight" method rotates the provided bitmap 90 degrees to the right.
        /// </summary>
        /// <param name="original">The original bitmap to rotate.</param>
        /// <returns>The rotated bitmap.</returns>
        /// <remarks>
        /// This method rotates the provided bitmap 90 degrees to the right by swapping its width and height
        /// and then using RotateFlipType.Rotate90FlipNone to rotate the image. It returns a new bitmap
        /// with the rotated image.
        /// </remarks>
        private Bitmap RotateImage90DegreesRight(Bitmap original)
        {
            DrawingWidth = DrawingBoardPictureBox.Height;
            DrawingHeight = DrawingBoardPictureBox.Width;
            DrawingBoardPictureBox.Width = DrawingWidth;
            DrawingBoardPictureBox.Height = DrawingHeight;
            original.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return new Bitmap(original);
        }

        /// <summary>
        /// The "RotateImage90DegreesLeft" method rotates the provided bitmap 90 degrees to the left.
        /// </summary>
        /// <param name="original">The original bitmap to rotate.</param>
        /// <returns>The rotated bitmap.</returns>
        /// <remarks>
        /// This method rotates the provided bitmap 90 degrees to the left by swapping its width and height
        /// and then using RotateFlipType.Rotate270FlipNone to rotate the image. It returns a new bitmap
        /// with the rotated image.
        /// </remarks>
        private Bitmap RotateImage90DegreesLeft(Bitmap original)
        {
            DrawingWidth = DrawingBoardPictureBox.Height;
            DrawingHeight = DrawingBoardPictureBox.Width;
            DrawingBoardPictureBox.Width = DrawingWidth;
            DrawingBoardPictureBox.Height = DrawingHeight;
            original.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return new Bitmap(original);
        }

        /// <summary>
        /// The "RotateImage180Degrees" method rotates the provided bitmap 180 degrees.
        /// </summary>
        /// <param name="original">The original bitmap to rotate.</param>
        /// <returns>The rotated bitmap.</returns>
        /// <remarks>
        /// This method rotates the provided bitmap 180 degrees using RotateFlipType.Rotate180FlipNone
        /// and returns a new bitmap with the rotated image.
        /// </remarks>
        private Bitmap RotateImage180Degrees(Bitmap original)
        {
            original.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return new Bitmap(original);
        } 

        #endregion

        #region Private Undo/Redo Methods

        /// <summary>
        /// The "RedoToolStripButton_Click" method handles the click event for redoing the last action.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method decreases the currentCanvasIndex to move to the next canvas update in the list.
        /// It checks if the currentCanvasIndex is at the beginning of the list to disable the redo button.
        /// It also checks if the currentCanvasIndex is at the second last index to enable the undo button.
        /// Finally, it calls the HandleCanvas method to update the drawing board.
        /// </remarks>
        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            currentCanvasIndex--;
            if (currentCanvasIndex == 0)
            {
                RedoToolStripButton.Enabled = false;
                RedoToolStripButton.Image = RedoIsNotShown;
            }
            if(currentCanvasIndex == LastCanvasUpdates.Count - 2)
            {
                UndoToolStripButton.Enabled = true;
                UndoToolStripButton.Image = UndoIsShown;
            }
            HandleCanvas();
        }

        /// <summary>
        /// The "UndoToolStripButton_Click" method handles the click event for undoing the last action.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method increases the currentCanvasIndex to move to the previous canvas update in the list.
        /// It checks if the currentCanvasIndex is at the second index to enable the redo button.
        /// It also checks if the currentCanvasIndex is at the last index to disable the undo button.
        /// Finally, it calls the HandleCanvas method to update the drawing board.
        /// </remarks>
        private void UndoToolStripButton_Click(object sender, EventArgs e)
        {
            currentCanvasIndex++;
            if (currentCanvasIndex == 1)
            {
                RedoToolStripButton.Enabled = true;
                RedoToolStripButton.Image = RedoIsShown;
            }
            if (currentCanvasIndex == LastCanvasUpdates.Count - 1)
            {
                UndoToolStripButton.Enabled = false;
                UndoToolStripButton.Image = UndoIsNotShown;
            }
            HandleCanvas();
        }

        /// <summary>
        /// The "HandleCanvas" method updates the drawing board based on the currentCanvasIndex.
        /// </summary>
        /// <remarks>
        /// This method retrieves the drawing object at the currentCanvasIndex from the LastCanvasUpdates list.
        /// It sets the width and height of the DrawingBoardPictureBox to match the drawing dimensions.
        /// It clones the drawing image and assigns it to the DrawingBitMap.
        /// It creates a Graphics object from the DrawingBitMap.
        /// Finally, it sets the DrawingBoardPictureBox.Image to the updated DrawingBitMap.
        /// </remarks>
        private void HandleCanvas()
        {
            Drawing drawing = LastCanvasUpdates[currentCanvasIndex];
            DrawingBoardPictureBox.Width = drawing.Width;
            DrawingBoardPictureBox.Height = drawing.Height;
            DrawingBitMap = (Bitmap)drawing.DrawingImage.Clone();
            Graphics = Graphics.FromImage(DrawingBitMap);
            DrawingBoardPictureBox.Image = DrawingBitMap;
        }

        #endregion

    }
}
