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
        }
        public event EventHandler Search;
        public CustomTextBox SeacrhBar => SearchBarCustomTextBox;

        

        private void SearchBar_Load(object sender, EventArgs e)
        {

        }

        private void OnSearch(object sender, EventArgs e)
        {
            Search?.Invoke(this, e);
        }
        public void AddSearchOnClickHandler(EventHandler handler)
        {
            Search += handler;
        }

        private void SearchBarCustomTextBox_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
