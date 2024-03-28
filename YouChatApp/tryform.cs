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
    public partial class tryform : Form
    {
        public tryform()
        {
            InitializeComponent();
            personalVerificationAnswersControl1.SetQuestions(new string[] { "h", "b", "d", "f", "g" });
        }

        private void customComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
