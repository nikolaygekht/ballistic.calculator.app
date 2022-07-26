using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallisticCalculator.Data.Dictionary;

namespace BallisticCalculatorNet.InputPanels
{
    public partial class CaliberSelectorForm : Form, ICaliberSelector
    {
        private static AmmunitionCaliberDictionary gCalibers = AmmunitionCaliberFactory.Create();

        public static AmmunitionCaliberDictionary Calibers { get; set; }
        
        public AmmunitionCaliber Caliber { get; set; }

        public IMessageFactory MessageFactory { get; set; } = new WindowsMessageFactory();

        public CaliberSelectorForm()
        {
            InitializeComponent();
            SortByType();
        }

        private int GetSelection()
        {
            var selection = -1;

            for (int i = 0; i < listViewCalibers.Items.Count; i++)
                if (listViewCalibers.Items[i].Selected)
                    selection = i;

            return selection;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            var text = textBoxFind.Text;
            
            if (string.IsNullOrEmpty(text))
                return;

            var startFrom = GetSelection() + 1;
           
            for (int i = startFrom; i < listViewCalibers.Items.Count; i++)
            {
                var lvi = listViewCalibers.Items[i];
                if (lvi.SubItems[1].Text.Contains(text))
                {
                    lvi.Selected = true;
                    lvi.Focused = true;
                    lvi.EnsureVisible();
                    return;
                }
            }
            MessageFactory.ShowMessage(this, "The caliber isn't found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            var selection = GetSelection();
            if (selection >= 0 && listViewCalibers.Items[selection].Tag is AmmunitionCaliber selectedCaliber)
                Caliber = selectedCaliber;
            else
                DialogResult = DialogResult.None;
        }

        public bool Select(IWin32Window parent)
        {
            return ShowDialog(parent) == DialogResult.OK;
        }

        private void listViewCalibers_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSelect.Enabled = listViewCalibers.SelectedIndices.Count > 0;
        }

        private void SortByType()
        {
            var calibers = gCalibers.ToArray();
            Array.Sort(calibers, (a, b) =>
            {
                if (a.TypeOfAmmunition > b.TypeOfAmmunition)
                    return 1;
                else if (a.TypeOfAmmunition < b.TypeOfAmmunition)
                    return -1;
                return string.Compare(a.Name, b.Name, true);
            });
            InitList(calibers);

        }

        private void SortByName()
        {
            var calibers = gCalibers.ToArray();
            Array.Sort(calibers, (a, b) => string.Compare(a.Name, b.Name, true));
            InitList(calibers);
        }

        private void SortByBulletDiameter()
        {
            var calibers = gCalibers.ToArray();
            Array.Sort(calibers, (a, b) =>
            {
                if (a.BulletDiameter > b.BulletDiameter)
                    return 1;
                else if (a.BulletDiameter < b.BulletDiameter)
                    return -1;
                return string.Compare(a.Name, b.Name, true);
            });
            InitList(calibers);
        }

        private void InitList(AmmunitionCaliber[] calibers)
        {
            StringBuilder sb = new StringBuilder();
            listViewCalibers.BeginUpdate();
            listViewCalibers.Items.Clear();
            for (int i = 0; i < calibers.Length; i++)
            {
                var item = calibers[i];
                var lvi = listViewCalibers.Items.Add(item.TypeOfAmmunition.ToString());
                sb.Clear();
                sb.Append(item.Name);
                if (item.AlternativeNames.Count > 0)
                {
                    sb.Append(' ').Append('(');
                    for (int j = 0; j < item.AlternativeNames.Count; j++)
                    {
                        if (j > 0)
                            sb.Append(',').Append(' ');
                        sb.Append(item.AlternativeNames[j]);
                    }
                    sb.Append(' ').Append(')');
                }
                lvi.SubItems.Add(sb.ToString());
                lvi.SubItems.Add(item.BulletDiameter.ToString());
                lvi.Tag = item;
            }
            listViewCalibers.EndUpdate();
            buttonSelect.Enabled = false;
        }

        private void listViewCalibers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
                SortByType();
            else if (e.Column == 1)
                SortByName();
            else if (e.Column == 2)
                SortByBulletDiameter();
        }
    }
}


