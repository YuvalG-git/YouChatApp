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
    /// <summary>
    /// The "CustomComboBox" class represents a custom ComboBox control with extended styling options.
    /// </summary>
    /// <remarks>
    /// This control allows customization of background color, icon color, list background color, list text color,
    /// border color, and border size. It provides events for selected index changed and text update.
    /// </remarks>
    [DefaultEvent("OnSelectedIndexChanged")]
    public partial class CustomComboBox : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "OnSelectedIndexChanged" event is raised when the selected index of the control is changed.
        /// </summary>
        public event EventHandler OnSelectedIndexChanged;

        /// <summary>
        /// The EventHandler "OnTextUpdate" event is raised when the text of the control is updated.
        /// </summary>
        public event EventHandler OnTextUpdate;

        #endregion

        #region Private Fields

        /// <summary>
        /// The ComboBox "ComboBoxList" represents the combo box control.
        /// </summary>
        private ComboBox ComboBoxList;

        /// <summary>
        /// The Label "LabelText" represents the label control for the text.
        /// </summary>
        private Label LabelText;

        /// <summary>
        /// The Button "ButtonIcon" represents the button control for the icon.
        /// </summary>
        private Button ButtonIcon;

        /// <summary>
        /// The Color "BackColorProperty" represents the background color property.
        /// </summary>
        private Color BackColorProperty = Color.WhiteSmoke;

        /// <summary>
        /// The Color "IconColorProperty" represents the icon color property.
        /// </summary>
        private Color IconColorProperty = Color.MediumSlateBlue;

        /// <summary>
        /// The Color "ListBackColorProperty" represents the list background color property.
        /// </summary>
        private Color ListBackColorProperty = Color.FromArgb(230, 228, 245);

        /// <summary>
        /// The Color "ListTextColorProperty" represents the list text color property.
        /// </summary>
        private Color ListTextColorProperty = Color.DimGray;

        /// <summary>
        /// The Color "BorderColorProperty" represents the border color property.
        /// </summary>
        private Color BorderColorProperty = Color.MediumSlateBlue;

        /// <summary>
        /// The int "BorderSizeProperty" represents the border size property.
        /// </summary>
        private int BorderSizeProperty = 1;

        #endregion

        #region Constructors

        /// <summary>
        /// The "CustomComboBox" constructor initializes a new instance of the <see cref="CustomComboBox"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the CustomComboBox by initializing its components.
        /// </remarks>
        public CustomComboBox()
        {
            ComboBoxList = new ComboBox();
            LabelText = new Label();
            ButtonIcon = new Button();
            this.SuspendLayout();

            ComboBoxList.BackColor = ListBackColorProperty;
            ComboBoxList.Font = new Font(this.Font.Name, 10F);
            ComboBoxList.ForeColor = ListTextColorProperty;
            ComboBoxList.SelectedIndexChanged += new EventHandler(ComboBoxList_SelectedIndexChanged);
            ComboBoxList.TextUpdate += new EventHandler(ComboBoxList_TextUpdate); ;
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

        #endregion

        #region Properties

        /// <summary>
        /// The "BackColor" property represents the background color of the control.
        /// It gets or sets the background color.
        /// </summary>
        /// <value>
        /// The background color of the control.
        /// </value>
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

        /// <summary>
        /// The "IconColor" property represents the color of the icon in the control.
        /// It gets or sets the icon color.
        /// </summary>
        /// <value>
        /// The icon color of the control.
        /// </value>
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

        /// <summary>
        /// The "ListBackColor" property represents the background color of the list in the control.
        /// It gets or sets the list background color.
        /// </summary>
        /// <value>
        /// The list background color of the control.
        /// </value>
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

        /// <summary>
        /// The "ListTextColor" property represents the text color of the list in the control.
        /// It gets or sets the list text color.
        /// </summary>
        /// <value>
        /// The list text color of the control.
        /// </value>
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
                return BorderColorProperty;
            }
            set
            {
                BorderColorProperty = value;
                base.BackColor = BorderColorProperty;
            }
        }

        /// <summary>
        /// The "BorderSize" property represents the size of the border around the control.
        /// It gets or sets the size of the border.
        /// </summary>
        /// <value>
        /// The size of the border around the control.
        /// </value>
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

        /// <summary>
        /// The "ForeColor" property represents the foreground color of the control.
        /// It gets or sets the foreground color.
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
                LabelText.ForeColor = value;
            }
        }

        /// <summary>
        /// The "Font" property represents the font of the control.
        /// It gets or sets the font.
        /// </summary>
        /// <value>
        /// The font of the control.
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
                LabelText.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
                AdjustComboBoxDimensions();
            }
        }

        /// <summary>
        /// The "TextContent" property represents the text content of the control.
        /// It gets or sets the text content.
        /// </summary>
        /// <value>
        /// The text content of the control.
        /// </value>
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

        /// <summary>
        /// The "DropDownStyle" property represents the style of the drop-down list in the combo box.
        /// It gets or sets the style of the drop-down list.
        /// </summary>
        /// <value>
        /// The style of the drop-down list in the combo box.
        /// </value>
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

        /// <summary>
        /// The "SelectedValue" property represents the selected value in the combo box.
        /// It gets or sets the selected value.
        /// </summary>
        /// <value>
        /// The selected value in the combo box.
        /// </value>
        public object SelectedValue
        {
            get
            {
                return ComboBoxList.SelectedValue;
            }
            set
            {
                ComboBoxList.SelectedValue = value;
            }
        }

        /// <summary>
        /// The "Items" property represents the collection of items in the combo box.
        /// It gets the collection of items in the combo box.
        /// </summary>
        /// <value>
        /// The collection of items in the combo box.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get 
            { 
                return ComboBoxList.Items;
            }
        }

        /// <summary>
        /// The "DataSource" property represents the data source for the combo box.
        /// It gets or sets the data source for the combo box.
        /// </summary>
        /// <value>
        /// The data source for the combo box.
        /// </value>
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get
            { 
                return ComboBoxList.DataSource;
            }
            set 
            { 
                ComboBoxList.DataSource = value;
            }
        }

        /// <summary>
        /// The "AutoCompleteCustomSource" property represents the custom auto-complete source for the combo box.
        /// It gets or sets the custom auto-complete source for the combo box.
        /// </summary>
        /// <value>
        /// The custom auto-complete source for the combo box.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get 
            { 
                return ComboBoxList.AutoCompleteCustomSource;
            }
            set 
            { 
                ComboBoxList.AutoCompleteCustomSource = value; 
            }
        }

        /// <summary>
        /// The "AutoCompleteSource" property represents the source of auto-complete strings for the combo box.
        /// It gets or sets the source of auto-complete strings for the combo box.
        /// </summary>
        /// <value>
        /// The source of auto-complete strings for the combo box.
        /// </value>
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get 
            { 
                return ComboBoxList.AutoCompleteSource;
            }
            set 
            { 
                ComboBoxList.AutoCompleteSource = value;
            }
        }

        /// <summary>
        /// The "AutoCompleteMode" property represents the auto-complete mode for the combo box.
        /// It gets or sets the auto-complete mode for the combo box.
        /// </summary>
        /// <value>
        /// The auto-complete mode for the combo box.
        /// </value>
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get 
            { 
                return ComboBoxList.AutoCompleteMode;
            }
            set 
            { 
                ComboBoxList.AutoCompleteMode = value;
            }
        }

        /// <summary>
        /// The "SelectedItem" property represents the currently selected item in the combo box.
        /// It gets or sets the currently selected item.
        /// </summary>
        /// <value>
        /// The currently selected item in the combo box.
        /// </value>
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get 
            { 
                return ComboBoxList.SelectedItem;
            }
            set 
            { 
                ComboBoxList.SelectedItem = value;
            }
        }

        /// <summary>
        /// The "SelectedIndex" property represents the index of the currently selected item in the combo box.
        /// It gets or sets the index of the currently selected item.
        /// </summary>
        /// <value>
        /// The index of the currently selected item in the combo box.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get 
            { 
                return ComboBoxList.SelectedIndex;
            }
            set 
            { 
                ComboBoxList.SelectedIndex = value;
            }
        }

        /// <summary>
        /// The "DisplayMember" property represents the property of the data source to display for each item in the combo box.
        /// It gets or sets the property of the data source to display.
        /// </summary>
        /// <value>
        /// The property of the data source to display for each item in the combo box.
        /// </value>
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get 
            { 
                return ComboBoxList.DisplayMember;
            }
            set 
            { 
                ComboBoxList.DisplayMember = value;
            }
        }

        /// <summary>
        /// The "ValueMember" property represents the property of the data source that is used to get the value of the selected item in the combo box.
        /// It gets or sets the property of the data source that is used to get the value of the selected item.
        /// </summary>
        /// <value>
        /// The property of the data source that is used to get the value of the selected item in the combo box.
        /// </value>
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get 
            { 
                return ComboBoxList.ValueMember;
            }
            set 
            { 
                ComboBoxList.ValueMember = value;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Raises the Load event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control is loaded.
        /// It updates the height of the control to accommodate the text content if it is not multiline.
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        /// <summary>
        /// Raises the Resize event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control is resized.
        /// If in design mode, it updates the height of the control to accommodate the text content if it is not multiline.
        /// It also adjusts the dimensions of the combo box.
        /// </remarks>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
            AdjustComboBoxDimensions();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "LabelText_MouseLeave" method raises the MouseLeave event for the LabelText control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the mouse pointer leaves the LabelText control.
        /// It raises the MouseLeave event for the control.
        /// </remarks>
        private void LabelText_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        /// <summary>
        /// The "LabelText_MouseEnter" method raises the MouseEnter event for the LabelText control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the mouse pointer enters the LabelText control.
        /// It raises the MouseEnter event for the control.
        /// </remarks>
        private void LabelText_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        /// <summary>
        /// The "AdjustComboBoxDimensions" method adjusts the dimensions and location of the ComboBoxList control.
        /// </summary>
        /// <remarks>
        /// This method is called to adjust the width of the ComboBoxList control to match the width of the LabelText control.
        /// It also calculates the new location of the ComboBoxList control based on the dimensions of the LabelText control.
        /// </remarks>
        private void AdjustComboBoxDimensions()
        {
            ComboBoxList.Width = LabelText.Width;
            int XCoordinate = this.Width - this.Padding.Right - ComboBoxList.Width;
            int YCoordinate = LabelText.Bottom - ComboBoxList.Height;
            ComboBoxList.Location = new Point(XCoordinate, YCoordinate);
        }

        /// <summary>
        /// The "LabelText_Click" method raises the Click event for the LabelText control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the LabelText control is clicked.
        /// It raises the Click event for the control, selects the ComboBoxList control, and opens the drop-down list if the ComboBox style is DropDownList.
        /// </remarks>
        private void LabelText_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            ComboBoxList.Select();
            if (ComboBoxList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                ComboBoxList.DroppedDown = true;
            }
        }

        /// <summary>
        /// The "UpdateControlHeight" method adjusts the height of the control based on the height of the LabelText control and the padding.
        /// </summary>
        /// <remarks>
        /// This method is called to update the height of the control to accommodate the height of the LabelText control and the padding.
        /// It calculates the minimum size needed for the LabelText control based on the current font, and then sets the height of the control accordingly.
        /// </remarks>
        private void UpdateControlHeight()
        {
            int TextHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
            LabelText.MinimumSize = new Size(0, TextHeight);
            this.Height = LabelText.Height + this.Padding.Bottom + this.Padding.Top;
        }

        /// <summary>
        /// The "ButtonIcon_Paint" method draws a custom icon on the ButtonIcon control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the ButtonIcon control is being painted.
        /// It draws a custom icon in the center of the control using a GraphicsPath and a Pen with a specified color.
        /// </remarks>
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
                    Path.AddLine(RectangleIcon.X + (IconWidth / 2), RectangleIcon.Bottom, RectangleIcon.Right, RectangleIcon.Y);
                    Graphics.DrawPath(Pen, Path);
                }
            }
        }

        /// <summary>
        /// The "ButtonIcon_Click" method raises the Click event for the ButtonIcon control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the ButtonIcon control is clicked.
        /// It selects the ComboBoxList control and opens the drop-down list.
        /// </remarks>
        private void ButtonIcon_Click(object sender, EventArgs e)
        {
            ComboBoxList.Select();
            ComboBoxList.DroppedDown = true;
        }

        /// <summary>
        /// The "ComboBoxList_TextChanged" method updates the LabelText control with the text from the ComboBoxList control when its Text property changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the Text property of the ComboBoxList control changes.
        /// It sets the Text property of the LabelText control to match the Text property of the ComboBoxList control.
        /// </remarks>
        private void ComboBoxList_TextChanged(object sender, EventArgs e)
        {
            LabelText.Text = ComboBoxList.Text;
        }

        /// <summary>
        /// The "ComboBoxList_TextUpdate" method updates the LabelText control with the text from the ComboBoxList control when its Text property is updated.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the Text property of the ComboBoxList control is updated.
        /// It sets the Text property of the LabelText control to match the Text property of the ComboBoxList control and raises the OnTextUpdate event.
        /// </remarks>
        private void ComboBoxList_TextUpdate(object sender, EventArgs e)
        {
            LabelText.Text = ComboBoxList.Text;
            if (OnTextUpdate != null)
            {
                OnTextUpdate.Invoke(sender, e);
            }
        }

        /// <summary>
        /// The "ComboBoxList_SelectedIndexChanged" method updates the LabelText control with the selected item's text from the ComboBoxList control when its SelectedIndexChanged event is raised.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the SelectedIndexChanged event of the ComboBoxList control is raised.
        /// It sets the Text property of the LabelText control to match the Text property of the selected item in the ComboBoxList control and raises the OnSelectedIndexChanged event.
        /// </remarks>
        private void ComboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelText.Text = ComboBoxList.Text;
            if (OnSelectedIndexChanged != null)
            {
                OnSelectedIndexChanged.Invoke(sender, e);
            }
        }

        #endregion
    }
}
