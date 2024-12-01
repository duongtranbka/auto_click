using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Click
{
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();
            this.Icon = new Icon( Environment.CurrentDirectory + "\\pb.ico");

        }

        private void jSubmitPassword_Click(object sender, EventArgs e)
        {
            //Auto_Click mainForm = new Auto_Click();
            //mainForm.FormClosed += (s, args) => this.Close();
            //mainForm.Show();
            //this.Hide();
            if (jInputPW.Text != "")
            {
                if (jInputPW.Text == "thena")
                {
                    Auto_Click mainForm = new Auto_Click();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    this.Hide();
                }
            }
        }
    }
}

