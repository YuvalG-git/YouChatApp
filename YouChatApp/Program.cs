using System;
using System.Collections.Generic;
using System.Linq;
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
            //Application.Run(new LoginAndRegistration());
            //Application.Run(new InitialProfileSelection());

            //Application.Run(new Profile());
            //Application.Run(new Paint());
            Application.Run(new ContactSharing());
            //Application.Run(new Document());
            //Application.Run(new ImageHandler());
            //Application.Run(new EmojiKeyboard());
            //Application.Run(new VideoCall());
            //Application.Run(new AudioCall());

            //Application.Run(new YouChat());

        }
    }
}
