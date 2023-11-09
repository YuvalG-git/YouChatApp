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
    public partial class CustomDateTimePicker : DateTimePicker
    {

        private Image CalendarDarkIcon = Properties.Resources.CalendarDark;
        private Image CalendarWhiteIcon = Properties.Resources.CalendarWhite;

        private Color _skinColor = Color.MediumSlateBlue;
        private Color _textColor = Color.White;
        private Color _borderColor = Color.PaleVioletRed;
        private int _borderSize = 0;

        private bool _droppedDown = false;
        private Image _calendarIcon;
        private RectangleF _iconButtonArea;
        private const int _calendarIconWidth = 34;
        private const int _arrowIconWidth = 17;


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
        public CustomDateTimePicker()
        {
            _calendarIcon = CalendarWhiteIcon;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
            InitializeComponent();
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            _droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            _droppedDown = false;

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }
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
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            _iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }
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
        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidh <= this.Width - (_calendarIconWidth + 20))
                return _calendarIconWidth;
            else 
                return _arrowIconWidth;
        }
    }
}
