using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculatorNet.Common;

namespace BallisticCalculatorNet
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            SetupMenu();
            this.LoadFormState(Program.Configuration, "main", true);
        }

        private void SetupMenu()
        {
            menuFileExit.Click += (_, _) => this.Close();
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveFormState(Program.Configuration, "main");
        }
    }
}
