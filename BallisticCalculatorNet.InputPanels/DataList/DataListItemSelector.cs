using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.InputPanels.DataList
{
    public partial class DataListItemSelector : Form
    {
        private IReadOnlyList<IDataListItem> mItems;

        class ItemContainer
        {
            private readonly IDataListItem mItem;

            public ItemContainer(IDataListItem item)
            {
                mItem = item;
            }

            public override string ToString()
            {
                return mItem.Name;
            }

            public IDataListItem Item => mItem;
        }

        public IDataListItem SelectedItem { get; private set; }
        
        public IReadOnlyList<IDataListItem> Items
        {
            get => mItems;
            set
            {
                mItems = value;
                listBox.Items.Clear();
                for (int i = 0; i < mItems.Count; i++)
                    listBox.Items.Add(new ItemContainer(mItems[i]));
            }               
        }

        public DataListItemSelector()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelectedItem = ((ItemContainer)listBox.SelectedItem)?.Item;
        }
    }
}
