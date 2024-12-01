using Newtonsoft.Json.Linq;
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
    public partial class config : Form
    {
        Auto_Click form1;
        public config(Auto_Click _form)
        {
            InitializeComponent();
            form1 = new Auto_Click();
            form1 = _form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jsonContent = File.ReadAllText(Auto_Click.dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            if (comboBox1.SelectedIndex == 0)
            {
                jsonObject["browser"] = "chrome";
            }else if (comboBox1.SelectedIndex == 1)
            {
                jsonObject["browser"] = "orbita";
            }
            File.WriteAllText(Auto_Click.dataDir, jsonObject.ToString());
        }

    }
}
