using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.AttachedFiles;
using YouChatApp.AttachedFiles.PaintHandler;

namespace YouChatApp
{
    /// <summary>
    /// The "Program" class contains the entry point for the application.
    /// </summary>
    internal static class Program
    {
        #region Static Methods

        /// <summary>
        /// The "Main" method initializes the application's main form for user authentication and runs the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application.
            Application.EnableVisualStyles();
            // Set the application to use the default text rendering settings.
            Application.SetCompatibleTextRenderingDefault(false);
            // Run the application with the login form as the main form.
            Application.Run(new UserAuthentication.Forms.Login());

        }

        #endregion
    }
}
