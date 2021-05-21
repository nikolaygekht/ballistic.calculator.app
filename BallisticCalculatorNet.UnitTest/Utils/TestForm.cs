using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    internal class TestForm : Form
    {
        private readonly System.ComponentModel.IContainer components = null;

        public TestForm()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private int mItemsAdded = 0;

        public T AddControl<T>(int x, int y, int sx, int sy)
            where T : Control, new()
        {
            T t = new T()
            {
                Location = new Point(x, y),
                Size = new Size(sx, sy),
                TabIndex = ++mItemsAdded,
            };
            this.Controls.Add(t);
            return t;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TestForm
            // 
            this.ClientSize = new System.Drawing.Size(417, 253);
            this.Name = "TestForm";
            this.ResumeLayout(false);
        }
    }
}
