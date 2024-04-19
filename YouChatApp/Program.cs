using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.AttachedFiles;

namespace YouChatApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //for (int i = 0; i < 4; i++)
            //{
            //    ServerCommunication.Connect("10.100.102.3");
            //}
            //Application.Run(new LoginAndRegistration());
            //Application.Run(new InitialProfileSelection(true));
            //Application.Run(new tryform());

            //Application.Run(new Profile());
            //Application.Run(new Paint());
            Application.Run(new ContactSharing());
            //Application.Run(new Document());
            //Application.Run(new ImageSender());
            //Application.Run(new EmojiKeyboard());
            //Application.Run(new VideoCall("Pogur", new Bitmap("C:\\Users\\Yuval\\Downloads\\3f82f9ff-3986-4830-858f-35afc6c6b4e5.png")));
            //Application.Run(new AudioCall("ben", new Bitmap("C:\\Users\\Yuval\\Downloads\\3f82f9ff-3986-4830-858f-35afc6c6b4e5.png")));
            //Application.Run(new Camera());
            //Application.Run(new WaitingForm());
            //Application.Run(new CallInvitation("Yuval"));
            //Application.Run(new ImageViewer(new Bitmap("C:\\Users\\Yuval\\Downloads\\3f82f9ff-3986-4830-858f-35afc6c6b4e5.png")));
            //Application.Run(new UserAuthentication.Forms.Registration());
            //Application.Run(new UserAuthentication.Forms.Login());
            //Application.Run(new UserAuthentication.Forms.PasswordRestart());
            //Application.Run(new BanForm());


            //Application.Run(new YouChat());

        }
    }
}
