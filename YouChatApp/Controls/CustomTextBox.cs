using System;
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
    /// <summary>
    /// The "CustomTextBox" class represents a custom text box control with extended styling options.
    /// </summary>
    /// <remarks>
    /// This control allows customization of border color, size, and style, as well as placeholder text and color.
    /// It also provides events for text changed and supports password masking.
    /// </remarks>
    [DefaultEvent("TextChangedEvent")]
    public partial class CustomTextBox : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "TextChangedEvent" event is raised when the text of the control has changed.
        /// </summary>
        public event EventHandler TextChangedEvent;

        #endregion

        #region Private Fields

        /// <summary>
        /// The Color "BorderColorProperty" represents the border color property.
        /// </summary>
        private Color BorderColorProperty = Color.MediumSlateBlue;

        /// <summary>
        /// The int "BorderSizeProperty" represents the border size property.
        /// </summary>
        private int BorderSizeProperty = 2;

        /// <summary>
        /// The bool "UnderlineStyleProperty" indicates whether the underline style is used.
        /// </summary>
        private bool UnderlineStyleProperty = false;

        /// <summary>
        /// The Color "BorderFocusColorProperty" represents the border focus color property.
        /// </summary>
        private Color BorderFocusColorProperty = Color.HotPink;

        /// <summary>
        /// The bool "IsFocusedProperty" indicates whether the control is focused.
        /// </summary>
        private bool IsFocusedProperty = false;

        /// <summary>
        /// The int "BorderRadiusProperty" represents the border radius property.
        /// </summary>
        private int BorderRadiusProperty = 0;

        /// <summary>
        /// The Color "PlaceHolderColorProperty" represents the placeholder color property.
        /// </summary>
        private Color PlaceHolderColorProperty = Color.DarkGray;

        /// <summary>
        /// The string "PlaceHolderTextProperty" represents the placeholder text property.
        /// </summary>
        private string PlaceHolderTextProperty = "";

        /// <summary>
        /// The bool "IsPlaceHolderProperty" indicates whether the placeholder is used.
        /// </summary>
        private bool IsPlaceHolderProperty = false;

        /// <summary>
        /// The bool "IsPasswordCharProperty" indicates whether the control uses a password character.
        /// </summary>
        private bool IsPasswordCharProperty = false;


        #endregion

        #region Constructors

        /// <summary>
        /// The "CustomTextBox" constructor initializes a new instance of the <see cref="CustomTextBox"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the CustomTextBox by initializing its components.
        /// </remarks>
        public CustomTextBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "BorderColor" property represents the border color of a control.
        /// It gets or sets the border color of the control.
        /// </summary>
        /// <value>
        /// The border color of the control.
        /// </value>
        [Category("YouChat")]
        public Color BorderColor
        {
            get 
            { 
                return BorderColorProperty;
            }
            set
            {
                BorderColorProperty = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderSize" property represents the size of the border of a control.
        /// It gets or sets the size of the border of the control.
        /// </summary>
        /// <value>
        /// The size of the border of the control.
        /// </value>
        [Category("YouChat")]
        public int BorderSize
        {
            get 
            { 
                return BorderSizeProperty;
            }
            set
            {
                BorderSizeProperty = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "UnderlineStyle" property represents whether the control has an underline style.
        /// It gets or sets the underline style of the control.
        /// </summary>
        /// <value>
        /// Whether the control has an underline style.
        /// </value>
        [Category("YouChat")]
        public bool UnderlineStyle
        {
            get 
            { 
                return UnderlineStyleProperty;
            }
            set
            {
                UnderlineStyleProperty = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderFocusColor" property represents the border color of the control when it is focused.
        /// It gets or sets the focus border color of the control.
        /// </summary>
        /// <value>
        /// The focus border color of the control.
        /// </value>
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

        /// <summary>
        /// The "IsFocused" property represents whether the control is currently focused.
        /// It gets or sets the focus status of the control.
        /// </summary>
        /// <value>
        /// Whether the control is currently focused.
        /// </value>
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

        /// <summary>
        /// The "BorderRadius" property represents the radius of the border corners of the control.
        /// It gets or sets the border radius of the control.
        /// </summary>
        /// <value>
        /// The border radius of the control.
        /// </value>
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

        /// <summary>
        /// The "PlaceHolderColor" property represents the color of the placeholder text in the control.
        /// It gets or sets the color of the placeholder text.
        /// </summary>
        /// <value>
        /// The color of the placeholder text.
        /// </value>
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
                    TextBox.ForeColor = value;
                }
            }
        }

        /// <summary>
        /// The "PlaceHolderText" property represents the placeholder text displayed in the control when it is empty.
        /// It gets or sets the placeholder text of the control.
        /// </summary>
        /// <value>
        /// The placeholder text of the control.
        /// </value>
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
                TextBox.Text = "";
                SetPlaceHolder();
            }
        }

        /// <summary>
        /// The "PasswordChar" property represents whether the control displays its text as a password character.
        /// It gets or sets whether the control displays its text as a password character.
        /// </summary>
        /// <value>
        /// Whether the control displays its text as a password character.
        /// </value>
        [Category("YouChat")]
        public bool PasswordChar
        {
            get
            {
                return IsPasswordCharProperty;
            }
            set
            {
                IsPasswordCharProperty = value;
                TextBox.UseSystemPasswordChar = value;
            }
        }

        /// <summary>
        /// The "Multiline" property represents whether the control allows multiple lines of text.
        /// It gets or sets whether the control allows multiple lines of text.
        /// </summary>
        /// <value>
        /// Whether the control allows multiple lines of text.
        /// </value>
        [Category("YouChat")]
        public bool Multiline
        {
            get
            {
                return TextBox.Multiline;
            }
            set
            {
                TextBox.Multiline = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color of the control.
        /// </summary>
        /// <value>
        /// The background color of the control.
        /// </value>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                TextBox.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control, which is the color of the text.
        /// </summary>
        /// <value>
        /// The foreground color of the control.
        /// </value>
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                TextBox.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>
        /// The font of the text displayed by the control.
        /// </value>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                TextBox.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        /// <summary>
        /// The "MaxLength" property represents the maximum number of characters the user can type or paste into the control.
        /// It gets or sets the maximum number of characters allowed in the control.
        /// </summary>
        /// <value>
        /// The maximum number of characters allowed in the control.
        /// </value>
        [Category("YouChat")]
        public int MaxLength
        {
            get
            {
                return TextBox.MaxLength;
            }
            set
            {
                TextBox.MaxLength = value;
            }
        }

        /// <summary>
        /// The "ShortcutsEnabled" property represents whether shortcut keys are enabled for the control.
        /// It gets or sets whether shortcut keys are enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if shortcut keys are enabled; otherwise, <c>false</c>.
        /// </value>
        [Category("YouChat")]
        public bool ShortcutsEnabled
        {
            get
            {
                return TextBox.ShortcutsEnabled;
            }
            set
            {
                TextBox.ShortcutsEnabled = value;
            }
        }

        /// <summary>
        /// The "TextAlign" property represents the horizontal alignment of the text in the control.
        /// It gets or sets the horizontal alignment of the text.
        /// </summary>
        /// <value>
        /// One of the <see cref="System.Windows.Forms.HorizontalAlignment"/> values.
        /// </value>
        [Category("YouChat")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return TextBox.TextAlign;
            }
            set
            {
                TextBox.TextAlign = value;
            }
        }

        /// <summary>
        /// The "ScrollBars" property represents the scroll bars to display in a multiline control.
        /// It gets or sets the scroll bars to display.
        /// </summary>
        /// <value>
        /// One of the <see cref="System.Windows.Forms.ScrollBars"/> values.
        /// </value>
        [Category("YouChat")]
        public ScrollBars ScrollBars
        {
            get
            {
                return TextBox.ScrollBars;
            }
            set
            {
                TextBox.ScrollBars = value;
            }
        }

        /// <summary>
        /// The "ReadOnly" property represents whether the text in the control is read-only.
        /// It gets or sets whether the text is read-only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the text is read-only; otherwise, <c>false</c>.
        /// </value>
        [Category("YouChat")]
        public bool ReadOnly
        {
            get
            {
                return TextBox.ReadOnly;
            }
            set
            {
                TextBox.ReadOnly = value;
            }
        }

        /// <summary>
        /// The "TextContent" property represents the text content of the control.
        /// It gets or sets the text content.
        /// </summary>
        /// <value>
        /// The text content of the control.
        /// </value>
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
                    return TextBox.Text;
                }
            }
            set
            {
                TextBox.Text = value;
                if (TextBox.Text == "")
                {
                    SetPlaceHolder();
                }
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Overrides the OnPaint method to customize the appearance of the control.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control needs to be redrawn. It customizes the appearance
        /// of the control based on its focus state, border properties, and other visual settings.
        /// </remarks>
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

        /// <summary>
        /// Overrides the OnResize method to handle control resizing.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control is resized. It updates the control's height 
        /// in design mode to ensure proper display and layout during design-time.
        /// </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        /// <summary>
        /// Overrides the OnLoad method to handle control loading.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control is loaded. It updates the control's height 
        /// to ensure proper display and layout.
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "SetPlaceHolder" method sets the placeholder text and styling for the TextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if the TextBox is empty and sets the placeholder text and color if it is.
        /// If the TextBox is set to use a password character, it temporarily disables this setting
        /// to display the placeholder text properly.
        /// </remarks>
        private void SetPlaceHolder()
        {
            if ((string.IsNullOrWhiteSpace(TextBox.Text)) && (PlaceHolderTextProperty != ""))
            {
                IsPlaceHolderProperty = true;
                TextBox.Text = PlaceHolderTextProperty;
                TextBox.ForeColor = PlaceHolderColorProperty;
                if (IsPasswordCharProperty)
                {
                    TextBox.UseSystemPasswordChar = false;
                }
            }
        }

        /// <summary>
        /// The "RemovePlaceHolder" method removes the placeholder text and resets the TextBox to its original state.
        /// </summary>
        /// <remarks>
        /// This method checks if the TextBox currently has a placeholder text set and removes it if it does.
        /// It resets the text color and, if applicable, restores the use of a password character for the TextBox.
        /// </remarks>
        private void RemovePlaceHolder()
        {
            if ((IsPlaceHolderProperty) && (PlaceHolderTextProperty != ""))
            {
                IsPlaceHolderProperty = false;
                TextBox.Text = "";
                TextBox.ForeColor = this.ForeColor;
                if (IsPasswordCharProperty)
                {
                    TextBox.UseSystemPasswordChar = true;
                }
            }
        }

        /// <summary>
        /// The "SetTextBoxRoundedRegion" method sets a rounded region for the TextBox control.
        /// </summary>
        /// <remarks>
        /// This method creates a rounded region based on the border size and border radius properties of the control.
        /// If the control is multiline, the rounded region is created with a border radius minus the border size.
        /// Otherwise, for single-line controls, the rounded region is created with a border size multiplied by 2.
        /// </remarks>
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath Path;
            if (Multiline)
            {
                Path = GraphicsHandler.GetFigurePath(TextBox.ClientRectangle, BorderRadiusProperty - BorderSizeProperty);
                TextBox.Region = new Region(Path);
            }
            else
            {
                Path = GraphicsHandler.GetFigurePath(TextBox.ClientRectangle, BorderSizeProperty * 2);
                TextBox.Region = new Region(Path);
            }
        }

        /// <summary>
        /// The "UpdateControlHeight" method updates the height of the control based on the text content.
        /// </summary>
        /// <remarks>
        /// This method calculates the height needed to display a single line of text in the control's font.
        /// It then sets the control's minimum size to accommodate this single line of text.
        /// Finally, it sets the control's height to the calculated height plus the bottom and top padding.
        /// </remarks>
        private void UpdateControlHeight()
        {
            if (TextBox.Multiline == false)
            {
                int TextHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                TextBox.Multiline = true;
                TextBox.MinimumSize = new Size(0, TextHeight);
                TextBox.Multiline = false;
                this.Height = TextBox.Height + this.Padding.Bottom + this.Padding.Top;
            }
        }

        /// <summary>
        /// The "TextBox_TextChanged" event handler method invokes the TextChangedEvent if it is not null.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the text in the TextBox changes. 
        /// It checks if the TextChangedEvent is not null and invokes it, passing the sender and event arguments.
        /// </remarks>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChangedEvent != null)
            {
                TextChangedEvent.Invoke(sender, e);
            }
        }

        /// <summary>
        /// The "TextBox_Click" event handler method triggers the Click event of the control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the TextBox is clicked. 
        /// It triggers the Click event of the control, which can be handled by subscribing to the Click event.
        /// </remarks>
        private void TextBox_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        /// <summary>
        /// The "TextBox_MouseEnter" event handler method triggers the MouseEnter event of the control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse enters the TextBox area. 
        /// It triggers the MouseEnter event of the control, which can be handled by subscribing to the MouseEnter event.
        /// </remarks>
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        /// <summary>
        /// The "TextBox_MouseLeave" event handler method triggers the MouseLeave event of the control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse leaves the TextBox area. 
        /// It triggers the MouseLeave event of the control, which can be handled by subscribing to the MouseLeave event.
        /// </remarks>
        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        /// <summary>
        /// The "TextBox_KeyDown" event handler method triggers the KeyDown event of the control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when a key is pressed while the TextBox has focus. 
        /// It triggers the KeyDown event of the control, which can be handled by subscribing to the KeyDown event.
        /// </remarks>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        /// <summary>
        /// The "TextBox_KeyPress" event handler method triggers the KeyPress event of the control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when a key is pressed while the TextBox has focus and generates a character. 
        /// It triggers the KeyPress event of the control, which can be handled by subscribing to the KeyPress event.
        /// </remarks>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        /// <summary>
        /// The "TextBox_KeyUp" event handler method triggers the KeyUp event of the control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when a key is released while the TextBox has focus. 
        /// It triggers the KeyUp event of the control, which can be handled by subscribing to the KeyUp event.
        /// </remarks>
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        /// <summary>
        /// The "TextBox_Enter" event handler method is called when the TextBox control receives focus.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the TextBox control receives focus, indicating that it is now the active control.
        /// It sets the IsFocused property to true, invalidates the control to trigger a repaint, and removes the placeholder text if present.
        /// </remarks>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            IsFocused = true;
            this.Invalidate();
            RemovePlaceHolder();
        }

        /// <summary>
        /// The "TextBox_Leave" event handler method is called when the TextBox control loses focus.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the TextBox control loses focus, indicating that it is no longer the active control.
        /// It sets the IsFocused property to false, invalidates the control to trigger a repaint, and sets the placeholder text if the TextBox is empty.
        /// </remarks>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            IsFocused = false;
            this.Invalidate();
            SetPlaceHolder();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "isPlaceHolder" method determines whether the TextBox is currently displaying placeholder text.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the TextBox is displaying placeholder text; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method returns <c>true</c> if the TextBox is currently displaying placeholder text,
        /// indicating that the TextBox is empty and has not received focus.
        /// </remarks>
        public bool isPlaceHolder()
        {
            return IsPlaceHolderProperty;
        }

        /// <summary>
        /// The "IsContainingValue" method checks if the TextBox contains any value other than the placeholder text.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the TextBox contains a value; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method returns <c>true</c> if the TextBox contains any value other than the placeholder text.
        /// If the TextBox is currently displaying the placeholder text or is empty, it returns <c>false</c>.
        /// </remarks>
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

        /// <summary>
        /// The "CancelPlaceHolder" method removes the placeholder text from the TextBox if it is currently displayed.
        /// </summary>
        /// <remarks>
        /// This method removes the placeholder text from the TextBox if it is currently displayed.
        /// It calls the "RemovePlaceHolder" method internally to perform this action.
        /// </remarks>
        public void CancelPlaceHolder()
        {
            RemovePlaceHolder();
        }

        /// <summary>
        /// The "SelectText" method selects a portion of the text in the TextBox.
        /// </summary>
        /// <param name="start">The starting position of the text to select.</param>
        /// <param name="length">The length of the text to select.</param>
        /// <remarks>
        /// This method selects a portion of the text in the TextBox, starting from the specified "start" position and
        /// extending for the specified "length" of characters.
        /// </remarks>
        public void SelectText(int start, int length)
        {
            TextBox.Select(start, length);
        }

        #endregion
    }
}
