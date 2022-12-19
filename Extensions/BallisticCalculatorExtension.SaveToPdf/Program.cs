using BallisticCalculatorNet.Api.Interop;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorExtension.SaveToPdf
{
    public static class Program
    {
        public static string ApplicationFolder { get; private set; }

        public static IConfiguration Configuration { get; private set; }

        public static InteropClient Client { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            ApplicationFolder = new FileInfo(typeof(Program).Assembly.Location).Directory.FullName;

            Configuration = new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(ApplicationFolder, "configuration.json"), true)
                        .AddCommandLine(args)
                        .Build();

            var s = Configuration["interop:port"];
            if (s == null || !int.TryParse(s, out var port))
                port = 32800;
            Client = new InteropClient("localhost", port);

            try
            {
                Client.Connect();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Can't connect to a running instance of Ballistic Calculator\r\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var start = DateTime.Now;           
            s = Configuration["interop:timeout"];
            if (s == null || !int.TryParse(s, out var timeout))
                timeout = 1000;
            while (!Client.Connected && DateTime.Now - start < TimeSpan.FromMilliseconds(timeout))
                Thread.Sleep(50);

            if (!Client.Connected)
            {
                MessageBox.Show("Can't connect to a running instance of Ballistic Calculator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm();
            Application.Run(form);
        }
    }
}
