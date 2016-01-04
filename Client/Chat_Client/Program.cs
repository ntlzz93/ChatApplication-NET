using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chat_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginform = new LoginForm();
            Application.Run(new LoginForm());

            if (loginform.DialogResult == DialogResult.OK)
            {
                ClientForm clientForm = new ClientForm();
                clientForm.clientSocket = loginform.clientSocket;
                clientForm.strName = loginform.strName;

                clientForm.ShowDialog();
            }
        }
    }
}
