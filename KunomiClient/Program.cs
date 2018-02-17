using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KunomiClient
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

            LoginForm loginForm = new LoginForm();

            Application.Run(loginForm);
            if (loginForm.DialogResult == DialogResult.OK)
            {
                KunomiClient kunomiClientForm = new KunomiClient();
                kunomiClientForm.clientSocket = loginForm.clientSocket;
                kunomiClientForm.strName = loginForm.strName;
                kunomiClientForm.epServer = loginForm.epServer;

                kunomiClientForm.ShowDialog();
            }

        }
    }
}