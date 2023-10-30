using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
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
        private Color BackColorProperty = Color.WhiteSmoke;
        private Color IconColorProperty = Color.MediumSlateBlue;
        private Color ListBackColorProperty = Color.FromArgb(230, 228, 245);
        private Color ListTextColorProperty = Color.DimGray;
        private Color BorderColorProperty = Color.MediumSlateBlue;
        private int BorderSizeProperty = 1;
        public new Color BackColor
        {
            get
            {
                return BackColorProperty;
            }
            set
            {
                BackColorProperty = value;
                LabelText.BackColor = BackColorProperty;
                ButtonIcon.BackColor = BackColorProperty;

            }
        }
        public Color IconColor
        {
            get
            {
                return IconColorProperty;
            }
            set
            {
                IconColorProperty = value;
                ButtonIcon.Invalidate();

            }
        }
        public Color ListBackColor
        {
            get
            {
                return ListBackColorProperty;
            }
            set
            {
                ListBackColorProperty = value;
                ComboBoxList.BackColor = ListBackColorProperty;
            }
        }
        public Color ListTextColor
        {
            get
            {
                return ListTextColorProperty;
            }
            set
            {
                ListTextColorProperty = value;
                ComboBoxList.ForeColor = ListTextColorProperty;
            }
        }
        public Color BorderColor
        {
            get
            {
                return BorderColorProperty;
            }
            set
            {
                BorderColorProperty = value;
                base.BackColor = BorderColorProperty;
            }
        }
        public int BorderSize
        {
            get
            {
                return BorderSizeProperty;
            }
            set
            {
                BorderSizeProperty = value;
                this.Padding = new Padding(BorderSizeProperty);
                AdjustComboBoxDimensions();
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
                LabelText.ForeColor = value;
            }
        }
        public override Font Font //when is changed needs to change the whole controls size...
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                LabelText.Font = value;
                ComboBoxList.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
                AdjustComboBoxDimensions();
            }
        }
        public string TextContent
        {
            get
            {
                return LabelText.Text;
            }
            set
            {
                LabelText.Text = value;
            }
        }
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return ComboBoxList.DropDownStyle;
            }
            set
            {
                if (ComboBoxList.DropDownStyle != ComboBoxStyle.Simple)
                {
                    ComboBoxList.DropDownStyle = value;
                }
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return ComboBoxList.Items; }
        }
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get { return ComboBoxList.DataSource; }
            set { ComboBoxList.DataSource = value; }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return ComboBoxList.AutoCompleteCustomSource; }
            set { ComboBoxList.AutoCompleteCustomSource = value; }
        }
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return ComboBoxList.AutoCompleteSource; }
            set { ComboBoxList.AutoCompleteSource = value; }
        }
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return ComboBoxList.AutoCompleteMode; }
            set { ComboBoxList.AutoCompleteMode = value; }
        }
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return ComboBoxList.SelectedItem; }
            set { ComboBoxList.SelectedItem = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return ComboBoxList.SelectedIndex; }
            set { ComboBoxList.SelectedIndex = value; }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return ComboBoxList.DisplayMember; }
            set { ComboBoxList.DisplayMember = value; }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return ComboBoxList.ValueMember; }
            set { ComboBoxList.ValueMember = value; }
        }


        private ComboBox ComboBoxList;
        private Label LabelText;
        private Button ButtonIcon;

        public event EventHandler OnSelectedIndexChanged;

        public CustomComboBox()
        {

            //InitializeComponent();
            ComboBoxList = new ComboBox();
            LabelText = new Label();
            ButtonIcon = new Button();
            this.SuspendLayout();

            ComboBoxList.BackColor = ListBackColorProperty;
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
            LabelText.MouseEnter += new EventHandler(LabelText_MouseEnter);
            LabelText.MouseLeave += new EventHandler(LabelText_MouseLeave);


            this.Controls.Add(LabelText);
            this.Controls.Add(ButtonIcon); 
            this.Controls.Add(ComboBoxList);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(BorderSizeProperty);
            base.BackColor = BorderColorProperty;
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void LabelText_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void LabelText_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);

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
            this.OnClick(e);
            ComboBoxList.Select();
            if(ComboBoxList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                ComboBoxList.DroppedDown = true;
            }
        }
        private void UpdateControlHeight()
        {
            int TextHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
            LabelText.MinimumSize = new Size(0, TextHeight);
            this.Height = LabelText.Height + this.Padding.Bottom + this.Padding.Top;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        private void ButtonIcon_Paint(object sender, PaintEventArgs e)
        {
            int IconWidth = 14;
            int IconHeight = 6;
            var RectangleIcon = new Rectangle((ButtonIcon.Width - IconWidth) / 2, (ButtonIcon.Height - IconHeight) / 2, IconWidth, IconHeight);
            Graphics Graphics = e.Graphics;
            using (GraphicsPath Path = new GraphicsPath())
            {
                using (Pen Pen = new Pen(IconColorProperty, 2))
                {
                    Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Path.AddLine(RectangleIcon.X, RectangleIcon.Y, RectangleIcon.X + (IconWidth / 2), RectangleIcon.Bottom);
                    Path.AddLine(RectangleIcon.X+(IconWidth / 2), RectangleIcon.Bottom, RectangleIcon.Right, RectangleIcon.Y);
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
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
            AdjustComboBoxDimensions();

        }
    }
}
