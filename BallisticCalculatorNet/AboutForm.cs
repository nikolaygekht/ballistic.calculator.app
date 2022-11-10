using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            var attr = typeof(AboutForm).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>();
            var dateStr = attr.Single(a => a.Key == "AssemblyDate")?.Value;
            label6.Text += dateStr;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var browser = new Process();
            browser.StartInfo.UseShellExecute = true;
            browser.StartInfo.FileName = (sender as LinkLabel).Text;
            browser.Start();
        }
    }
}
