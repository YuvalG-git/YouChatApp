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
using System.Windows.Forms.Design;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "CustomDateTimePicker" class represents a custom DateTimePicker control with extended styling options.
    /// </summary>
    /// <remarks>
    /// This control allows customization of skin color, text color, border color, and border size.
    /// It also provides a custom calendar icon and adjusts its appearance based on the skin color brightness.
    /// </remarks>
    public partial class CustomDateTimePicker : DateTimePicker
    {
        #region Private Fields

        /// <summary>
        /// The Color "_skinColor" represents the skin color.
        /// </summary>
        private Color _skinColor = Color.MediumSlateBlue;

        /// <summary>
        /// The Color "_textColor" represents the text color.
        /// </summary>
        private Color _textColor = Color.White;

        /// <summary>
        /// The Color "_borderColor" represents the border color.
        /// </summary>
        private Color _borderColor = Color.PaleVioletRed;

        /// <summary>
        /// The int "_borderSize" represents the border size.
        /// </summary>
        private int _borderSize = 0;

        /// <summary>
        /// The bool "_droppedDown" indicates whether the control is dropped down.
        /// </summary>
        private bool _droppedDown = false;

        /// <summary>
        /// The Image "_calendarIcon" represents the calendar icon.
        /// </summary>
        private Image _calendarIcon;

        /// <summary>
        /// The RectangleF "_iconButtonArea" represents the icon button area.
        /// </summary>
        private RectangleF _iconButtonArea;

        #endregion

        #region Private Const Fields

        /// <summary>
        /// The int "_calendarIconWidth" represents the width of the calendar icon.
        /// </summary>
        private const int _calendarIconWidth = 34;

        /// <summary>
        /// The int "_arrowIconWidth" represents the width of the arrow icon.
        /// </summary>
        private const int _arrowIconWidth = 17;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "CalendarDarkIcon" represents the dark calendar icon.
        /// </summary>
        private readonly Image CalendarDarkIcon = Properties.Resources.CalendarDark;

        /// <summary>
        /// The readonly Image "CalendarWhiteIcon" represents the white calendar icon.
        /// </summary>
        private readonly Image CalendarWhiteIcon = Properties.Resources.CalendarWhite;
   
        #endregion

        #region Constructors

        /// <summary>
        /// The "CustomDateTimePicker" constructor initializes a new instance of the <see cref="CustomDateTimePicker"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the CustomDateTimePicker by initializing its components.
        /// </remarks>

        public CustomDateTimePicker()
        {
            _calendarIcon = CalendarWhiteIcon;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "SkinColor" property represents the skin color of the control.
        /// It gets or sets the skin color.
        /// </summary>
        /// <value>
        /// The skin color of the control.
        /// </value>
        public Color SkinColor
        {
            get
            {
                return _skinColor;
            }
            set
            {
                _skinColor = value;
                if (SkinColor.GetBrightness() >= 0.8F)
                {
                    _calendarIcon = CalendarDarkIcon;
                }
                else
                {
                    _calendarIcon = CalendarWhiteIcon;
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "TextColor" property represents the text color of the control.
        /// It gets or sets the text color.
        /// </summary>
        /// <value>
        /// The text color of the control.
        /// </value>
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderColor" property represents the border color of the control.
        /// It gets or sets the border color.
        /// </summary>
        /// <value>
        /// The border color of the control.
        /// </value>
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderSize" property represents the border size of the control.
        /// It gets or sets the border size.
        /// </summary>
        /// <value>
        /// The border size of the control.
        /// </value>
        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
            set
            {
                _borderSize = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Raises the DropDown event.
        /// </summary>
        /// <param name="eventargs">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the drop-down portion of the ComboBox is shown.
        /// It sets the _droppedDown field to true.
        /// </remarks>
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            _droppedDown = true;
        }

        /// <summary>
        /// Raises the CloseUp event.
        /// </summary>
        /// <param name="eventargs">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the drop-down portion of the ComboBox is closed.
        /// It sets the _droppedDown field to false.
        /// </remarks>
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            _droppedDown = false;
        }

        /// <summary>
        /// Raises the KeyPress event.
        /// </summary>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when a key is pressed while the ComboBox has focus.
        /// It sets the Handled property of the event args to true, indicating that the key press is handled.
        /// </remarks>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control needs to be painted.
        /// It draws the control's surface, text, calendar icon, and border based on the current properties.
        /// If the drop-down is open, it highlights the calendar icon.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics Graphics = this.CreateGraphics())
            {
                using (Pen PenBorder = new Pen(_borderColor, _borderSize))
                {
                    using (SolidBrush SkinBrush = new SolidBrush(_skinColor))
                    {
                        using (SolidBrush OpenIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
                        {
                            using (SolidBrush TextBrush = new SolidBrush(_textColor))
                            {
                                using (StringFormat TextFormat = new StringFormat())
                                {
                                    RectangleF ClientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                                    RectangleF IconArea = new RectangleF(ClientArea.Width - _calendarIconWidth, 0, _calendarIconWidth, ClientArea.Height);
                                    PenBorder.Alignment = PenAlignment.Inset;
                                    TextFormat.LineAlignment = StringAlignment.Center;
                                    //Draw surface
                                    Graphics.FillRectangle(SkinBrush, ClientArea);
                                    //Draw text
                                    Graphics.DrawString("   " + this.Text, this.Font, TextBrush, ClientArea, TextFormat);
                                    //Draw open calendar icon highlight
                                    if (_droppedDown == true)
                                    {
                                        Graphics.FillRectangle(OpenIconBrush, IconArea);
                                    }
                                    //Draw border
                                    if (_borderSize >= 1)
                                    {
                                        Graphics.DrawRectangle(PenBorder, ClientArea.X, ClientArea.Y, ClientArea.Width, ClientArea.Height);
                                    }
                                    //Draw icon
                                    Graphics.DrawImage(_calendarIcon, this.Width - _calendarIcon.Width - 9, (this.Height - _calendarIcon.Height) / 2);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raises the HandleCreated event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control's handle is created.
        /// It calculates the area for the icon button based on the current width of the control.
        /// </remarks>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            _iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }

        /// <summary>
        /// Raises the MouseMove event.
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the mouse is moved over the control.
        /// It changes the cursor to a hand cursor if the mouse is over the icon button area.
        /// </remarks>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_iconButtonArea.Contains(e.Location))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "GetIconButtonWidth" method calculates the width of the icon button based on the available space and the text width.
        /// </summary>
        /// <returns>The width of the icon button.</returns>
        /// <remarks>
        /// This method calculates the width of the icon button based on the available space in the control
        /// and the width of the text displayed. If the text can fit within the control's width after
        /// accounting for the icon, the method returns the width of the calendar icon; otherwise, it returns
        /// the width of the arrow icon.
        /// </remarks>
        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidh <= this.Width - (_calendarIconWidth + 20))
                return _calendarIconWidth;
            else 
                return _arrowIconWidth;
        }

        #endregion
    }
}
