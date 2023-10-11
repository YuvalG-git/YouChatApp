using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class SearchBar : UserControl
    {
        public SearchBar()
        {
            InitializeComponent();
            SearchBarCustomTextBox.PlaceHolderText = "Search...";
        }
        public event EventHandler Search;
        public CustomTextBox SeacrhBar => SearchBarCustomTextBox;
        private bool _isMouseOverSearchBar = false;


        private void SearchBar_Load(object sender, EventArgs e)
        {
            
        }

        private void OnSearch(object sender, EventArgs e)
        {
            if (_isMouseOverSearchBar)
            {
                Search?.Invoke(this, e);
            }
        }
        public void AddSearchOnClickHandler(EventHandler handler)
        {
            Search += handler;
        }

        private void SearchBarCustomTextBox_MouseDown(object sender, MouseEventArgs e)
        {
        }
        [Category("YouChat")]
        public Color BorderColor
        {
            get 
            { 
                return SearchBarCustomTextBox.BorderColor;
            }
            set
            {
                SearchBarCustomTextBox.BorderColor = value;
                this.Invalidate();
            }
        }
        [Category("YouChat")]
        public Color BorderFocusColor
        {
            get
            {
                return SearchBarCustomTextBox.BorderFocusColor;
            }
            set
            {
                SearchBarCustomTextBox.BorderFocusColor = value;
            }
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            _isMouseOverSearchBar = true;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            _isMouseOverSearchBar = false;
        }
    }
}
