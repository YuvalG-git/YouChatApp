using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    /// <summary>
    /// The "CircularPictureBox" class represents a custom PictureBox control that displays images in a circular shape.
    /// </summary>
    /// <remarks>
    /// This control allows customization of the border color, border size, and whether a border is displayed around the image.
    /// It draws an ellipse border around the control if the "HasBorder" property is set to true.
    /// </remarks>
    public partial class CircularPictureBox : PictureBox
    {
        #region Private Fields

        /// <summary>
        /// The bool "_hasBorder" indicates whether the control has a border.
        /// </summary>
        private bool _hasBorder = false;

        /// <summary>
        /// The int "_borderSize" represents the size of the border, if present.
        /// </summary>
        private int _borderSize = 1;

        /// <summary>
        /// The Color "_borderColor" represents the border color, if present.
        /// </summary>
        private Color _borderColor = Color.Gray;

        #endregion

        #region Properties

        /// <summary>
        /// The "HasBorder" property represents whether the control has a border.
        /// It gets or sets whether the control has a border.
        /// </summary>
        /// <value>
        /// Whether the control has a border.
        /// </value>
        public bool HasBorder
        {
            get 
            { 
                return _hasBorder; 
            }
            set 
            { 
                _hasBorder = value;
            }
        }

        /// <summary>
        /// The "BorderSize" property represents the size of the control's border.
        /// It gets or sets the size of the control's border.
        /// </summary>
        /// <value>
        /// The size of the control's border.
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
            }
        }

        /// <summary>
        /// The "BorderColor" property represents the color of the control's border.
        /// It gets or sets the color of the control's border.
        /// </summary>
        /// <value>
        /// The color of the control's border.
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
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// The "OnPaint" method handles the painting of the control.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control needs to be painted. It draws an ellipse border around the control if the "hasBorder" property is set to true.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                using (Pen PenBorder = new Pen(_borderColor, _borderSize))
                {
                    if (_hasBorder)
                    {
                        PenBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawEllipse(PenBorder, 1, 1, ClientSize.Width - 2, ClientSize.Height - 2);
                    }
                    path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                    Region = new Region(path);
                    base.OnPaint(e);
                }
            }
        }

        #endregion
    }
}
