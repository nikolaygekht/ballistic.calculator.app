﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.ReticleEditor.Forms
{
    public partial class EditPathForm : Form
    {
        public EditPathForm()
        {
            InitializeComponent();
        }

        internal void Save()
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
