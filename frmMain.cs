using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            for (int i = 0; i < data.Items.Count; i++)
            {
                this.createButton(data.Items[i]);
            }
        }

        private void createButton(ItemSettings item)
        {
            Button button = new Button();
            button.Text = item.text;
            button.Parent = this;
            button.Width = 849;
            button.Height = 489;
            // button.Anchor = 

            if (File.Exists(item.img))
            {
                button.BackgroundImage = Image.FromFile(item.img);
                // button.BackgroundImageLayout
            }
        }
    }
}
