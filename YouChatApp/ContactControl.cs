using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class ContactControl : UserControl
    {
        public ContactControl()
        {
            InitializeComponent();
        }
        public CircularPictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public System.Windows.Forms.Label ContactName => ContactNameLabel;

        public System.Windows.Forms.CheckBox ContactSelection => ContactSharingCheckBox;



        private void ContactSharingCheckBox_Click(object sender, EventArgs e)
        {

            if (ContactSharingCheckBox.Checked)
            {
                if (ServerCommunication.SelectedContacts >= 3)
                {
                    ContactSharingCheckBox.Checked = false;

                }
                else
                {
                    ServerCommunication.SelectedContacts++;
                }
            }
            else
            {
                ServerCommunication.SelectedContacts--;
            }
        }
    }
}
