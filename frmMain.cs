using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Shell
{
    public partial class frmMain : Form
    {

        private CreateOnForm formData;

        public frmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.formData =  new CreateOnForm(this);
        }

    }
}
