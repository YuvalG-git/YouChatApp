using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "CustomButton" class represents a custom Button control with extended styling options.
    /// </summary>
    /// <remarks>
    /// This control allows customization of border size, border radius, border color, background color,
    /// text color, and whether the button should be displayed as circular. It also provides a click sound effect.
    /// </remarks>
    public partial class CustomButton : Button
    {
        #region Private Fields

        /// <summary>
        /// The int "BorderSizeProperty" represents the border size property.
        /// </summary>
        private int BorderSizeProperty = 0;

        /// <summary>
        /// The int "BorderRadiusProperty" represents the border radius property.
        /// </summary>
        private int BorderRadiusProperty = 10;

        /// <summary>
        /// The Color "BorderColorProperty" represents the border color property.
        /// </summary>
        private Color BorderColorProperty = Color.PaleVioletRed;

        /// <summary>
        /// The bool "isCircular" indicates whether the control is circular.
        /// </summary>
        private bool isCircular = false;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly SoundPlayer "player" represents the sound player for click sound effects.
        /// </summary>
        private readonly SoundPlayer player = new SoundPlayer(Properties.Audio.ClickSoundEffect);

        #endregion

        #region Constructors

        /// <summary>
        /// The "CustomButton" constructor initializes a new instance of the <see cref="CustomButton"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the CustomButton by initializing its components.
        /// </remarks>
        public CustomButton()
        {
            InitializeComponent();
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(CustomButton_Resize);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Circular" property represents whether the control should be displayed as a circular shape.
        /// It gets or sets whether the control should be displayed as a circular shape.
        /// </summary>
        /// <value>
        /// Whether the control should be displayed as a circular shape.
        /// </value>
        [Category("YouChat")]
        public bool Circular
        {
            get 
            { 
                return isCircular;
            }
            set
            {
                isCircular = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderSize" property represents the size of the border around the control.
        /// It gets or sets the size of the border around the control.
        /// </summary>
        /// <value>
        /// The size of the border around the control.
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
        /// The "BorderRadius" property represents the radius of the border corners of the control.
        /// It gets or sets the radius of the border corners of the control.
        /// </summary>
        /// <value>
        /// The radius of the border corners of the control.
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
                if (value <= this.Height/2)
                {
                    BorderRadiusProperty = value;
                }
                else
                {
                    BorderRadiusProperty = this.Height/2;

                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderColor" property represents the color of the border around the control.
        /// It gets or sets the color of the border around the control.
        /// </summary>
        /// <value>
        /// The color of the border around the control.
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
        /// The "BackgroundColor" property represents the background color of the control.
        /// It gets or sets the background color of the control.
        /// </summary>
        /// <value>
        /// The background color of the control.
        /// </value>
        [Category("YouChat")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor; 
            }
            set
            {
                this.BackColor = value;
            }
        }

        /// <summary>
        /// The "TextColor" property represents the color of the text displayed by the control.
        /// It gets or sets the color of the text displayed by the control.
        /// </summary>
        /// <value>
        /// The color of the text displayed by the control.
        /// </value>
        [Category("YouChat")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// The "OnPaint" method is called when the control needs to be redrawn. It handles the painting of the control's surface and border.
        /// </summary>
        /// <param name="Pevent">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is overridden to customize the painting of the control.
        /// It draws either a circular or rounded rectangle shape based on the isCircular and BorderRadiusProperty properties.
        /// The control's surface and border are drawn using the specified BorderColorProperty and BorderSizeProperty.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs Pevent)
        {
            base.OnPaint(Pevent);
            Pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle RectangleSurface = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle RectangleBorder = new Rectangle(1, 1, this.Width - 1, this.Height - 1);
            if (isCircular)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    using (Pen PenBorder = new Pen(BorderColorProperty, BorderSizeProperty))
                    {
                        PenBorder.Alignment = PenAlignment.Inset;
                        Pevent.Graphics.DrawEllipse(PenBorder, 1, 1, ClientSize.Width - 2, ClientSize.Height - 2);
                        path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                        Region = new Region(path);
                        base.OnPaint(Pevent);
                    }
                }
            }
            else
            {
                if (BorderRadiusProperty > 2)
                {
                    using (GraphicsPath PathSurface = GraphicsHandler.GetFigurePath(RectangleSurface, BorderRadiusProperty))
                    {
                        using (GraphicsPath PathBorder = GraphicsHandler.GetFigurePath(RectangleBorder, BorderRadiusProperty - 1))
                        {
                            using (Pen PenSurface = new Pen(this.Parent.BackColor, 2))
                            {
                                using (Pen PenBorder = new Pen(BorderColorProperty, BorderSizeProperty))
                                {
                                    PenBorder.Alignment = PenAlignment.Inset;
                                    this.Region = new Region(PathSurface);
                                    Pevent.Graphics.DrawPath(PenSurface, PathSurface);
                                    if (BorderSizeProperty >= 1)
                                    {
                                        Pevent.Graphics.DrawPath(PenBorder, PathBorder);

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.Region = new Region(RectangleSurface);
                    if (BorderSizeProperty >= 1)
                    {
                        using (Pen PenBorder = new Pen(BorderColorProperty, BorderSizeProperty))
                        {
                            PenBorder.Alignment = PenAlignment.Inset;
                            Pevent.Graphics.DrawRectangle(PenBorder, 0, 0, this.Width - 1, this.Height - 1);
                        }
                    }
                }
            }    
        }

        /// <summary>
        /// The "OnHandleCreated" method is called when the control's handle is created. It attaches an event handler to the parent control's BackColorChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is overridden to perform initialization tasks when the control's handle is created.
        /// It attaches an event handler to the parent control's BackColorChanged event to handle changes in the parent control's background color.
        /// </remarks>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(ContainerBackColorChanged);
        }

        /// <summary>
        /// The "OnClick" method is called when the control is clicked. It plays a sound using the player and calls the base class implementation.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is overridden to provide custom behavior when the control is clicked.
        /// It plays a sound using the player object and then calls the base class implementation to handle the click event.
        /// </remarks>
        protected override void OnClick(EventArgs e)
        {
            player.Play();
            base.OnClick(e);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "ContainerBackColorChanged" method is called when the parent control's back color changes. It invalidates the control to trigger a repaint if in design mode.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is used to handle changes in the parent control's back color.
        /// If the control is in design mode, it invalidates the control to trigger a repaint and update its appearance.
        /// </remarks>
        private void ContainerBackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "CustomButton_Resize" method is called when the control is resized. It ensures that the BorderRadiusProperty does not exceed the control's height.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is used to handle the resize event of the control.
        /// It ensures that the BorderRadiusProperty does not exceed the control's height to maintain a visually pleasing appearance.
        /// </remarks>
        private void CustomButton_Resize(object sender, EventArgs e)
        {
            if (BorderRadiusProperty > this.Height)
            {
                BorderRadius = this.Height;
            }
        }

        #endregion
    }
}
