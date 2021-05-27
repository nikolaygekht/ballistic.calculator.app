using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.Common
{
    public partial class ExceptionForm : Form
    {
        public ExceptionForm(object exceptionObject)
        {
            InitializeComponent();

            labelType.Text = exceptionObject.GetType().FullName;
            if (exceptionObject is Exception e)
            {
                labelMessage.Text = e.Message;
                textBoxDetails.Text = e.ToString();
                textBoxDetails.Select(0, 0);
            }
            else
                labelMessage.Text = exceptionObject.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = linkLabel1.Text;
            myProcess.Start();
        }
    }
}
