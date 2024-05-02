using System.Collections.Generic;

namespace YouChatApp.AttachedFiles.PaintHandler
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.PaintMenuStrip = new System.Windows.Forms.MenuStrip();
            this.PaintFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintColorDialog = new System.Windows.Forms.ColorDialog();
            this.PaintOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PaintSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TextContentTextBox = new System.Windows.Forms.TextBox();
            this.FirstColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SecondColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ThirdColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FourthColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PenSizeToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.PenSizeValue5ToolStripDropDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PenSizeValue10ToolStripDropDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PenSizeValue15ToolStripDropDownButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintToolStrip = new System.Windows.Forms.ToolStrip();
            this.RedoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.UndoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.MultiColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BackgroundColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PencilToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EraserToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ShapesToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.LineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.z = new System.Windows.Forms.ToolStripDropDownButton();
            this.RotateRight90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateLeft90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rotate180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlipVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextToolStrip = new System.Windows.Forms.ToolStrip();
            this.FirstTextColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SecondTextColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ThirdTextColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FourthTextColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TextMultiColorOptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TextSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.FontToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.BoldtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ItalicToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.UnderlineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.StrikeoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DrawingBoardPictureBox = new System.Windows.Forms.PictureBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.PaintMenuStrip.SuspendLayout();
            this.PaintToolStrip.SuspendLayout();
            this.TextToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBoardPictureBox)).BeginInit();
            this.BackgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaintMenuStrip
            // 
            this.PaintMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PaintFileToolStripMenuItem});
            this.PaintMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.PaintMenuStrip.Name = "PaintMenuStrip";
            this.PaintMenuStrip.Size = new System.Drawing.Size(800, 29);
            this.PaintMenuStrip.TabIndex = 0;
            this.PaintMenuStrip.Text = "menuStrip1";
            // 
            // PaintFileToolStripMenuItem
            // 
            this.PaintFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveOptionToolStripMenuItem,
            this.OpenOptionToolStripMenuItem,
            this.DeleteOptionToolStripMenuItem,
            this.SendOptionToolStripMenuItem});
            this.PaintFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaintFileToolStripMenuItem.Name = "PaintFileToolStripMenuItem";
            this.PaintFileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.PaintFileToolStripMenuItem.Text = "File";
            // 
            // SaveOptionToolStripMenuItem
            // 
            this.SaveOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.SaveOption;
            this.SaveOptionToolStripMenuItem.Name = "SaveOptionToolStripMenuItem";
            this.SaveOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.SaveOptionToolStripMenuItem.Text = "Save";
            this.SaveOptionToolStripMenuItem.Click += new System.EventHandler(this.SaveOptionToolStripMenuItem_Click);
            // 
            // OpenOptionToolStripMenuItem
            // 
            this.OpenOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.OpenOption;
            this.OpenOptionToolStripMenuItem.Name = "OpenOptionToolStripMenuItem";
            this.OpenOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.OpenOptionToolStripMenuItem.Text = "Open";
            this.OpenOptionToolStripMenuItem.Click += new System.EventHandler(this.OpenOptionToolStripMenuItem_Click);
            // 
            // DeleteOptionToolStripMenuItem
            // 
            this.DeleteOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.DeleteOption1;
            this.DeleteOptionToolStripMenuItem.Name = "DeleteOptionToolStripMenuItem";
            this.DeleteOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.DeleteOptionToolStripMenuItem.Text = "Delete";
            this.DeleteOptionToolStripMenuItem.Click += new System.EventHandler(this.DeleteOptionToolStripMenuItem_Click);
            // 
            // SendOptionToolStripMenuItem
            // 
            this.SendOptionToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.SendOption1;
            this.SendOptionToolStripMenuItem.Name = "SendOptionToolStripMenuItem";
            this.SendOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.SendOptionToolStripMenuItem.Text = "Send";
            this.SendOptionToolStripMenuItem.Click += new System.EventHandler(this.SendOptionToolStripMenuItem_Click);
            // 
            // PaintOpenFileDialog
            // 
            this.PaintOpenFileDialog.FileName = "openFileDialog1";
            // 
            // TextContentTextBox
            // 
            this.TextContentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextContentTextBox.Location = new System.Drawing.Point(430, 182);
            this.TextContentTextBox.Multiline = true;
            this.TextContentTextBox.Name = "TextContentTextBox";
            this.TextContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextContentTextBox.Size = new System.Drawing.Size(180, 36);
            this.TextContentTextBox.TabIndex = 3;
            this.TextContentTextBox.Visible = false;
            this.TextContentTextBox.TextChanged += new System.EventHandler(this.TextContentTextBox_TextChanged);
            this.TextContentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextContentTextBox_KeyDown);
            this.TextContentTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextContentTextBox_MouseDown);
            // 
            // FirstColorOptionToolStripButton
            // 
            this.FirstColorOptionToolStripButton.BackColor = System.Drawing.Color.Black;
            this.FirstColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstColorOptionToolStripButton.Name = "FirstColorOptionToolStripButton";
            this.FirstColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.FirstColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // SecondColorOptionToolStripButton
            // 
            this.SecondColorOptionToolStripButton.BackColor = System.Drawing.Color.Red;
            this.SecondColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SecondColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SecondColorOptionToolStripButton.Name = "SecondColorOptionToolStripButton";
            this.SecondColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SecondColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // ThirdColorOptionToolStripButton
            // 
            this.ThirdColorOptionToolStripButton.BackColor = System.Drawing.Color.Green;
            this.ThirdColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ThirdColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThirdColorOptionToolStripButton.Name = "ThirdColorOptionToolStripButton";
            this.ThirdColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ThirdColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // FourthColorOptionToolStripButton
            // 
            this.FourthColorOptionToolStripButton.BackColor = System.Drawing.Color.Blue;
            this.FourthColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FourthColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FourthColorOptionToolStripButton.Name = "FourthColorOptionToolStripButton";
            this.FourthColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.FourthColorOptionToolStripButton.Click += new System.EventHandler(this.ColorChange_Click);
            // 
            // PenSizeToolStripDropDownButton
            // 
            this.PenSizeToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PenSizeToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenSizeValue5ToolStripDropDownButton,
            this.PenSizeValue10ToolStripDropDownButton,
            this.PenSizeValue15ToolStripDropDownButton});
            this.PenSizeToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PenSizeToolStripDropDownButton.Name = "PenSizeToolStripDropDownButton";
            this.PenSizeToolStripDropDownButton.Size = new System.Drawing.Size(63, 22);
            this.PenSizeToolStripDropDownButton.Text = "Pen Size";
            // 
            // PenSizeValue5ToolStripDropDownButton
            // 
            this.PenSizeValue5ToolStripDropDownButton.Name = "PenSizeValue5ToolStripDropDownButton";
            this.PenSizeValue5ToolStripDropDownButton.Size = new System.Drawing.Size(86, 22);
            this.PenSizeValue5ToolStripDropDownButton.Text = "5";
            this.PenSizeValue5ToolStripDropDownButton.Click += new System.EventHandler(this.PenSizeChangeValue_Click);
            // 
            // PenSizeValue10ToolStripDropDownButton
            // 
            this.PenSizeValue10ToolStripDropDownButton.Name = "PenSizeValue10ToolStripDropDownButton";
            this.PenSizeValue10ToolStripDropDownButton.Size = new System.Drawing.Size(86, 22);
            this.PenSizeValue10ToolStripDropDownButton.Text = "10";
            this.PenSizeValue10ToolStripDropDownButton.Click += new System.EventHandler(this.PenSizeChangeValue_Click);
            // 
            // PenSizeValue15ToolStripDropDownButton
            // 
            this.PenSizeValue15ToolStripDropDownButton.Name = "PenSizeValue15ToolStripDropDownButton";
            this.PenSizeValue15ToolStripDropDownButton.Size = new System.Drawing.Size(86, 22);
            this.PenSizeValue15ToolStripDropDownButton.Text = "15";
            this.PenSizeValue15ToolStripDropDownButton.Click += new System.EventHandler(this.PenSizeChangeValue_Click);
            // 
            // PaintToolStrip
            // 
            this.PaintToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedoToolStripButton,
            this.UndoToolStripButton,
            this.FirstColorOptionToolStripButton,
            this.SecondColorOptionToolStripButton,
            this.ThirdColorOptionToolStripButton,
            this.FourthColorOptionToolStripButton,
            this.MultiColorOptionToolStripButton,
            this.PenSizeToolStripDropDownButton,
            this.BackgroundColorToolStripButton,
            this.PencilToolStripButton,
            this.EraserToolStripButton,
            this.TextToolStripButton,
            this.ShapesToolStripDropDownButton,
            this.z});
            this.PaintToolStrip.Location = new System.Drawing.Point(0, 29);
            this.PaintToolStrip.Name = "PaintToolStrip";
            this.PaintToolStrip.Size = new System.Drawing.Size(800, 25);
            this.PaintToolStrip.TabIndex = 1;
            this.PaintToolStrip.Text = "toolStrip1";
            // 
            // RedoToolStripButton
            // 
            this.RedoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoToolStripButton.Enabled = false;
            this.RedoToolStripButton.Image = global::YouChatApp.Properties.Resources.RedoNotPressed;
            this.RedoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoToolStripButton.Name = "RedoToolStripButton";
            this.RedoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RedoToolStripButton.Text = "Redo";
            this.RedoToolStripButton.Click += new System.EventHandler(this.RedoToolStripButton_Click);
            // 
            // UndoToolStripButton
            // 
            this.UndoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoToolStripButton.Enabled = false;
            this.UndoToolStripButton.Image = global::YouChatApp.Properties.Resources.UndoNotPressed;
            this.UndoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoToolStripButton.Name = "UndoToolStripButton";
            this.UndoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.UndoToolStripButton.Text = "Undo";
            this.UndoToolStripButton.Click += new System.EventHandler(this.UndoToolStripButton_Click);
            // 
            // MultiColorOptionToolStripButton
            // 
            this.MultiColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MultiColorOptionToolStripButton.Image = global::YouChatApp.Properties.Resources.colors;
            this.MultiColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MultiColorOptionToolStripButton.Name = "MultiColorOptionToolStripButton";
            this.MultiColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.MultiColorOptionToolStripButton.Text = "Colors";
            this.MultiColorOptionToolStripButton.Click += new System.EventHandler(this.MultiColorOptionToolStripButton_Click);
            // 
            // BackgroundColorToolStripButton
            // 
            this.BackgroundColorToolStripButton.Image = global::YouChatApp.Properties.Resources.BackgroundColor2;
            this.BackgroundColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackgroundColorToolStripButton.Name = "BackgroundColorToolStripButton";
            this.BackgroundColorToolStripButton.Size = new System.Drawing.Size(123, 22);
            this.BackgroundColorToolStripButton.Text = "Background Color";
            this.BackgroundColorToolStripButton.Click += new System.EventHandler(this.BackgroundColorToolStripButton_Click);
            // 
            // PencilToolStripButton
            // 
            this.PencilToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PencilToolStripButton.Image = global::YouChatApp.Properties.Resources.Pencil;
            this.PencilToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PencilToolStripButton.Name = "PencilToolStripButton";
            this.PencilToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.PencilToolStripButton.Text = "Pencil";
            this.PencilToolStripButton.Click += new System.EventHandler(this.PencilToolStripButton_Click);
            // 
            // EraserToolStripButton
            // 
            this.EraserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraserToolStripButton.Image = global::YouChatApp.Properties.Resources.Eraser;
            this.EraserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraserToolStripButton.Name = "EraserToolStripButton";
            this.EraserToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.EraserToolStripButton.Text = "Eraser";
            this.EraserToolStripButton.Click += new System.EventHandler(this.EraserToolStripButton_Click);
            // 
            // TextToolStripButton
            // 
            this.TextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextToolStripButton.Image = global::YouChatApp.Properties.Resources.Text;
            this.TextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextToolStripButton.Name = "TextToolStripButton";
            this.TextToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.TextToolStripButton.Text = "Text";
            this.TextToolStripButton.Click += new System.EventHandler(this.TextToolStripButton_Click);
            // 
            // ShapesToolStripDropDownButton
            // 
            this.ShapesToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShapesToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineToolStripMenuItem,
            this.CircleToolStripMenuItem,
            this.RectangleToolStripMenuItem});
            this.ShapesToolStripDropDownButton.Image = global::YouChatApp.Properties.Resources.Shapes;
            this.ShapesToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShapesToolStripDropDownButton.Name = "ShapesToolStripDropDownButton";
            this.ShapesToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.ShapesToolStripDropDownButton.Text = "Shapes";
            // 
            // LineToolStripMenuItem
            // 
            this.LineToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.Line;
            this.LineToolStripMenuItem.Name = "LineToolStripMenuItem";
            this.LineToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.LineToolStripMenuItem.Text = "Line";
            this.LineToolStripMenuItem.Click += new System.EventHandler(this.LineToolStripMenuItem_Click);
            // 
            // CircleToolStripMenuItem
            // 
            this.CircleToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.Circle;
            this.CircleToolStripMenuItem.Name = "CircleToolStripMenuItem";
            this.CircleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.CircleToolStripMenuItem.Text = "Circle";
            this.CircleToolStripMenuItem.Click += new System.EventHandler(this.CircleToolStripMenuItem_Click);
            // 
            // RectangleToolStripMenuItem
            // 
            this.RectangleToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.Rectange;
            this.RectangleToolStripMenuItem.Name = "RectangleToolStripMenuItem";
            this.RectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.RectangleToolStripMenuItem.Text = "Rectangle";
            this.RectangleToolStripMenuItem.Click += new System.EventHandler(this.RectangleToolStripMenuItem_Click);
            // 
            // z
            // 
            this.z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.z.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RotateRight90ToolStripMenuItem,
            this.RotateLeft90ToolStripMenuItem,
            this.Rotate180ToolStripMenuItem,
            this.FlipVerticalToolStripMenuItem,
            this.FlipHorizontalToolStripMenuItem});
            this.z.Image = global::YouChatApp.Properties.Resources.RotatePicture;
            this.z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(29, 22);
            this.z.Text = "Rotate";
            // 
            // RotateRight90ToolStripMenuItem
            // 
            this.RotateRight90ToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.RotateRight90;
            this.RotateRight90ToolStripMenuItem.Name = "RotateRight90ToolStripMenuItem";
            this.RotateRight90ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.RotateRight90ToolStripMenuItem.Text = "Rotate Right 90";
            this.RotateRight90ToolStripMenuItem.Click += new System.EventHandler(this.RotateRight90ToolStripMenuItem_Click);
            // 
            // RotateLeft90ToolStripMenuItem
            // 
            this.RotateLeft90ToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.RotateLeft90;
            this.RotateLeft90ToolStripMenuItem.Name = "RotateLeft90ToolStripMenuItem";
            this.RotateLeft90ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.RotateLeft90ToolStripMenuItem.Text = "Rotate Left 90";
            this.RotateLeft90ToolStripMenuItem.Click += new System.EventHandler(this.RotateLeft90ToolStripMenuItem_Click);
            // 
            // Rotate180ToolStripMenuItem
            // 
            this.Rotate180ToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.Rotate180;
            this.Rotate180ToolStripMenuItem.Name = "Rotate180ToolStripMenuItem";
            this.Rotate180ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Rotate180ToolStripMenuItem.Text = "Rotate 180";
            this.Rotate180ToolStripMenuItem.Click += new System.EventHandler(this.Rotate180ToolStripMenuItem_Click);
            // 
            // FlipVerticalToolStripMenuItem
            // 
            this.FlipVerticalToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.FlipVertically;
            this.FlipVerticalToolStripMenuItem.Name = "FlipVerticalToolStripMenuItem";
            this.FlipVerticalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.FlipVerticalToolStripMenuItem.Text = "Flip Vertical";
            this.FlipVerticalToolStripMenuItem.Click += new System.EventHandler(this.FlipVerticalToolStripMenuItem_Click);
            // 
            // FlipHorizontalToolStripMenuItem
            // 
            this.FlipHorizontalToolStripMenuItem.Image = global::YouChatApp.Properties.Resources.FlipHorizontally;
            this.FlipHorizontalToolStripMenuItem.Name = "FlipHorizontalToolStripMenuItem";
            this.FlipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.FlipHorizontalToolStripMenuItem.Text = "Flip Horizontal";
            this.FlipHorizontalToolStripMenuItem.Click += new System.EventHandler(this.FlipHorizontalToolStripMenuItem_Click);
            // 
            // TextToolStrip
            // 
            this.TextToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstTextColorOptionToolStripButton,
            this.SecondTextColorOptionToolStripButton,
            this.ThirdTextColorOptionToolStripButton,
            this.FourthTextColorOptionToolStripButton,
            this.TextMultiColorOptionToolStripButton,
            this.TextSizeToolStripComboBox,
            this.FontToolStripComboBox,
            this.BoldtoolStripButton,
            this.ItalicToolStripButton,
            this.UnderlineToolStripButton,
            this.StrikeoutToolStripButton});
            this.TextToolStrip.Location = new System.Drawing.Point(0, 54);
            this.TextToolStrip.Name = "TextToolStrip";
            this.TextToolStrip.Size = new System.Drawing.Size(800, 25);
            this.TextToolStrip.TabIndex = 4;
            this.TextToolStrip.Text = "toolStrip1";
            this.TextToolStrip.Visible = false;
            // 
            // FirstTextColorOptionToolStripButton
            // 
            this.FirstTextColorOptionToolStripButton.BackColor = System.Drawing.Color.Black;
            this.FirstTextColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstTextColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstTextColorOptionToolStripButton.Name = "FirstTextColorOptionToolStripButton";
            this.FirstTextColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.FirstTextColorOptionToolStripButton.Click += new System.EventHandler(this.TextColorChange);
            // 
            // SecondTextColorOptionToolStripButton
            // 
            this.SecondTextColorOptionToolStripButton.BackColor = System.Drawing.Color.Red;
            this.SecondTextColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SecondTextColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SecondTextColorOptionToolStripButton.Name = "SecondTextColorOptionToolStripButton";
            this.SecondTextColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SecondTextColorOptionToolStripButton.Click += new System.EventHandler(this.TextColorChange);
            // 
            // ThirdTextColorOptionToolStripButton
            // 
            this.ThirdTextColorOptionToolStripButton.BackColor = System.Drawing.Color.Green;
            this.ThirdTextColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ThirdTextColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThirdTextColorOptionToolStripButton.Name = "ThirdTextColorOptionToolStripButton";
            this.ThirdTextColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ThirdTextColorOptionToolStripButton.Click += new System.EventHandler(this.TextColorChange);
            // 
            // FourthTextColorOptionToolStripButton
            // 
            this.FourthTextColorOptionToolStripButton.BackColor = System.Drawing.Color.Blue;
            this.FourthTextColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FourthTextColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FourthTextColorOptionToolStripButton.Name = "FourthTextColorOptionToolStripButton";
            this.FourthTextColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.FourthTextColorOptionToolStripButton.Click += new System.EventHandler(this.TextColorChange);
            // 
            // TextMultiColorOptionToolStripButton
            // 
            this.TextMultiColorOptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextMultiColorOptionToolStripButton.Image = global::YouChatApp.Properties.Resources.colors;
            this.TextMultiColorOptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextMultiColorOptionToolStripButton.Name = "TextMultiColorOptionToolStripButton";
            this.TextMultiColorOptionToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.TextMultiColorOptionToolStripButton.Text = "Colors";
            this.TextMultiColorOptionToolStripButton.Click += new System.EventHandler(this.TextMultiColorOptionToolStripButton_Click);
            // 
            // TextSizeToolStripComboBox
            // 
            this.TextSizeToolStripComboBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.TextSizeToolStripComboBox.Name = "TextSizeToolStripComboBox";
            this.TextSizeToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.TextSizeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.TextSizeToolStripComboBox_SelectedIndexChanged);
            // 
            // FontToolStripComboBox
            // 
            this.FontToolStripComboBox.Name = "FontToolStripComboBox";
            this.FontToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.FontToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.FontToolStripComboBox_SelectedIndexChanged);
            // 
            // BoldtoolStripButton
            // 
            this.BoldtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BoldtoolStripButton.Image = global::YouChatApp.Properties.Resources.BoldText;
            this.BoldtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BoldtoolStripButton.Name = "BoldtoolStripButton";
            this.BoldtoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.BoldtoolStripButton.Text = "Bold";
            this.BoldtoolStripButton.Click += new System.EventHandler(this.BoldtoolStripButton_Click);
            // 
            // ItalicToolStripButton
            // 
            this.ItalicToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItalicToolStripButton.Image = global::YouChatApp.Properties.Resources.ItalicText;
            this.ItalicToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItalicToolStripButton.Name = "ItalicToolStripButton";
            this.ItalicToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItalicToolStripButton.Text = "Italic";
            this.ItalicToolStripButton.Click += new System.EventHandler(this.ItalicToolStripButton_Click);
            // 
            // UnderlineToolStripButton
            // 
            this.UnderlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UnderlineToolStripButton.Image = global::YouChatApp.Properties.Resources.UnderlineText;
            this.UnderlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnderlineToolStripButton.Name = "UnderlineToolStripButton";
            this.UnderlineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.UnderlineToolStripButton.Text = "Underline";
            this.UnderlineToolStripButton.Click += new System.EventHandler(this.UnderlineToolStripButton_Click);
            // 
            // StrikeoutToolStripButton
            // 
            this.StrikeoutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StrikeoutToolStripButton.Image = global::YouChatApp.Properties.Resources.StrikeoutText1;
            this.StrikeoutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StrikeoutToolStripButton.Name = "StrikeoutToolStripButton";
            this.StrikeoutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.StrikeoutToolStripButton.Text = "Strikeout";
            this.StrikeoutToolStripButton.Click += new System.EventHandler(this.StrikeoutToolStripButton_Click);
            // 
            // DrawingBoardPictureBox
            // 
            this.DrawingBoardPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.DrawingBoardPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DrawingBoardPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.DrawingBoardPictureBox.Location = new System.Drawing.Point(5, 5);
            this.DrawingBoardPictureBox.Name = "DrawingBoardPictureBox";
            this.DrawingBoardPictureBox.Padding = new System.Windows.Forms.Padding(2);
            this.DrawingBoardPictureBox.Size = new System.Drawing.Size(790, 790);
            this.DrawingBoardPictureBox.TabIndex = 2;
            this.DrawingBoardPictureBox.TabStop = false;
            this.DrawingBoardPictureBox.Click += new System.EventHandler(this.DrawingBoardPictureBox_Click);
            this.DrawingBoardPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseClick);
            this.DrawingBoardPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseDown);
            this.DrawingBoardPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseMove);
            this.DrawingBoardPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingBoardPictureBox_MouseUp);
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.Color.Black;
            this.BackgroundPanel.Controls.Add(this.TextContentTextBox);
            this.BackgroundPanel.Controls.Add(this.DrawingBoardPictureBox);
            this.BackgroundPanel.Location = new System.Drawing.Point(0, 80);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(800, 800);
            this.BackgroundPanel.TabIndex = 5;
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 880);
            this.Controls.Add(this.TextToolStrip);
            this.Controls.Add(this.PaintToolStrip);
            this.Controls.Add(this.PaintMenuStrip);
            this.Controls.Add(this.BackgroundPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.PaintMenuStrip;
            this.MaximumSize = new System.Drawing.Size(816, 919);
            this.MinimumSize = new System.Drawing.Size(816, 919);
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Paint_FormClosing);
            this.PaintMenuStrip.ResumeLayout(false);
            this.PaintMenuStrip.PerformLayout();
            this.PaintToolStrip.ResumeLayout(false);
            this.PaintToolStrip.PerformLayout();
            this.TextToolStrip.ResumeLayout(false);
            this.TextToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBoardPictureBox)).EndInit();
            this.BackgroundPanel.ResumeLayout(false);
            this.BackgroundPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip PaintMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PaintFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenOptionToolStripMenuItem;
        private System.Windows.Forms.ColorDialog PaintColorDialog;
        private System.Windows.Forms.PictureBox DrawingBoardPictureBox;
        private System.Windows.Forms.ToolStripMenuItem DeleteOptionToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog PaintOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog PaintSaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem SendOptionToolStripMenuItem;
        private List<System.Windows.Forms.TextBox> TextContentTextBoxList;
        private System.Windows.Forms.TextBox TextContentTextBox;
        private System.Windows.Forms.ToolStripButton RedoToolStripButton;
        private System.Windows.Forms.ToolStripButton UndoToolStripButton;
        private System.Windows.Forms.ToolStripButton FirstColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton SecondColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton ThirdColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton FourthColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton MultiColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton PenSizeToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem PenSizeValue5ToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem PenSizeValue10ToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem PenSizeValue15ToolStripDropDownButton;
        private System.Windows.Forms.ToolStripButton BackgroundColorToolStripButton;
        private System.Windows.Forms.ToolStripButton PencilToolStripButton;
        private System.Windows.Forms.ToolStripButton EraserToolStripButton;
        private System.Windows.Forms.ToolStripButton TextToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton ShapesToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem LineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton z;
        private System.Windows.Forms.ToolStripMenuItem RotateRight90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RotateLeft90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Rotate180ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FlipVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FlipHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStrip PaintToolStrip;
        private System.Windows.Forms.ToolStrip TextToolStrip;
        private System.Windows.Forms.ToolStripButton FirstTextColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton SecondTextColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton ThirdTextColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton FourthTextColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton TextMultiColorOptionToolStripButton;
        private System.Windows.Forms.ToolStripButton ItalicToolStripButton;
        private System.Windows.Forms.ToolStripButton StrikeoutToolStripButton;
        private System.Windows.Forms.ToolStripComboBox FontToolStripComboBox;
        private System.Windows.Forms.ToolStripButton BoldtoolStripButton;
        private System.Windows.Forms.ToolStripButton UnderlineToolStripButton;
        private System.Windows.Forms.ToolStripComboBox TextSizeToolStripComboBox;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel BackgroundPanel;
    }
}