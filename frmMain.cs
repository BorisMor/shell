using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shell
{
    public partial class frmMain : Form
    {
     

        public frmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DataSettings data = DataSettings.GetData();
            for (int i = 0; i < data.items.Count; i++)
            {
                this.createButton(data.items[i]);
            }
        }

        private void createButton(ItemSettings item)
        {
            Button button = new Button();
            button.Text = item.text;
            button.Parent = this;
        }
    }
}
