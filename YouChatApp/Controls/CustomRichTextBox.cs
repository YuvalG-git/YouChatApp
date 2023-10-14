﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class CustomRichTextBox : UserControl
    {

        private Color BorderColorProperty = Color.MediumSlateBlue;
        private int BorderSizeProperty = 2;
        private bool UnderlineStyleProperty = false;
        private Color BorderFocusColorProperty = Color.HotPink;
        private bool IsFocusedProperty = false;

        private int BorderRadiusProperty = 0;

        private Color PlaceHolderColorProperty = Color.DarkGray;
        private string PlaceHolderTextProperty = "";
        private bool IsPlaceHolderProperty = false;

        public CustomRichTextBox()
        {
            InitializeComponent();
        }
        public event EventHandler TextChangedEvent;

        [Category("YouChat")]
        public Color BorderColor
        {
            get { return BorderColorProperty; }
            set
            {
                BorderColorProperty = value;
                this.Invalidate();
            }
        }

        [Category("YouChat")]
        public int BorderSize
        {
            get { return BorderSizeProperty; }
            set
            {
                BorderSizeProperty = value;
                this.Invalidate();
            }
        }

        [Category("YouChat")]
        public bool UnderlineStyle
        {
            get { return UnderlineStyleProperty; }
            set
            {
                UnderlineStyleProperty = value;
                this.Invalidate();
            }
        }

        [Category("YouChat")]
        public Color BorderFocusColor
        {
            get
            {
                return BorderFocusColorProperty;
            }
            set
            {
                BorderFocusColorProperty = value;
            }
        }

        [Category("YouChat")]
        public bool IsFocused
        {
            get
            {
                return IsFocusedProperty;
            }
            set
            {
                IsFocusedProperty = value;
            }
        }

        [Category("YouChat")]
        public int BorderRadius
        {
            get
            {
                return BorderRadiusProperty;
            }
            set
            {
                if ((value >= 0) && (value < (int)this.Height / 2))
                {
                    BorderRadiusProperty = value;
                    this.Invalidate();
                }
            }
        }

        [Category("YouChat")]
        public Color PlaceHolderColor
        {
            get
            {
                return PlaceHolderColorProperty;
            }
            set
            {
                PlaceHolderColorProperty = value;
                if (IsPlaceHolderProperty)
                {
                    RichTextBox.ForeColor = value;
                }
                //this.Invalidate(); //needed???

            }
        }

        [Category("YouChat")]
        public string PlaceHolderText
        {
            get
            {
                return PlaceHolderTextProperty;
            }
            set
            {
                PlaceHolderTextProperty = value;
                RichTextBox.Text = "";
                SetPlaceHolder();

                //this.Invalidate(); //needed???

            }
        }
        public bool isPlaceHolder()
        {
            return IsPlaceHolderProperty;
        }
        public bool IsContainingValue()
        {
            if (isPlaceHolder())
            {
                return false;
            }
            else
            {
                if (TextContent == "")
                {
                    return false;
                }
            }
            return true;
        }




        [Category("YouChat")]
        public bool Multiline
        {
            get
            {
                return RichTextBox.Multiline;
            }
            set
            {
                RichTextBox.Multiline = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                RichTextBox.BackColor = value;
            }
        }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                RichTextBox.ForeColor = value;
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                RichTextBox.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }
        [Category("YouChat")]
        public int MaxLength
        {
            get
            {
                return RichTextBox.MaxLength;
            }
            set
            {
                RichTextBox.MaxLength = value;
            }
        }
        [Category("YouChat")]
        public bool ReadOnly
        {
            get
            {
                return RichTextBox.ReadOnly;
            }
            set
            {
                RichTextBox.ReadOnly = value;
            }
        }

        [Category("YouChat")]
        public string TextContent
        {
            get
            {
                if (IsPlaceHolderProperty)
                {
                    return "";
                }
                else
                {
                    //SetPlaceHolder();
                    return RichTextBox.Text;
                }
            }
            set
            {
                RichTextBox.Text = value;
            }
        }

        private void SetPlaceHolder()
        {
            if ((string.IsNullOrWhiteSpace(RichTextBox.Text)) && (PlaceHolderTextProperty != ""))
            {
                IsPlaceHolderProperty = true;
                RichTextBox.Text = PlaceHolderTextProperty;
                RichTextBox.ForeColor = PlaceHolderColorProperty;
            }
        }

        private void RemovePlaceHolder()
        {
            if ((IsPlaceHolderProperty) && (PlaceHolderTextProperty != ""))
            {
                IsPlaceHolderProperty = false;
                RichTextBox.Text = "";
                RichTextBox.ForeColor = this.ForeColor;
            }
        }
        public void SelectText(int start, int length)
        {
            RichTextBox.Select(start, length);

        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            Color CurrentBorderColor;
            if (IsFocused)
            {
                CurrentBorderColor = BorderFocusColorProperty;
            }
            else
            {
                CurrentBorderColor = BorderColorProperty;
            }
            if (BorderRadius > 1)
            {
                var RectangleBorderSmooth = this.ClientRectangle;
                var RectangleBorder = Rectangle.Inflate(RectangleBorderSmooth, -BorderSizeProperty, -BorderSizeProperty);
                int SmoothSize = BorderSize > 0 ? BorderSize : 1; //need to learn that and all this code kinda...
                using (GraphicsPath PathBorderSmooth = GraphicsHandler.GetFigurePath(RectangleBorderSmooth, BorderRadiusProperty))
                {
                    using (GraphicsPath PathBorder = GraphicsHandler.GetFigurePath(RectangleBorder, BorderRadiusProperty - BorderSizeProperty))
                    {
                        using (Pen PenBorderSmooth = new Pen(this.Parent.BackColor, SmoothSize))
                        {
                            using (Pen PenBorder = new Pen(CurrentBorderColor, BorderSizeProperty))
                            {
                                this.Region = new Region(PathBorderSmooth);
                                if (BorderRadiusProperty > 15)
                                {
                                    SetTextBoxRoundedRegion();
                                }
                                Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                PenBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

                                if (UnderlineStyleProperty)
                                {
                                    Graphics.DrawPath(PenBorderSmooth, PathBorderSmooth);
                                    Graphics.SmoothingMode = SmoothingMode.None;
                                    Graphics.DrawLine(PenBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                                }
                                else
                                {
                                    Graphics.DrawPath(PenBorderSmooth, PathBorderSmooth);
                                    Graphics.DrawPath(PenBorder, PathBorder);

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                using (Pen BorderPen = new Pen(CurrentBorderColor, BorderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (UnderlineStyleProperty)
                    {
                        Graphics.DrawLine(BorderPen, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        Graphics.DrawRectangle(BorderPen, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }
                }
            }
        }

        private void SetTextBoxRoundedRegion()
        {

            GraphicsPath Path;
            if (Multiline)
            {
                Path = GraphicsHandler.GetFigurePath(RichTextBox.ClientRectangle, BorderRadiusProperty - BorderSizeProperty);
                RichTextBox.Region = new Region(Path);

            }
            else
            {
                Path = GraphicsHandler.GetFigurePath(RichTextBox.ClientRectangle, BorderSizeProperty * 2);
                RichTextBox.Region = new Region(Path);

            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (RichTextBox.Multiline == false)
            {
                int TextHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                RichTextBox.Multiline = true;
                RichTextBox.MinimumSize = new Size(0, TextHeight);
                RichTextBox.Multiline = false;
                this.Height = RichTextBox.Height + this.Padding.Bottom + this.Padding.Top;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChangedEvent != null)
            {
                TextChangedEvent.Invoke(sender, e);
            }
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e); //shouldnt i just state that this control if a text box?
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            IsFocused = true;
            this.Invalidate();
            RemovePlaceHolder();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            IsFocused = false;
            this.Invalidate();
            SetPlaceHolder();
        }
    }
}
