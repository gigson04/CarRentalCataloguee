using System;
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Show login first. Only run the dashboard when login returns DialogResult.OK.
            using var login = new LogInForm();
            var result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new DashBoard());
            }
            // otherwise exit
        }
    }
}