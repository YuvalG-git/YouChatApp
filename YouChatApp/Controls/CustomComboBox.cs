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
    [DefaultEvent("OnSelectedIndexChanged")]
    public partial class CustomComboBox : UserControl
    {
        public CustomComboBox()
        {
            //InitializeComponent();
            ComboBoxList = new ComboBox();
            LabelText = new Label();
            ButtonIcon = new Button();
            this.SuspendLayout();

            ComboBoxList.BackColor = BackColorProperty;
            ComboBoxList.Font = new Font(this.Font.Name, 10F);
            ComboBoxList.ForeColor = ListTextColorProperty;
            ComboBoxList.SelectedIndexChanged += new EventHandler(ComboBoxList_SelectedIndexChanged);
            ComboBoxList.TextChanged += new EventHandler(ComboBoxList_TextChanged);

            ButtonIcon.Dock = DockStyle.Right;
            ButtonIcon.FlatStyle = FlatStyle.Flat;
            ButtonIcon.FlatAppearance.BorderSize = 0;
            ButtonIcon.BackColor = BackColorProperty;
            ButtonIcon.Size = new Size(30, 30);
            ButtonIcon.Cursor = Cursors.Hand;
            ButtonIcon.Click += new EventHandler(ButtonIcon_Click);
            ButtonIcon.Paint += new PaintEventHandler(ButtonIcon_Paint);

            LabelText.Dock = DockStyle.Fill;
            LabelText.AutoSize = false;
            LabelText.BackColor = BackColorProperty;
            LabelText.TextAlign = ContentAlignment.MiddleLeft;
            LabelText.Padding = new Padding(8, 0, 0, 0);
            LabelText.Font = new Font(this.Font.Name, 10F);
            LabelText.Click += new EventHandler(LabelText_Click);

            this.Controls.Add(ComboBoxList);
            this.Controls.Add(ButtonIcon);
            this.Controls.Add(LabelText);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(BorderSizeProperty);
            base.BackColor = BorderColorProperty;
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void AdjustComboBoxDimensions()
        {
            ComboBoxList.Width = LabelText.Width;
            int XCoordinate = this.Width - this.Padding.Right - ComboBoxList.Width;
            int YCoordinate = LabelText.Bottom - ComboBoxList.Height;
            ComboBoxList.Location = new Point(XCoordinate, YCoordinate);

        }

        private void LabelText_Click(object sender, EventArgs e)
        {
            ComboBoxList.Select();
            if(ComboBoxList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                ComboBoxList.DroppedDown = true;
            }
        }

        private void ButtonIcon_Paint(object sender, PaintEventArgs e)
        {
            int IconWidth = 14;
            int IconHeight = 6;
            var RectangleIcon = new Rectangle((ButtonIcon.Width - IconWidth) / 2, (ButtonIcon.Height - IconHeight) / 2, IconHeight, IconWidth);
            Graphics Graphics = e.Graphics;
            using (GraphicsPath Path = new GraphicsPath())
            {
                using (Pen Pen = new Pen(IconColorProperty, 2))
                {
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Path.AddLine(RectangleIcon.X, RectangleIcon.Y, RectangleIcon.X + (IconWidth / 2), RectangleIcon.Bottom);
                    Path.AddLine(RectangleIcon.X+(IconWidth / 2), RectangleIcon.Bottom, RectangleIcon.Right + (IconWidth / 2), RectangleIcon.Y);
                    Graphics.DrawPath(Pen, Path);

                }
            }
        }

        private void ButtonIcon_Click(object sender, EventArgs e)
        {
            ComboBoxList.Select();
            ComboBoxList.DroppedDown = true;

        }

        private void ComboBoxList_TextChanged(object sender, EventArgs e)
        {
            LabelText.Text = ComboBoxList.Text;
        }

        private void ComboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
            {
                OnSelectedIndexChanged.Invoke(sender, e);
            }
            LabelText.Text = ComboBoxList.Text;

        }

        private Color BackColorProperty = Color.WhiteSmoke;
        private Color IconColorProperty = Color.MediumSlateBlue;
        private Color ListBackColorProperty = Color.FromArgb(230, 228, 245);
        private Color ListTextColorProperty = Color.DimGray;
        private Color BorderColorProperty = Color.MediumSlateBlue;
        private int BorderSizeProperty = 1;

        private ComboBox ComboBoxList;
        private Label LabelText;
        private Button ButtonIcon;

        public event EventHandler OnSelectedIndexChanged;


    }
}
